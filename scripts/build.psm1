function New-Directory {
    param (
        [string]$Path
    )
    if (-not (Test-Path $Path)) {
        New-Item -Path $Path -ItemType Directory -Force | Out-Null
    }
}

function Get-GitVersion {
    $VersionInfo = & dotnet-gitversion | ConvertFrom-Json
    $VersionInfo.FullSemVer
}

function New-MainNuspec {
    Param(
        [Parameter(Mandatory = $true)][string] $ProjectName,
        [Parameter(Mandatory = $true)][string] $OutputDir,
        [Parameter(Mandatory = $true)][string] $Version
    )
    New-Directory $OutputDir    
    Copy-Item -Path "LICENSE.txt" -Destination $OutputDir
    $NuspecName = "lib$ProjectName.nuspec"
    $NuspecPath = Join-Path $OutputDir $NuspecName
    $Nuspec = @"
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd">
  <metadata minClientVersion="2.12">
    <id>lib$ProjectName</id>
    <version>$Version</version>
    <authors>Summpot</authors>
    <owners>Summpot</owners>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <license type="expression">MIT</license>
    <projectUrl>https://github.com/Summpot/tree-sitter</projectUrl>
    <description>Multi-platform native library for lib$ProjectName.</description>
    <copyright>Copyright (c) 2023 Summpot</copyright>
    <repository type="git" url="https://github.com/tree-sitter/tree-sitter" branch="master" />
    <dependencies>
      <group targetFramework=".NETStandard2.0" >
        <dependency id="lib$ProjectName.runtime.linux-arm64" version="$Version" />
        <dependency id="lib$ProjectName.runtime.linux-x64" version="$Version" />
        <dependency id="lib$ProjectName.runtime.osx-arm64" version="$Version" />
        <dependency id="lib$ProjectName.runtime.osx-x64" version="$Version" />
        <dependency id="lib$ProjectName.runtime.win-arm64" version="$Version" />
        <dependency id="lib$ProjectName.runtime.win-x64" version="$Version" />
        <dependency id="lib$ProjectName.runtime.win-x86" version="$Version" />
      </group>
    </dependencies>
  </metadata><files>
    <file src="LICENSE.TXT" target="LICENSE.TXT" />
  </files>
</package>
"@
    Out-File -InputObject $Nuspec -FilePath $NuspecPath -Force
}

function New-Nuspec {
    param (
        [Parameter(Mandatory = $true)][string] $RID,
        [Parameter(Mandatory = $true)][string] $OutputDir,
        [Parameter(Mandatory = $true)][string] $ProjectName,
        [Parameter(Mandatory = $true)][string] $Version
    )
    New-Directory $OutputDir
      
    $OS, $Arch = $RID -split "-"
    $extension = switch ($OS) {
        "linux" { ".so" }
        "osx" { ".dylib" }
        "win" { ".dll" }
        Default {}
    }

    $SourceTargetName = switch ($OS) {
        "linux" { "lib$ProjectName" }
        "osx" { "lib$ProjectName" }
        "win" { "$ProjectName" }
        Default {}
    }
      
    $NuspecName = "lib$ProjectName.runtime.$RID.nuspec"
    $NuspecPath = Join-Path $OutputDir $NuspecName
    $Nuspec = @"  
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd">
  <metadata minClientVersion="2.12">
    <id>lib$ProjectName.runtime.$RID</id>
    <version>$version</version>
    <authors>Summpot</authors>
    <owners>Summpot</owners>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <license type="expression">MIT</license>
    <projectUrl>https://github.com/Summpot/tree-sitter</projectUrl>
    <description>linux arm64 native library for lib$ProjectName.</description>
    <copyright>Copyright (c) 2023 Summpot</copyright>
    <repository type="git" url="https://github.com/Summpot/tree-sitter" branch="master" />
  </metadata>
  <files>
    <file src="LICENSE.TXT" target="LICENSE.TXT" />
    <file src="$RID/$SourceTargetName$extension" target="runtimes\$RID\native\lib$ProjectName$extension" />
  </files>
</package>
"@
    Out-File -InputObject $Nuspec -FilePath $NuspecPath -Force
}

function Build-CMakeProject {
    param (
        [string] $RID,
        [string] $ProjectDir,
        [string] $CMakeBuildDir,
        [string] $OutputDir,
        [string] $LibraryName
    )
    New-Directory $OutputDir
    $BuildDir = Join-Path $CMakeBuildDir "build-$RID"
    New-Directory $BuildDir
    $OS, $Arch = $RID -split "-"
    $SystemName = switch ($OS) {
        "linux" { "Linux" }
        "osx" { "Darwin" }
        "win" { "Windows" }
        Default { "Generic" }
    }
    
    $SystemProcessor = switch ($Arch) {
        "x64" { "x64" }
        "x86" { "x86" }
        "arm64" { "aarch64" }
        Default {}
    }
    Push-Location $BuildDir
    & cmake -GNinja -DCMAKE_SYSTEM_NAME="$SystemName" -DCMAKE_SYSTEM_PROCESSOR="$SystemProcessor" "$ProjectDir"
    & cmake --build "$BuildDir"
    Pop-Location
    New-Directory $OutputDir
    $RIDDir = Join-Path $OutputDir $RID
    New-Directory $RIDDir
    switch ($OS) {
        "linux" { Copy-Item "$BuildDir/*.so" $RIDDir }
        "osx" { Copy-Item "$BuildDir/*.dylib" $RIDDir }
        "win" { Copy-Item "$BuildDir/*.dll" $RIDDir }
        Default {}
    }
}

function Build-NodeGypProject {
    Param(
        [string] $ProjectDir,
        [string] $OutputDir,
        [string] $RID
    )
    $RIDDir = Join-Path $OutputDir $RID
    New-Directory $RIDDir
    Push-Location $ProjectDir
    & pnpm install
    & tree-sitter generate
    & node-gyp configure
    & node-gyp build
    Get-ChildItem -Recurse -Filter *.node | Select-Object -First | Copy-Item $_ (Join-Path $RIDDir "$($ProjectDir.Name).$($_.Extension)")
    Pop-Location
}
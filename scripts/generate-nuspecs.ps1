[CmdletBinding(PositionalBinding = $false)]
Param(
    [switch] $MainNuspec = $false,     
    [string] $RID
)
$OS, $Arch = $RID -split "-"
$extension = switch ($OS) {
    "linux" { ".so" }
    "osx" { ".dylib" }
    "win" { ".dll" }
    Default {}
}
$NuspecsDir = "nupkgs/nuspecs"
New-Item -Path $NuspecsDir -ItemType Directory -Force | Out-Null
$VersionInfo = & dotnet-gitversion | ConvertFrom-Json
$Version = $VersionInfo.FullSemVer

Copy-Item -Path "LICENSE.txt" -Destination $NuspecsDir

if ($MainNuspec) {
    $NuspecName = "libtree-sitter.nuspec"
    $NuspecXmlPath = Join-Path $NuspecsDir $NuspecName
    $NuspecXml = @"
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd">
  <metadata minClientVersion="2.12">
    <id>libtree-sitter</id>
    <version>$Version</version>
    <authors>Summpot</authors>
    <owners>Summpot</owners>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <license type="expression">MIT</license>
    <projectUrl>https://github.com/Summpot/tree-sitter</projectUrl>
    <description>Multi-platform native library for libtree-sitter.</description>
    <copyright>Copyright (c) 2023 Summpot</copyright>
    <repository type="git" url="https://github.com/tree-sitter/tree-sitter" branch="master" />
    <dependencies>
      <group targetFramework=".NETStandard2.0" >
        <dependency id="libtree-sitter.runtime.linux-arm64" version="$Version" />
        <dependency id="libtree-sitter.runtime.linux-x64" version="$Version" />
        <dependency id="libtree-sitter.runtime.osx-arm64" version="$Version" />
        <dependency id="libtree-sitter.runtime.osx-x64" version="$Version" />
        <dependency id="libtree-sitter.runtime.win-arm64" version="$Version" />
        <dependency id="libtree-sitter.runtime.win-x64" version="$Version" />
        <dependency id="libtree-sitter.runtime.win-x86" version="$Version" />
      </group>
    </dependencies>
  </metadata><files>
    <file src="LICENSE.TXT" target="LICENSE.TXT" />
  </files>
</package>
"@
    Out-File -InputObject $NuspecXml -FilePath $NuspecXmlPath
}

if ($RID) {
    $NuspecName = "libtree-sitter.runtime.$RID.nuspec"
    $NuspecXmlPath = Join-Path $NuspecsDir $NuspecName
    $NuspecXml = @"
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd">
  <metadata minClientVersion="2.12">
    <id>libtree-sitter.runtime.$RID</id>
    <version>$version$</version>
    <authors>Summpot</authors>
    <owners>Summpot</owners>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <license type="expression">MIT</license>
    <projectUrl>https://github.com/Summpot/tree-sitter</projectUrl>
    <description>linux arm64 native library for libtree-sitter.</description>
    <copyright>Copyright (c) 2023 Summpot</copyright>
    <repository type="git" url="https://github.com/Summpot/tree-sitter" branch="master" />
  </metadata>
  <files>
    <file src="LICENSE.TXT" target="LICENSE.TXT" />
    <file src="$RID/libtree-sitter$extension" target="runtimes\$RID\native\libtree-sitter$extension" />
  </files>
</package>
"@
    Out-File -InputObject $NuspecXml -FilePath $NuspecXmlPath
}

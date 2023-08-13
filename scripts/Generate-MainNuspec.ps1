[CmdletBinding(PositionalBinding = $false)]
Param(
    [Parameter(Mandatory=$true)][string] $LibraryName,
    [Parameter(Mandatory=$true)][string] $OutputDir,
    [Parameter(Mandatory=$true)][string] $Version
)

if (-not (Test-Path $OutputDir)) {
    New-Item -Path $OutputDir -ItemType Directory -Force | Out-Null
}

Copy-Item -Path "LICENSE.txt" -Destination $OutputDir


$NuspecName = "$LibraryName.nuspec"
$NuspecPath = Join-Path $OutputDir $NuspecName
$Nuspec = @"
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd">
  <metadata minClientVersion="2.12">
    <id>$LibraryName</id>
    <version>$Version</version>
    <authors>Summpot</authors>
    <owners>Summpot</owners>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <license type="expression">MIT</license>
    <projectUrl>https://github.com/Summpot/tree-sitter</projectUrl>
    <description>Multi-platform native library for $LibraryName.</description>
    <copyright>Copyright (c) 2023 Summpot</copyright>
    <repository type="git" url="https://github.com/tree-sitter/tree-sitter" branch="master" />
    <dependencies>
      <group targetFramework=".NETStandard2.0" >
        <dependency id="$LibraryName.runtime.linux-arm64" version="$Version" />
        <dependency id="$LibraryName.runtime.linux-x64" version="$Version" />
        <dependency id="$LibraryName.runtime.osx-arm64" version="$Version" />
        <dependency id="$LibraryName.runtime.osx-x64" version="$Version" />
        <dependency id="$LibraryName.runtime.win-arm64" version="$Version" />
        <dependency id="$LibraryName.runtime.win-x64" version="$Version" />
        <dependency id="$LibraryName.runtime.win-x86" version="$Version" />
      </group>
    </dependencies>
  </metadata><files>
    <file src="LICENSE.TXT" target="LICENSE.TXT" />
  </files>
</package>
"@
Out-File -InputObject $Nuspec -FilePath $NuspecPath
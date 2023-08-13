[CmdletBinding(PositionalBinding = $false)]
Param(    
    [Parameter(Mandatory=$true)][string] $RID,
    [Parameter(Mandatory=$true)][string] $OutputDir,
    [Parameter(Mandatory=$true)][string] $LibraryName,
    [Parameter(Mandatory=$true)][string] $Version

)

if (-not (Test-Path $OutputDir)) {
  New-Item -Path $OutputDir -ItemType Directory -Force | Out-Null
}

$OS, $Arch = $RID -split "-"
$extension = switch ($OS) {
    "linux" { ".so" }
    "osx" { ".dylib" }
    "win" { ".dll" }
    Default {}
}

$NuspecName = "$LibraryName.runtime.$RID.nuspec"
$NuspecPath = Join-Path $OutputDir $NuspecName
$Nuspec = @"  
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd">
  <metadata minClientVersion="2.12">
    <id>$LibraryName.runtime.$RID</id>
    <version>$version</version>
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
    <file src="$RID/$LibraryName$extension" target="runtimes\$RID\native\$LibraryName$extension" />
  </files>
</package>
"@
Out-File -InputObject $Nuspec -FilePath $NuspecPath

Param(
    [switch] $Pack
)

function Build-MesonProject {
    Param(
        [string] $RID,
        [string] $ProjectName
    )
    $OS, $Arch = $RID -split "-"
    $Extensin = switch ($OS) {
        "win" { ".dll" }
        "osx" { ".dylib" }
        "linux" { ".so" }
        Default {}
    }

    $SourceDir = Join-Path "native/sources" $ProjectName
    $BuildDir = Join-Path $SourceDir "build-$RID"
    $CrossfilePath = "native/crossfiles/$RID.txt"
    $NuspecsDir = Join-Path $PSScriptRoot "native/nuspecs"
    
    & meson setup --cross-file "$CrossfilePath" "$BuildDir" "$SourceDir"
    & meson compile -C $BuildDir
    $TargetItem = Get-ChildItem -Path $BuildDir -Filter "*$Extensin" -File
    $TargetDir = Join-Path $NuspecsDir $RID
    $TargetPath = Join-Path $TargetDir "$($TargetItem.Name)"
    New-Item -Path $TargetDir -ItemType Directory -ErrorAction SilentlyContinue
    Copy-Item $TargetItem $TargetPath
    $NuspecPath = Join-Path $NuspecsDir "lib$ProjectName.runtime.$RID.nuspec"
    if ($Pack) {
        & nuget pack $NuspecPath
    }
}

$ErrorActionPreference = "Stop"
$ProjectNames = @("tree-sitter", "tree-sitter-c", "tree-sitter-cpp", "tree-sitter-lua")
if ($IsWindows) {
    $RIDS = @("win-x86", "win-x64", "win-arm64")
}
elseif ($IsLinux) {
    $RIDS = @("linux-x64", "linux-arm64")
}
elseif ($IsMacOS) {
    $RIDS = @("osx-x64", "osx-arm64")
}
else {
    Write-Error "System is not supported."
}
$GitVersionInfo = & dotnet-gitversion | ConvertFrom-Json
$Version = $GitVersionInfo.FullSemVer
$Nuspecs = Get-ChildItem -Path "native/nuspecs" -Filter "*.nuspec"  -File
foreach ($Nuspec in $Nuspecs) {
    $xml = [System.Xml.Linq.XDocument]::Load($Nuspec.FullName)
    $ns = $xml.Root.Name.Namespace
    $versionNodes = $xml.Descendants($ns + "version")
    foreach ($versionNode in $versionNodes) {
        $versionNode.SetValue($Version)
    }
    $dependencyNodes = $xml.Descendants($ns + "dependency")
    foreach ($dependencyNode in $dependencyNodes) {
        $versionAttribute = $dependencyNode.Attribute("version")
        if ($null -ne $versionAttribute) {
            $versionAttribute.SetValue($Version)
        }
    }
    $xml.Save($Nuspec.FullName)
}
foreach ($ProjectName in $ProjectNames) {
    foreach ($RID in $RIDS) {
        Build-MesonProject -RID $RID -ProjectName $ProjectName
        if ($Pack) {
            & nuget pack "native/nuspecs/lib$ProjectName.nuspec"
        }
        
    }  
}





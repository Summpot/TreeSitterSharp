
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
    New-Item -Path $TargetDir -ItemType Directory -ErrorAction Continue
    Copy-Item $TargetItem $TargetPath
    $NuspecPath = Join-Path $NuspecsDir "lib$ProjectName.runtime.$RID.nuspec"
    & nuget pack $NuspecPath
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
foreach ($ProjectName in $ProjectNames) {
    foreach ($RID in $RIDS) {
        Build-MesonProject -RID $RID -ProjectName $ProjectName
        & nuget pack "native/nuspecs/lib$ProjectName.nuspec"
    }  
}





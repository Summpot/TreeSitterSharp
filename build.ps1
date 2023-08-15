function Build-MesonProject {
    Param(
        $RID,
        $ProjectName
    )
    $SourceDir = "native/sources/$ProjectName"
    $BuildDir = "$SourceDir/build-$RID"
    $CrossfilePath = "native/crossfiles/$RID.txt"
    
    & meson setup --cross-file "$CrossfilePath" "$BuildDir" "$SourceDir"
    & meson compile -C $BuildDir
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

foreach ($RID in $RIDS) {
    foreach ($ProjectName in $ProjectNames) {
        Build-MesonProject -RID $RID -ProjectName $ProjectName
    }
}




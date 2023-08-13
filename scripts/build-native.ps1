[CmdletBinding(PositionalBinding = $false)]
Param(
    [string] $RID = ""
)

$ErrorActionPreference = "Continue"
$CMakeBuildDir = "cmake-build-$RID"
New-Item -Path $CMakeBuildDir -ItemType Directory -Force
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
Push-Location $CMakeBuildDir
& cmake -GNinja -DCMAKE_SYSTEM_NAME="$SystemName" -DCMAKE_SYSTEM_PROCESSOR="$SystemProcessor" "../tree-sitter"
& cmake --build .
Pop-Location
New-Item -Path "nupkgs/nuspecs/$RID" -ItemType Directory -Force
switch ($OS) {
    "linux" { Copy-Item "$CMakeBuildDir/libtree-sitter.so" "nupkgs/nuspecs/$RID/libtree-sitter.so" }
    "osx" { Copy-Item "$CMakeBuildDir/libtree-sitter.dylib" "nupkgs/nuspecs/$RID/libtree-sitter.dylib" }
    "win" { Copy-Item "$CMakeBuildDir/tree-sitter.dll" "nupkgs/nuspecs/$RID/libtree-sitter.dll" }
    Default {}
}
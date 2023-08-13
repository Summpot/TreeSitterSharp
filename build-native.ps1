[CmdletBinding(PositionalBinding = $false)]
Param(
    [string] $RID = "",
    [switch] $Help
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
switch ($OS) {
    "linux" { Copy-Item "$CMakeBuildDir/libtree-sitter.so" "pkgs/libtree-sitter/libtree-sitter.runtime.$RID/libtree-sitter.so" }
    "osx" { Copy-Item "$CMakeBuildDir/libtree-sitter.dylib" "pkgs/libtree-sitter/libtree-sitter.runtime.$RID/libtree-sitter.dylib" }
    "win" { Copy-Item "$CMakeBuildDir/tree-sitter.dll" "pkgs/libtree-sitter/libtree-sitter.runtime.$RID/libtree-sitter.dll" }
    Default {}
}
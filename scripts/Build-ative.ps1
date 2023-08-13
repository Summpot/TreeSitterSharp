[CmdletBinding(PositionalBinding = $false)]
Param(
    [string] $RID,
    [string] $ProjectDir,
    [string] $CMakeBuildDir,
    [string] $OutputDir
)
if (-not (Test-Path $OutputDir)) {
    New-Item -Path $OutputDir -ItemType Directory -Force | Out-Null
}
$BuildDir = Join-Path $CMakeBuildDir "build-$RID"
if (-not (Test-Path $BuildDir)) {
    New-Item -Path $BuildDir -ItemType Directory -Force | Out-Null
}
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
& cmake --build .
Pop-Location
if (-not (Test-Path "$OutputDir/$RID")) {
    New-Item -Path "$OutputDir/$RID" -ItemType Directory -Force | Out-Null
}
switch ($OS) {
    "linux" { Copy-Item "$BuildDir/libtree-sitter.so" "$OutputDir/$RID/libtree-sitter.so" }
    "osx" { Copy-Item "$BuildDir/libtree-sitter.dylib" "$OutputDir/$RID/libtree-sitter.dylib" }
    "win" { Copy-Item "$BuildDir/tree-sitter.dll" "$OutputDir/$RID/libtree-sitter.dll" }
    Default {}
}
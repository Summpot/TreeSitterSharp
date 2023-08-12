[CmdletBinding(PositionalBinding = $false)]
Param(
    [string] $RID = "",
    [switch] $Help
)

$ErrorActionPreference = "Continue"
$CMakeBuildDir = "cmake-build-$RID"
New-Item -Path $CMakeBuildDir -ItemType Directory -Force
$OS, $Arch = $RID -split "-"
Push-Location $CMakeBuildDir
& cmake -GNinja "../tree-sitter"
& cmake --build .
Pop-Location
Import-Module "$PSScriptRoot/scripts/build.psm1" -Force
$Version = Get-GitVersion
$Version
$RID = if ($env:RID) { $env:RID } else { "win-x64" }
$BuildDir = Join-Path $PSScriptRoot "build"
$NuspecsDir = Join-Path $BuildDir "nuspecs"
$CMakeBuildDir = Join-Path $BuildDir "cmake-build"
$NativeDir = Join-Path $PSScriptRoot "native"
$TreeSitterDir = Join-Path $NativeDir "tree-sitter"
$ParsersDir = Join-Path $NativeDir "parsers"
New-MainNuspec -OutputDir $NuspecsDir -Version $Version -ProjectName "tree-sitter"
New-Nuspec -RID $RID -OutputDir $NuspecsDir -Version $Version -ProjectName "tree-sitter"
Build-CMakeProject -RID $RID -CMakeBuildDir $CMakeBuildDir -OutputDir $NuspecsDir -ProjectDir $TreeSitterDir
Get-ChildItem $ParsersDir | ForEach-Object { Build-NodeGypProject -ProjectDir $_ -OutputDir $NuspecsDir -RID $RID}
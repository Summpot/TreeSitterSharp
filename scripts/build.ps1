[CmdletBinding(PositionalBinding = $false)]
Param(
    [Parameter(Mandatory = $true)][string] $LibraryName,
    [Parameter(Mandatory = $true)][string] $ProjectDir,
    [Parameter(Mandatory = $true)][string] $RID,
    [Parameter(Mandatory = $true)][string] $BuildDir
)
$ProjectDir = Resolve-Path (Join-Path $PWD $ProjectDir)
$Version = ./Get-GitVersion.ps1
$NuspecsDir = Join-Path $BuildDir "nuspecs"
$CMakeBuildDir = Join-Path $BuildDir "cmake-build"
./Build-Native.ps1 -RID $RID -CMakeBuildDir $CMakeBuildDir -OutputDir $NuspecsDir -ProjectDir $ProjectDir
./Generate-MainNuspec.ps1 -OutputDir $NuspecsDir -Version $Version -LibraryName $LibraryName
./Generate-Nuspec.ps1 -RID $RID -OutputDir $NuspecsDir -Version $Version -LibraryName $LibraryName
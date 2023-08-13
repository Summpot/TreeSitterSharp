[CmdletBinding(PositionalBinding = $false)]
Param(
    [Parameter(Mandatory = $true)][string] $LibraryName,
    [Parameter(Mandatory = $true)][string] $ProjectDir,
    [Parameter(Mandatory = $true)][string] $RID,
    [Parameter(Mandatory = $true)][string] $BuildDir
)
$ProjectDir = Resolve-Path (Join-Path $PWD $ProjectDir)
$Version = . "$PSScriptRoot/Get-GitVersion.ps1"
$Version
$NuspecsDir = Join-Path $BuildDir "nuspecs"
$CMakeBuildDir = Join-Path $BuildDir "cmake-build"
. "$PSScriptRoot/Build-Native.ps1" -RID $RID -CMakeBuildDir $CMakeBuildDir -OutputDir $NuspecsDir -ProjectDir $ProjectDir
. "$PSScriptRoot/Generate-MainNuspec.ps1" -OutputDir $NuspecsDir -Version $Version -LibraryName $LibraryName
. "$PSScriptRoot/Generate-Nuspec.ps1" -RID $RID -OutputDir $NuspecsDir -Version $Version -LibraryName $LibraryName
[CmdletBinding(PositionalBinding = $false)]
Param(
)
$VersionInfo = & dotnet-gitversion | ConvertFrom-Json
$Version = $VersionInfo.FullSemVer
return $Version
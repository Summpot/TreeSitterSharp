[CmdletBinding(PositionalBinding = $false)]
Param(
    [Parameter(Mandatory=$true)][string] $RID,
    [Parameter(Mandatory=$true)][string[]] $ParserGitUrls
)

foreach($parserGitUrl in $ParserUrls){
    & git clone $parserGitUrl
}
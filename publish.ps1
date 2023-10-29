Param(
    [switch]$Push
)
$tag = git describe --tags --abbrev=0
Write-Host "Tag: $tag"
$major, $minor, $patch = $tag -split '\.'
$patch = [int]$patch + 1
$newTag = "$major.$minor.$patch"
Write-Host "New tag: $newTag"
git tag $newTag
if ($Push) {
    git push --tags
}
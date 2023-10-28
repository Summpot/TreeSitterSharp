Param(
    [switch]$Push
)
$tag = git describe --tags --abbrev=0
$major, $minor, $patch = $tag -split '\.'
$patch = [int]$patch + 1
$newTag = "$major.$minor.$patch"
git tag $newTag
if ($Push) {
    git push --tags
}
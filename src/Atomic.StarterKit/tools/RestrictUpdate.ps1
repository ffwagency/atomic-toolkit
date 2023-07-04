param($installPath, $toolsPath, $package, $project)

# Get the package reference
$packageReference = $project.PackageReferences | Where-Object { $_.PackageIdentity.Id -eq $package.Id }

# Add the AllowedVersions attribute if it doesn't exist
if (-not $packageReference.AllowedVersions) {
    $allowedVersions = "[{0}]" -f $package.PackageIdentity.Version
    $packageReference.AllowedVersions = $allowedVersions

    # Save the modified project file
    $project.Save()
}
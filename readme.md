# Atomic Toolkit

## _Welcome to Atomic Toolkit for Umbraco_
Atomic Toolkit is a collection of packages for Umbraco. Its mission is to help developers and content editors fulfill their daily Umbraco tasks with less effort and more joy. So far, we have built packages related to Starter Kits, SEO, Cache, API, and more.

**All packages are meant to be a free contribution to the most friendly community! #H5YR**

For more information visit: [atomictoolkit.com](https://atomictoolkit.com/)

## How to release packages
The versioning of all packages follows Semantic Versioning 2.0.0 and matches the Umbraco version built for. This means that packages for Umbraco 11 will be with version 11.x.x, for Umbraco 12 - 12.x.x, etc. The release of all packages to NuGet is handled by a GitHub Action. Here is what the process looks like:

1. Review and merge all PRs which you want to include in the release to the 'dev' branch.
2. Versions of the packages are configured in their 'csproj' files. This means that you need to go and set the proper versions for all projects which contain changes in their 'csproj' files.
3. Ensure that all 'Atomic.*' package references on projects which will be released are correct and reflect all changes in versions you applied on the previous step. For example, if you are going to release Atomic.Seo and Atomic.StarterKit (which depends on Atomic.Seo) and you configured the version of Atomic.Seo to be '12.1.1', you should also update the PackageReference to Atomic.Seo in the Atomic.StarterKit.csproj file to be '12.1.1'.      
4. Create a branch called 'release' from dev and push it. This will trigger automatic release of the packages which versions you have updated in the second step. The process can be monitored in GitHub.
5. Create a PR from 'release' to 'master'. Review and merge it. Don't use squash in order to keep the history. Delete the release branch after merging.
6. Add (and push) tags for all packages which you have released.
using Umbraco.Cms.Core.Packaging;

namespace Atomic.Skeleton.Migrations;

public class SkeletonPackageMigrationPlan : PackageMigrationPlan
{
    public SkeletonPackageMigrationPlan() : base("Atomic.Skeleton") { }

    protected override void DefinePlan()
    {
        To<ImportPackageXmlMigration>("D6C32ED91DBD4BF4A8A7F3F26F59165C");
    }
}
using Umbraco.Cms.Core.Packaging;

namespace AtomicStarterKit.Sео.Migrations
{
    public class AtomicStarterKitSEOPackageMigrationPlan : PackageMigrationPlan
    {
        public AtomicStarterKitSEOPackageMigrationPlan() : base("Atomic-Starter-Kit-Seo") { }

        protected override void DefinePlan()
        {
            To<ImportPackageXmlMigration>(new Guid("5B6B7432-04B5-43ED-8952-C9298F3E56E0"));
        }
    }
}

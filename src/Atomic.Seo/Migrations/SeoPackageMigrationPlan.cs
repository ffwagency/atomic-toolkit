using Umbraco.Cms.Core.Packaging;

namespace Atomic.Sео.Migrations;

public class AtomicStarterKitSEOPackageMigrationPlan : PackageMigrationPlan
{
	public AtomicStarterKitSEOPackageMigrationPlan() : base("Atomic.Seo") { }

	protected override void DefinePlan()
	{
		To<ImportPackageXmlMigration>("D6C32ED91DBD4BF4A8A7F3F26F59165A");
	}
}
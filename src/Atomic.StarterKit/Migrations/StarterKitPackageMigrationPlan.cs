using Umbraco.Cms.Core.Packaging;

namespace Atomic.StarterKit.Migrations;

public class AtomicStarterKitPackageMigrationPlan : PackageMigrationPlan
{
	public AtomicStarterKitPackageMigrationPlan() : base("Atomic.StarterKit") { }

	protected override void DefinePlan()
	{
		To<ImportPackageXmlMigration>("D6C32ED91DBD4BF4A8A7F3F26F59165B");
	}
}
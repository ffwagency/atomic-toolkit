using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using Umbraco.Cms.Core.Packaging;

namespace AtomicStarterKit.Migrations;

public class AtomicStarterKitPackageMigrationPlan : PackageMigrationPlan
{
	public AtomicStarterKitPackageMigrationPlan() : base("Atomic-Starter-Kit") { }

	protected override void DefinePlan()
	{
		var checksum = GetFileChecksum();
		To<ImportPackageXmlMigration>(checksum);
	}

	private static string GetFileChecksum()
	{
		using (var sHA256 = SHA256.Create())
		{
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AtomicStarterKit.Migrations.package.zip"))
			{
				byte[] hash = sHA256.ComputeHash(stream);
				return BitConverter.ToString(hash).Replace("-", "").ToLower();
			}
		}
	}
}
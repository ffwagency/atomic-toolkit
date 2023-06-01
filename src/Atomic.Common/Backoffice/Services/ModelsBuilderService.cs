using Microsoft.Extensions.Options;
using System.Reflection;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Extensions;

namespace Atomic.Common.Backoffice.Services
{
	public class ModelsBuilderService
	{
		private const string AtomicModelsBuilderAssembliesStartsWith = "Atomic";
		private const string AtomicModelsBuilderAssembliesEndWith = "ModelsBuilder";
		private const string AtomicModelsBuilderSubDirectory = "AtomicToolkit";
		private const string AtomicModelsExtension = ".generated.cs";

		private readonly IHostingEnvironment _hostingEnvironment;
		private ModelsBuilderSettings _config;

		public ModelsBuilderService(IOptionsMonitor<ModelsBuilderSettings> config,
			 IHostingEnvironment hostingEnvironment)
		{
			_config = config.CurrentValue;
			config.OnChange(x => _config = x);
			_hostingEnvironment = hostingEnvironment;
		}

		public void GenerateAtomicModels()
		{
			var atomicModelsDirectory = GetAtomicModelsDirectoryAbsolute();
			if (!Directory.Exists(atomicModelsDirectory))
				Directory.CreateDirectory(atomicModelsDirectory);

			foreach (var assembly in GetAtomicModelsBuilderAssemblies())
			{
				var assemblyModelsSubDirectory = GetAtomicModelsSubdirectoryAbsolute(atomicModelsDirectory, assembly);
				if (!Directory.Exists(assemblyModelsSubDirectory))
					Directory.CreateDirectory(assemblyModelsSubDirectory);

				foreach (var file in Directory.GetFiles(assemblyModelsSubDirectory, "*" + AtomicModelsExtension))
					File.Delete(file);

				foreach (string embeddedResourceName in assembly.GetManifestResourceNames())
				{
					using (var embeddedResourceStream = assembly.GetManifestResourceStream(embeddedResourceName))
					{
						if (embeddedResourceStream == null)
							continue;

						var filePath = Path.Combine(assemblyModelsSubDirectory, BuildFileNameFromEmbeddedResourceName(embeddedResourceName));

						using (var fileStream = File.Create(filePath))
						{
							embeddedResourceStream.CopyTo(fileStream);
						}
					}
				}
			}
		}

		private static string BuildFileNameFromEmbeddedResourceName(string embeddedResourceName)
		{
			var fileNameWithoutExt = Path.GetFileNameWithoutExtension(embeddedResourceName);
			return fileNameWithoutExt.Substring(fileNameWithoutExt.LastIndexOf('.') + 1) + AtomicModelsExtension;
		}

		private static string GetAtomicModelsSubdirectoryAbsolute(string atomicModelsDirectory, Assembly assembly)
		{
			return Path.Combine(atomicModelsDirectory, assembly.GetName().Name!.Replace(".", string.Empty)
																			   .Replace(AtomicModelsBuilderAssembliesStartsWith, string.Empty)
																		       .Replace(AtomicModelsBuilderAssembliesEndWith, string.Empty));
		}

		private string GetAtomicModelsDirectoryAbsolute()
		{
			return Path.Combine(_config!.ModelsDirectoryAbsolute(_hostingEnvironment), AtomicModelsBuilderSubDirectory);
		}

		private static IEnumerable<Assembly> GetAtomicModelsBuilderAssemblies()
		{
			return AppDomain.CurrentDomain.GetAssemblies()
										  .Where(assembly => assembly.GetName().Name?.StartsWith(AtomicModelsBuilderAssembliesStartsWith, StringComparison.OrdinalIgnoreCase) == true
												 && assembly.GetName().Name?.EndsWith(AtomicModelsBuilderAssembliesEndWith) == true);
		}
	}
}
using System.Text;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Infrastructure.ModelsBuilder.Building;
using Umbraco.Extensions;

namespace Atomic.Common.ModelsBuilder
{
    public class AtomicModelsGenerator : IModelsGenerator
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly OutOfDateModelsStatus _outOfDateModels;
        private readonly UmbracoServices _umbracoService;
        private readonly IPublishedModelFactory _publishedModelFactory;
        private ModelsBuilderSettings _config;

        public AtomicModelsGenerator(UmbracoServices umbracoService, IOptionsMonitor<ModelsBuilderSettings> config,
            OutOfDateModelsStatus outOfDateModels, IHostingEnvironment hostingEnvironment,
            IPublishedModelFactory publishedModelFactory)
        {
            _umbracoService = umbracoService;
            _config = config.CurrentValue;
            _outOfDateModels = outOfDateModels;
            _publishedModelFactory = publishedModelFactory;
            _hostingEnvironment = hostingEnvironment;

            config.OnChange(x => _config = x);
        }

        public void GenerateModels()
        {
            var modelsDirectory = _config.ModelsDirectoryAbsolute(_hostingEnvironment);
            if (!Directory.Exists(modelsDirectory))
            {
                Directory.CreateDirectory(modelsDirectory);
            }

            foreach (var file in Directory.GetFiles(modelsDirectory, "*.generated.cs"))
            {
                File.Delete(file);
            }

            IList<TypeModel> typeModels = _umbracoService.GetAllTypes();

            var builder = new TextBuilder(_config, typeModels);

            foreach (TypeModel typeModel in builder.GetModelsToGenerate())
			{
				if (ModelExists(typeModel))
					continue;

				var sb = new StringBuilder();
				builder.Generate(sb, typeModel);
				var filename = Path.Combine(modelsDirectory, typeModel.ClrName + ".generated.cs");
				File.WriteAllText(filename, sb.ToString());
			}

			_outOfDateModels.Clear();
        }

		private bool ModelExists(TypeModel typeModel)
		{
			return _publishedModelFactory.GetModelType(typeModel.Alias) != typeof(IPublishedElement);
		}
	}
}

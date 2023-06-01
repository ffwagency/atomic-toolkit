using Atomic.Common.Backoffice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace Atomic.Common.Backoffice.Controllers
{
    public class AtomicToolkitController : UmbracoAuthorizedApiController
    {
        private readonly ModelsBuilderService _modelsBuilderService;
        private readonly ILogger<AtomicToolkitController> _logger;

		public AtomicToolkitController(ModelsBuilderService modelsBuilderService,
            ILogger<AtomicToolkitController> logger)
        {
            _modelsBuilderService = modelsBuilderService;
            _logger = logger;
		}

        [HttpGet]
        public bool RebuildModels()
        {
            try
            {
                _modelsBuilderService.GenerateAtomicModels();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AtomicToolkit: Generate Atomic Models failed");
                return false;
            }
        }
    }
}

using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;

namespace AtomicStarterKit.Sео.Migrations
{
    public class SetupAtomicStarterKitSeoPostMigration : MigrationBase
    {
        private readonly ILogger<SetupAtomicStarterKitSeoPostMigration> _logger;
        private readonly IContentService _contentService;

        public SetupAtomicStarterKitSeoPostMigration(
            ILogger<SetupAtomicStarterKitSeoPostMigration> logger,
            IContentService contentService,
            IMigrationContext context) : base(context)
        {
            _logger = logger;
            _contentService = contentService;
        }

        protected override void Migrate()
        {
            var contentHome = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "homePage");
            if (contentHome != null)
            {
                _contentService.SaveAndPublishBranch(contentHome, true);
            }
            else
            {
                _logger.LogWarning("The installed Home page was not found");
            }
        }
    }
}
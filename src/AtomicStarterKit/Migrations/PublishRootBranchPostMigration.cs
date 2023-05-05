﻿using Microsoft.Extensions.Logging;
using System.Linq;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Migrations;

public class PublishRootBranchPostMigration : MigrationBase
{
	private readonly ILogger<PublishRootBranchPostMigration> _logger;
	private readonly IContentService _contentService;

	public PublishRootBranchPostMigration(
		ILogger<PublishRootBranchPostMigration> logger,
		IContentService contentService,
		IMigrationContext context) : base(context)
	{
		_logger = logger;
		_contentService = contentService;
	}

	protected override void Migrate()
	{
		var contentHome = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == HomePage.ModelTypeAlias);
		if (contentHome != null)
			_contentService.SaveAndPublishBranch(contentHome, true);
		else
			_logger.LogWarning("The installed Home page was not found");
	}
}
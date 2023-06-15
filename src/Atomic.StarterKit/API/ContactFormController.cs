using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;
using Atomic.Common.Content;
using Atomic.StarterKit.Models;

namespace Atomic.StarterKit.API;

public class ContactFormController : SurfaceController
{
	private readonly IContentService _contentService;
	private readonly MultisiteContentService _multisiteContentService;

	public ContactFormController(
		IUmbracoContextAccessor umbracoContextAccessor,
		IUmbracoDatabaseFactory databaseFactory,
		ServiceContext services,
		AppCaches appCaches,
		IProfilingLogger profilingLogger,
		IPublishedUrlProvider publishedUrlProvider,
		IContentService contentService,
		MultisiteContentService multisiteContentService)
		: base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
	{
		_contentService = contentService;
		_multisiteContentService = multisiteContentService;
	}

	[HttpPost]
	public IActionResult Submit(ContactFormViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		var requestsContainer = _multisiteContentService.GetSharedContent<ContactEntriesContainer>();
		if (requestsContainer != null)
		{
			var entryName = string.IsNullOrWhiteSpace(model.Name) ? null : model.Name;

			var entry = _contentService.CreateAndSave($"Entry-{entryName}-{DateTime.Now}", requestsContainer.Id, "contactEntry");

			entry.SetValue(nameof(ContactEntry.ContactName), model.Name);
			entry.SetValue(nameof(ContactEntry.Email), model.Email);
			entry.SetValue(nameof(ContactEntry.Message), model.Message);

			_contentService.SaveAndPublish(entry);
		}
		else
		{
			return BadRequest();
		}

		return Ok();
	}
}

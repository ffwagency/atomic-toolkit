using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Cms.Web.Website.Controllers;
using AtomicStarterKit.Common.Services;
using System;
using AtomicStarterKit.Models;

namespace AtomicStarterKit.API
{
    public class ContactFormController : SurfaceController
	{
		private readonly IContentService _contentService;
		private readonly ContentTreeNavigator _contentTreeNavigator;

		public ContactFormController(
			IUmbracoContextAccessor umbracoContextAccessor,
			IUmbracoDatabaseFactory databaseFactory,
			ServiceContext services,
			AppCaches appCaches,
			IProfilingLogger profilingLogger,
			IPublishedUrlProvider publishedUrlProvider,
			IContentService contentService,
			ContentTreeNavigator contentTreeNavigator)
			: base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
		{
			_contentService = contentService;
			_contentTreeNavigator = contentTreeNavigator;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Submit(ContactFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return CurrentUmbracoPage();
			}

			var requestsContainer = _contentTreeNavigator.GetDataNode<ContactEntriesContainer>();
			if (requestsContainer != null)
			{
				var entryName = string.IsNullOrWhiteSpace(model.Name) ? null : model.Name;

				var entry = _contentService.CreateAndSave($"Entry-{entryName}-{DateTime.Now}", requestsContainer.Id, ContactEntry.ModelTypeAlias);

				entry.SetValue(nameof(ContactEntry.ContactName), model.Name);
				entry.SetValue(nameof(ContactEntry.Email), model.Email);
				entry.SetValue(nameof(ContactEntry.Message), model.Message);

				_contentService.SaveAndPublish(entry);
			}
			else
			{
				return CurrentUmbracoPage();
			}

			var homepage = _contentTreeNavigator.GetContentRootNode<HomePage>(HomePage.ModelTypeAlias);
			return Redirect("/");
		}
	}
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Extensions;

namespace AtomicStarterKit.Common.Services
{
    public class ContentTreeNavigator
    {
        private const string DataFolderName = "Shared Content";
        private const string SettingsFolderName = "Settings";
        private readonly ILogger<ContentTreeNavigator> _logger;
        private readonly IDomainService _domainService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUmbracoContextFactory _contextFactory;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly IPublishedValueFallback _publishedValueFallback;
        private readonly IScopeProvider _scopeProvider;

        private IUmbracoContext UmbracoContext
        {
            get
            {
                _umbracoContextAccessor.TryGetUmbracoContext(out var context);
                return context;
            }
        }

        public ContentTreeNavigator(ILogger<ContentTreeNavigator> logger,
           IDomainService domainService,
           IHttpContextAccessor httpContextAccessor,
           IUmbracoContextFactory contextFactory,
           IUmbracoContextAccessor umbracoContextAccessor,
           IPublishedValueFallback publishedValueFallback,
           IScopeProvider scopeProvider)
        {
            _logger = logger;
            _domainService = domainService;
            _httpContextAccessor = httpContextAccessor;
            _contextFactory = contextFactory;
            _umbracoContextAccessor = umbracoContextAccessor;
            _publishedValueFallback = publishedValueFallback;
            _scopeProvider = scopeProvider;
        }

        public IPublishedContent WebsiteRoot
        {
            get
            {
                var websiteHostname = _httpContextAccessor.HttpContext?.Request?.Host.Value;

                if (UmbracoContext?.PublishedRequest?.PublishedContent != null)
                    return UmbracoContext.PublishedRequest.PublishedContent.Root();

                var domain = _domainService.GetAll(true).FirstOrDefault(x => x.DomainName.Contains(websiteHostname));
                if (domain == null)
                {
                    _logger.LogError($"Cannot find Umbraco domain definition for hostname = {websiteHostname}.");
                    return default;
                }

                using var scope = _scopeProvider.CreateScope(autoComplete: true);
                using var contextRef = _contextFactory.EnsureUmbracoContext();
                var websiteRoot = contextRef.UmbracoContext.Content.GetById(domain.RootContentId.Value);
                if (websiteRoot == null)
                {
                    _logger.LogError("Cannot find website root item.");
                    return default;
                }

                return websiteRoot;
            }
        }

        public T GetSettingsNode<T>(string alias = null) where T : PublishedContentWrapped
        {
            using var scope = _scopeProvider.CreateScope(autoComplete: true);
            using var contextRef = _contextFactory.EnsureUmbracoContext();
            var settings = string.IsNullOrWhiteSpace(alias)
                ? WebsiteRoot?.Children?.FirstOrDefault(x => x.Name == SettingsFolderName)?.Descendants()?.FirstOrDefault(x => x is T)
                : WebsiteRoot?.Children?.FirstOrDefault(x => x.Name == SettingsFolderName)?.Descendants()?.FirstOrDefault(x => x.ContentType.Alias == alias);

            if (settings == null)
            {
                _logger.LogError($"Cannot find backoffice managable setting of type {typeof(T)}.");
                return default;
            }

            return string.IsNullOrWhiteSpace(alias) ? (T)settings : (T)Activator.CreateInstance(typeof(T), settings, _publishedValueFallback);
        }

        public T GetDataNode<T>(string alias = null) where T : PublishedContentWrapped
        {
            using var scope = _scopeProvider.CreateScope(autoComplete: true);
            using var contextRef = _contextFactory.EnsureUmbracoContext();

            var data = string.IsNullOrWhiteSpace(alias)
                ? WebsiteRoot?.Children?.FirstOrDefault(x => x.Name == DataFolderName)?.Descendants()?.FirstOrDefault(x => x is T)
                : WebsiteRoot?.Children?.FirstOrDefault(x => x.Name == DataFolderName)?.Descendants()?.FirstOrDefault(x => x.ContentType.Alias == alias);

            if (data == null)
            {
                _logger.LogError($"Cannot find data of type {typeof(T)}.");
                return default;
            }

            return string.IsNullOrWhiteSpace(alias) ? (T)data : (T)Activator.CreateInstance(typeof(T), data, _publishedValueFallback);
        }

        public T GetContentRootNode<T>(string alias = null) where T : PublishedContentWrapped
        {
            using var scope = _scopeProvider.CreateScope(autoComplete: true);
            using var contextRef = _contextFactory.EnsureUmbracoContext();

            var contentRoot = string.IsNullOrWhiteSpace(alias)
                ? WebsiteRoot?.Children?.FirstOrDefault(x => x is T)
                : WebsiteRoot?.Children?.FirstOrDefault(x => x.ContentType.Alias == alias);

            if (contentRoot == null)
            {
                _logger.LogError($"Cannot find content root of type {typeof(T)}.");
                return default;
            }

            return string.IsNullOrWhiteSpace(alias) ? (T)contentRoot : (T)Activator.CreateInstance(typeof(T), contentRoot, _publishedValueFallback);
        }
    }
}
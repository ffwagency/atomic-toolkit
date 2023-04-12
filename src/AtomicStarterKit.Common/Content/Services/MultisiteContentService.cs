using AtomicStarterKit.Common.Configuration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace AtomicStarterKit.Common.Content.Services;

public class MultisiteContentService
{
    private readonly ILogger<MultisiteContentService> _logger;
    private readonly IDomainService _domainService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;
    private readonly AtomicStarterKitCommonSettings _settings;

    public MultisiteContentService(ILogger<MultisiteContentService> logger,
       IDomainService domainService,
       IHttpContextAccessor httpContextAccessor,
       IUmbracoContextAccessor umbracoContextAccessor,
       IOptions<AtomicStarterKitCommonSettings> settings)
    {
        _logger = logger;
        _domainService = domainService;
        _httpContextAccessor = httpContextAccessor;
        _umbracoContextAccessor = umbracoContextAccessor;
        _settings = settings.Value;
    }

    public T? GetWebsiteRoot<T>() where T : IPublishedContent
    {
        var umbracoContext = _umbracoContextAccessor.GetRequiredUmbracoContext();

        if (umbracoContext.PublishedRequest?.PublishedContent is T)
            return (T)umbracoContext.PublishedRequest.PublishedContent.Root();

        var websiteHostname = _httpContextAccessor.HttpContext?.Request?.Host.Value ?? string.Empty;

        var domain = _domainService.GetAll(true).FirstOrDefault(x => x.DomainName.Contains(websiteHostname));
        if (domain?.RootContentId == null)
        {
            _logger.LogError("Cannot find Umbraco domain definition for {hostname}.", websiteHostname);
            return default;
        }

        var websiteRoot = umbracoContext.Content?.GetById(domain.RootContentId.Value);
        if (websiteRoot is not T t)
        {
            _logger.LogError("Cannot find website root item.");
            return default;
        }

        return t;
    }

    public T? GetSettings<T>() where T : IPublishedContent
    {
        var settings = GetWebsiteRoot<IPublishedContent>()
                       ?.Children
                       ?.FirstOrDefault(x => x.Name.InvariantEquals(_settings.WebsiteSettingsRootName))
                       ?.Descendants()
                       ?.FirstOrDefault(x => x is T);

        if (settings == null)
        {
            _logger.LogError("Cannot find setting of {type}.", typeof(T));
            return default;
        }

        return (T)settings;
    }

    public T? GetSharedContent<T>() where T : IPublishedContent
    {
        var sharedContent = GetWebsiteRoot<IPublishedContent>()
                            ?.Children
                            ?.FirstOrDefault(x => x.Name.InvariantEquals(_settings.WebsiteSharedContentRootName))
                            ?.Descendants()
                            ?.FirstOrDefault(x => x is T);

        if (sharedContent == null)
        {
            _logger.LogError("Cannot find data of type {type}.", typeof(T));
            return default;
        }

        return (T)sharedContent;
    }

    public T? GetContent<T>() where T : IPublishedContent
    {
        var contentRoot = GetWebsiteRoot<IPublishedContent>()
                          ?.Children
                          ?.FirstOrDefault(x => x is T);

        if (contentRoot == null)
        {
            _logger.LogError("Cannot find content root of type {type}.", typeof(T));
            return default;
        }

        return (T)contentRoot;
    }
}
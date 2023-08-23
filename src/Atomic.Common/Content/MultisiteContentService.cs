using Atomic.Common.Configuration;
using Atomic.Search.Fields.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Atomic.Common.Content;

public class MultisiteContentService
{
    private readonly ILogger<MultisiteContentService> _logger;
    private readonly IDomainService _domainService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;
    private readonly AtomicCommonOptions _commonOptions;

    public MultisiteContentService(ILogger<MultisiteContentService> logger,
       IDomainService domainService,
       IHttpContextAccessor httpContextAccessor,
       IUmbracoContextAccessor umbracoContextAccessor,
       IOptions<AtomicCommonOptions> commonOptions)
    {
        _logger = logger;
        _domainService = domainService;
        _httpContextAccessor = httpContextAccessor;
        _umbracoContextAccessor = umbracoContextAccessor;
        _commonOptions = commonOptions.Value;
    }

    public T GetWebsiteRoot<T>() where T : IPublishedContent
    {
        var umbracoContext = _umbracoContextAccessor.GetRequiredUmbracoContext();

        var root = GetSingeRoot<T>(umbracoContext.Content!);
        if (root != null)
            return root;

        if (umbracoContext.PublishedRequest?.PublishedContent is T)
            return (T)umbracoContext.PublishedRequest.PublishedContent.Root();

        var websiteHostname = _httpContextAccessor.HttpContext?.Request?.Host.Value ?? string.Empty;
        CannotResolveWebsiteRootException.ThrowIfCannotResolveRequestHostname(websiteHostname);

        var domain = _domainService.GetAll(true).FirstOrDefault(x => x.DomainName.Contains(websiteHostname));
        CannotResolveWebsiteRootException.ThrowIfHostnameIsNotConfigured(domain, websiteHostname);

        var websiteRoot = umbracoContext.Content!.GetById(domain!.RootContentId!.Value);
        CannotResolveWebsiteRootException.ThrowIfWebsiteRootIsNotOfType<T>(websiteRoot);

        return (T)websiteRoot!;
    }

    public T? GetSettings<T>(IPublishedContent? websiteRoot = null) where T : IPublishedContent
    {
        websiteRoot ??= GetWebsiteRoot<IPublishedContent>();

        var settings = websiteRoot
                       ?.Children
                       ?.FirstOrDefault(x => x.Name.InvariantEquals(_commonOptions.WebsiteSettingsRootName))
                       ?.Descendants()
                       ?.FirstOrDefault(x => x is T);

        if (settings == null)
        {
            _logger.LogError("Cannot find setting of {type}.", typeof(T));
            return default;
        }

        return (T)settings;
    }

    public T GetRequiredSettings<T>(IPublishedContent? websiteRoot = null) where T : IPublishedContent
    {
        var settings = GetSettings<T>(websiteRoot);
        InvalidSettingsException.ThrowIfNull(settings);
        return settings!;
    }

    public T? GetSharedContent<T>(IPublishedContent? websiteRoot = null) where T : IPublishedContent
    {
        websiteRoot ??= GetWebsiteRoot<IPublishedContent>();

        var sharedContent = websiteRoot
                            ?.Children
                            ?.FirstOrDefault(x => x.Name.InvariantEquals(_commonOptions.WebsiteSharedContentRootName))
                            ?.Descendants()
                            ?.FirstOrDefault(x => x is T);

        if (sharedContent == null)
        {
            _logger.LogError("Cannot find data of type {type}.", typeof(T));
            return default;
        }

        return (T)sharedContent;
    }

    public T? GetContent<T>(IPublishedContent? websiteRoot = null) where T : IPublishedContent
    {
        websiteRoot ??= GetWebsiteRoot<IPublishedContent>();

        var contentRoot = websiteRoot
                          ?.Children
                          ?.FirstOrDefault(x => x is T);

        if (contentRoot == null)
        {
            _logger.LogError("Cannot find content root of type {type}.", typeof(T));
            return default;
        }

        return (T)contentRoot;
    }

    private static T? GetSingeRoot<T>(IPublishedContentCache contentCache) where T : IPublishedContent
    {
        var roots = contentCache.GetAtRoot().Where(x => x is T).ToArray();
        if (roots.Length == 1)
            return (T)roots[0];

        return default;
    }
}
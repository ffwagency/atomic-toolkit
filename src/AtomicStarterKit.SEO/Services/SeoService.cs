using Microsoft.AspNetCore.Html;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;
using AtomicStarterKit.Common.Extensions;
using AtomicStarterKit.Common.Services;
using AtomicStarterKit.SEO.MetatagsProviders;
using AtomicStarterKit.Sео.Models;
using AtomicStarterKit.Sео.Interfaces;

namespace AtomicStarterKit.Sео.Services
{
    public class SeoService
    {
        private readonly List<ISeoMetatagsProvider> _seoMetatagsProviders;
        private readonly IUmbracoContextFactory _contextFactory;
        private readonly ContentTreeNavigator _contentTreeNavigator;

        private SeoBackofficeManagableSettings SeoSettings => _contentTreeNavigator.GetSettingsNode<SeoBackofficeManagableSettings>(SeoBackofficeManagableSettings.ModelTypeAlias);

        public SeoService(IUmbracoContextFactory contextFactory,
            ILocalizationService localizationService,
            ContentTreeNavigator contentTreeNavigator)
        {
            _contextFactory = contextFactory;
            _contentTreeNavigator = contentTreeNavigator;
            _seoMetatagsProviders = new List<ISeoMetatagsProvider>
            {
                new BasicSeoMetatagsProvider(),
                new SeoUrlsMetatagProvider(localizationService),
                new NoIndexNoFollowSeoMetatagsProvider(),
                new FacebookSeoMetatagsProvider(),
                new TwitterSeoMetatagsProvider()
            };
        }

        public HtmlString GetPageSeoHtml(IPublishedContent page)
        {
            if (page == null)
                throw new ArgumentNullException($"{nameof(page)} cannot be null.");
            if (SeoSettings == null)
                return HtmlString.Empty;

            var sb = new StringBuilder();
            foreach (var provider in _seoMetatagsProviders)
                sb.AppendLine(provider.GetHtml(page, SeoSettings));

            return new HtmlString(sb.ToString());
        }

        public string GetRobotsTxt()
        {
            if (SeoSettings == null)
                return string.Empty;

            using var contextRef = _contextFactory.EnsureUmbracoContext();
            return SeoSettings.RobotsTxt;
        }

        public string GetSitemapXml()
        {
            if (SeoSettings == null)
                return string.Empty;

            using var contextRef = _contextFactory.EnsureUmbracoContext();
            var sitemapRoot = SeoSettings.Root();
            var nodes = new List<SitemapNode>();
            nodes.AddRange(BuildSitemapNode(sitemapRoot));
            LoadSitemapNodes(sitemapRoot, nodes);
            return GetSitemapDocument(nodes);
        }

        private static string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    new XElement(xmlns + "lastmod", sitemapNode.LastModified.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    new XElement(xmlns + "changefreq", sitemapNode.Frequency.ToString().ToLowerInvariant()),
                    new XElement(xmlns + "priority", sitemapNode.Priority.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }

        private void LoadSitemapNodes(IPublishedContent root, List<SitemapNode> nodes)
        {
            var children = root.ChildrenForAllCultures;

            foreach (var child in children)
            {
                if (!child.ContentType.CompositionAliases.Contains("seoBasePage") && !child.ContentType.CompositionAliases.Contains("basePage"))
                    continue;

                if (child.Value<bool>("noIndex"))
                    continue;

                if (child.Value<bool>("noFollow"))
                    continue;

                nodes.AddRange(BuildSitemapNode(child));
            }

            foreach (var child in children)
                LoadSitemapNodes(child, nodes);
        }

        private static List<SitemapNode> BuildSitemapNode(IPublishedContent publishedContent)
        {
            var nodes = new List<SitemapNode>();
            var date = publishedContent.UpdateDate;

            var cultureSpecificUrl = false;
            foreach (var lang in publishedContent.Cultures.Keys.Select(x => x.CultureRegionToUpper()))
            {
                var url = publishedContent.Url(lang, UrlMode.Absolute);
                if (url == "#")
                    continue;

                cultureSpecificUrl = true;

                if (publishedContent.Value<bool>("denyOnLive", lang))
                    continue;

                var node = new SitemapNode { Url = url, LastModified = date };
                nodes.Add(node);
            }

            if (!cultureSpecificUrl)
            {
                var url = publishedContent.Url(null, UrlMode.Absolute);
                if (url != "#")
                {
                    var node = new SitemapNode { Url = url, LastModified = date };
                    nodes.Add(node);
                }
            }

            return nodes;
        }
    }
}
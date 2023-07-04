using System.Globalization;
using System.Xml.Linq;
using Atomic.Seo.SitemapXml.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Seo.SitemapXml;

public class SitemapService
{
    public string GetSitemapXml(ISeoBasePage websiteRoot)
    {
        var sitemapXmlNodes = new List<SitemapXmlNode>();
        AddWebsiteRoot(sitemapXmlNodes, websiteRoot);
        AddChildrenRecursively(sitemapXmlNodes, websiteRoot);
        return BuildSitemapXml(sitemapXmlNodes);
    }

    private static void AddWebsiteRoot(List<SitemapXmlNode> sitemapXmlNodes, ISeoBasePage websiteRoot)
    {
        sitemapXmlNodes.AddRange(BuildSitemapXmlNodes(websiteRoot));
    }

    private static void AddChildrenRecursively(List<SitemapXmlNode> sitemapXmlNodes, ISeoBasePage websiteRoot)
    {
        foreach (var child in websiteRoot.ChildrenForAllCultures)
        {
            if (child is not ISeoBasePage seoPage)
                continue;

            sitemapXmlNodes.AddRange(BuildSitemapXmlNodes(seoPage));

            AddChildrenRecursively(sitemapXmlNodes, seoPage);
        }
    }

    private static string BuildSitemapXml(IEnumerable<SitemapXmlNode> sitemapXmlNodes)
    {
        XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
        XElement root = new(xmlns + "urlset");

        foreach (SitemapXmlNode sitemapXmlNode in sitemapXmlNodes)
        {
            XElement urlElement = new(
                xmlns + "url",
                new XElement(xmlns + "loc", sitemapXmlNode.Url),
                new XElement(xmlns + "lastmod", sitemapXmlNode.LastModified.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")),
                new XElement(xmlns + "changefreq", sitemapXmlNode.ChangeFrequency.ToString().ToLowerInvariant()),
                new XElement(xmlns + "priority", sitemapXmlNode.Priority.ToString("F1", CultureInfo.InvariantCulture)));
            root.Add(urlElement);
        }

        XDocument document = new(root);
        return document.ToString();
    }

    private static List<SitemapXmlNode> BuildSitemapXmlNodes(ISeoBasePage seoPage)
    {
        var xmlNodes = new List<SitemapXmlNode>();

        if (seoPage.NoFollow || seoPage.NoIndex)
            return xmlNodes;

        foreach (var culture in seoPage.Cultures.Keys)
        {
            var url = seoPage.GetAbsoluteUrl(culture);
            xmlNodes.Add(new SitemapXmlNode(url, seoPage.UpdateDate, seoPage.ChangeFrequency, seoPage.Priority));
        }

        return xmlNodes;
    }
}
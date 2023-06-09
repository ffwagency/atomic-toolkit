﻿using Microsoft.AspNetCore.Html;
using System.Text;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Seo.Html;

public class SeoHtmlTagsService
{
    private readonly SeoHtmlTagsCollection _seoHtmlTagsCollection;

    public SeoHtmlTagsService(SeoHtmlTagsCollection seoHtmlTagsCollection)
    {
        _seoHtmlTagsCollection = seoHtmlTagsCollection;
    }

    public HtmlString GetHtmlTags(ISeoBasePage seoPage, SeoSettings seoSettings)
    {
        var html = new StringBuilder();

        foreach (var seoHtmlTags in _seoHtmlTagsCollection)
            html.AppendLine(seoHtmlTags.Get(seoPage, seoSettings));

        return new HtmlString(html.ToString());
    }
}
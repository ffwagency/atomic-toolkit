﻿using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Seo.Html.Tags;

public class CanonicalUrl : ISeoHtmlTags
{
    public virtual string Get(ISeoBasePage seoPage, SeoSettings seoSettings)
    {
        var url = seoPage.GetAbsoluteUrl();
        return $@"<link rel=""canonical"" href=""{url}"">{Environment.NewLine}";
    }
}
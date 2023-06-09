using Atomic.OutputCache.Mvc.ApplicationModels;
using Microsoft.AspNetCore.OutputCaching;
using Umbraco.Cms.Web.Common.Controllers;

namespace Atomic.OutputCache.Mvc.Controllers;

[OutputCache]
[PreviewRoute]
public class CachedUmbracoApiController : UmbracoApiController
{ }
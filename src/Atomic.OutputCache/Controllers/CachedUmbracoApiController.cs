using Atomic.Common.Api.PreviewRoute;
using Microsoft.AspNetCore.OutputCaching;
using Umbraco.Cms.Web.Common.Controllers;

namespace Atomic.OutputCache.Controllers;

[OutputCache]
[PreviewRoute]
public class CachedUmbracoApiController : UmbracoApiController
{ }
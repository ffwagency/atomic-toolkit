using Microsoft.AspNetCore.OutputCaching;
using Umbraco.Cms.Web.Common.Controllers;

namespace Atomic.OutputCache.Controllers;

[OutputCache]
public class CachedUmbracoApiController : UmbracoApiController
{ }
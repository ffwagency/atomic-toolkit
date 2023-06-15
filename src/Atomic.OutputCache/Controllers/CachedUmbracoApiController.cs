using Atomic.Common.Api.Multilanguage;
using Atomic.Common.Api.Preview;
using Microsoft.AspNetCore.OutputCaching;
using Umbraco.Cms.Web.Common.Controllers;

namespace Atomic.OutputCache.Controllers;

[OutputCache]
[EnablePreviewRoute]
[SetContextCulture]
public class CachedUmbracoApiController : UmbracoApiController
{ }
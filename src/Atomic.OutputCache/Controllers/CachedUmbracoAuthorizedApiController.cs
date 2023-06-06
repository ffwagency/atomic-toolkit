using Microsoft.AspNetCore.OutputCaching;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace Atomic.OutputCache.Controllers;

[OutputCache]
public class CachedUmbracoAuthorizedApiController : UmbracoAuthorizedApiController
{ }
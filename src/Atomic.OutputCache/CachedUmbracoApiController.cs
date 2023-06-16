using Atomic.Common.Api;
using Atomic.Common.Api.Preview;
using Microsoft.AspNetCore.OutputCaching;
using Umbraco.Cms.Web.Common.Controllers;

namespace Atomic.OutputCache;

[OutputCache(PolicyName = Constants.AtomicPolicyName)]
[EnablePreviewRoute]
[SetContextCulture]
public class CachedUmbracoApiController : UmbracoApiController
{ }
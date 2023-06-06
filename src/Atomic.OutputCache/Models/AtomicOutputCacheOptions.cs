using Atomic.Common.Backoffice.Extensions;
using Atomic.Common.Configuration.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Primitives;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Umbraco.Extensions;

namespace Atomic.OutputCache.Models;

[AtomicOptions(Constants.AtomicOutputCacheOptionsConfigurationKey)]
public class AtomicOutputCacheOptions
{
	internal const bool DefaultEnabled = true;
	internal const int DefaultCacheExpirationInMinutes = 15;

	[DefaultValue(DefaultEnabled)]
	public bool Enabled { get; set; } = DefaultEnabled;

	[DefaultValue(DefaultCacheExpirationInMinutes)]
	public int CacheExpirationInMinutes { get; set; } = DefaultCacheExpirationInMinutes;

	[JsonIgnore]
	public Func<OutputCacheContext, bool> DoesRequestQualify { get; set; } = DefaultRequestQualifier;

	public static Func<OutputCacheContext, bool> DefaultRequestQualifier = (context) =>
	{
		var request = context.HttpContext.Request;

		// Verify the method
		if (!HttpMethods.IsGet(request.Method) && !HttpMethods.IsHead(request.Method))
			return false;

		// Verify existence of authorization headers
		if (!StringValues.IsNullOrEmpty(request.Headers.Authorization) || request.HttpContext.User?.Identity?.IsAuthenticated == true)
			return false;

		// Verify if Local request. Let's don't bother local development
		if (request.IsLocal())
			return false;

		// Verify if Umbraco Preview
		if (context.HttpContext.IsPreview())
			return false;

		return true;
	};
}
using Atomic.Common.Backoffice.Extensions;
using Atomic.Common.Configuration.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Primitives;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Atomic.OutputCache.Models;

[AtomicOptions(Constants.AtomicOutputCacheOptionsConfigurationKey)]
public class AtomicOutputCacheOptions
{
	[DefaultValue(true)]
	public bool Enabled { get; set; } = true;

	[DefaultValue(15)]
	public int CacheExpirationInMinutes { get; set; } = 15;

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

		// Verify if Umbraco Preview
		if (context.HttpContext.InPreviewMode())
			return false;

		return true;
	};
}
using Atomic.Common.Backoffice;
using Atomic.Common.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Primitives;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Atomic.OutputCache;

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

	[JsonIgnore]
	public Func<OutputCacheContext, bool> DoesResponseQualify { get; set; } = DefaultResponseQualifier;

	public static Func<OutputCacheContext, bool> DefaultResponseQualifier = (context) =>
	{
		var response = context.HttpContext.Response;

		// Verify existence of cookie headers
		if (!StringValues.IsNullOrEmpty(response.Headers.SetCookie))
			return false;

		// Check response code
		if (response.StatusCode != StatusCodes.Status200OK)
			return false;

		return true;

	};
}
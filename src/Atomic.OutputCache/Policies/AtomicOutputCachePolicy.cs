using Atomic.OutputCache.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Atomic.OutputCache.Policies
{
    public sealed class AtomicOutputCachePolicy : IOutputCachePolicy
    {
		public const string DefaultTag = "AtomicOutputCachePolicy";

		private readonly AtomicOutputCacheOptions _options;

        public AtomicOutputCachePolicy(IOptions<AtomicOutputCacheOptions> options)
        {
            _options = options.Value;
        }

        ValueTask IOutputCachePolicy.CacheRequestAsync(OutputCacheContext context, CancellationToken cancellationToken)
        {
            var doesRequestQualify = _options.DoesRequestQualify(context);

            context.EnableOutputCaching = true;
            context.AllowCacheLookup = doesRequestQualify;
            context.AllowCacheStorage = doesRequestQualify;
            context.AllowLocking = true;
            context.CacheVaryByRules.QueryKeys = "*";
			context.Tags.Add(DefaultTag);
			context.ResponseExpirationTimeSpan = TimeSpan.FromMinutes(_options.CacheExpirationInMinutes);

			return ValueTask.CompletedTask;
        }

        ValueTask IOutputCachePolicy.ServeFromCacheAsync(OutputCacheContext context, CancellationToken cancellationToken)
        {
            return ValueTask.CompletedTask;
        }

        ValueTask IOutputCachePolicy.ServeResponseAsync(OutputCacheContext context, CancellationToken cancellationToken)
        {
            var response = context.HttpContext.Response;

            // Verify existence of cookie headers
            if (!StringValues.IsNullOrEmpty(response.Headers.SetCookie))
            {
                context.AllowCacheStorage = false;
                return ValueTask.CompletedTask;
            }

            // Check response code
            if (response.StatusCode != StatusCodes.Status200OK)
            {
                context.AllowCacheStorage = false;
                return ValueTask.CompletedTask;
            }

            return ValueTask.CompletedTask;
        }
    }
}
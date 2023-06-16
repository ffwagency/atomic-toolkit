using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Atomic.OutputCache
{
    public sealed class AtomicOutputCachePolicy : IOutputCachePolicy
    {
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
			context.Tags.Add(Constants.AtomicPolicyTag);
			context.ResponseExpirationTimeSpan = TimeSpan.FromMinutes(_options.CacheExpirationInMinutes);

			return ValueTask.CompletedTask;
        }

        ValueTask IOutputCachePolicy.ServeFromCacheAsync(OutputCacheContext context, CancellationToken cancellationToken)
        {
            return ValueTask.CompletedTask;
        }

        ValueTask IOutputCachePolicy.ServeResponseAsync(OutputCacheContext context, CancellationToken cancellationToken)
        {
            context.AllowCacheStorage = _options.DoesResponseQualify(context);
            return ValueTask.CompletedTask;
        }
    }
}
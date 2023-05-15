using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Umbraco.Extensions;
using IHostingEnvironment = Umbraco.Cms.Core.Hosting.IHostingEnvironment;

namespace Atomic.OutputCache;

public class ClearOutputCacheOnContentPublishedHandler : INotificationAsyncHandler<ContentPublishedNotification>
{
	private readonly IOutputCacheStore _outputCacheStore;
	private readonly ILogger<ClearOutputCacheOnContentPublishedHandler> _logger;
	private readonly IHostingEnvironment _hostingEnvironment;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public ClearOutputCacheOnContentPublishedHandler(IOutputCacheStore outputCacheStore,
									   ILogger<ClearOutputCacheOnContentPublishedHandler> logger,
									   IHostingEnvironment hostingEnvironment,
									   IHttpContextAccessor httpContextAccessor)
	{
		_outputCacheStore = outputCacheStore;
		_logger = logger;
		_hostingEnvironment = hostingEnvironment;
		_httpContextAccessor = httpContextAccessor;
	}

	public Task HandleAsync(ContentPublishedNotification notification, CancellationToken cancellationToken)
	{
		if (_httpContextAccessor.HttpContext?.Request.Host.Value.InvariantContains("localhost") == true)
			return Task.CompletedTask;

		var eviction = _outputCacheStore.EvictByTagAsync(Constants.DefaultPolicy, cancellationToken);

		_logger.LogInformation("Output Cache Cleared (Publish) for {SiteName}", _hostingEnvironment.SiteName);

		notification.Messages.Add(new EventMessage("Output Cache", "Cleared", EventMessageType.Success));

		return eviction.AsTask();
	}
}
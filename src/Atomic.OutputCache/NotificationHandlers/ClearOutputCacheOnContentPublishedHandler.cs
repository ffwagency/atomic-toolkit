using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using IHostingEnvironment = Umbraco.Cms.Core.Hosting.IHostingEnvironment;
using Atomic.OutputCache.Models;
using Microsoft.Extensions.Options;
using Atomic.OutputCache.Policies;

namespace Atomic.OutputCache.NotificationHandlers;

public class ClearOutputCacheOnContentPublishedHandler : INotificationAsyncHandler<ContentPublishedNotification>
{
    private readonly IOutputCacheStore _outputCacheStore;
    private readonly ILogger<ClearOutputCacheOnContentPublishedHandler> _logger;
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly AtomicOutputCacheOptions _outputCacheOptions;

    public ClearOutputCacheOnContentPublishedHandler(IOutputCacheStore outputCacheStore,
                                       ILogger<ClearOutputCacheOnContentPublishedHandler> logger,
                                       IHostingEnvironment hostingEnvironment,
                                       IOptions<AtomicOutputCacheOptions> outputCacheOptions)
    {
        _outputCacheStore = outputCacheStore;
        _logger = logger;
        _hostingEnvironment = hostingEnvironment;
        _outputCacheOptions = outputCacheOptions.Value;
    }

    public Task HandleAsync(ContentPublishedNotification notification, CancellationToken cancellationToken)
    {
        if(!_outputCacheOptions.Enabled)
            return Task.CompletedTask;

        _logger.LogInformation("Output Cache Cleared (Publish) for {SiteName}", _hostingEnvironment.SiteName);
        notification.Messages.Add(new EventMessage("Output Cache", "Cleared", EventMessageType.Success));
		var eviction = _outputCacheStore.EvictByTagAsync(AtomicOutputCachePolicy.DefaultTag, cancellationToken);
		return eviction.AsTask();
    }
}
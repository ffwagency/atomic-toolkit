using Atomic.Api.Request;
using Umbraco.Extensions;

namespace Atomic.Api;

public static class Constants
{
    public static class Configuration
    {
        public const string AtomicApiOptionsKey = Common.Configuration.Constants.AtomicOptionsConfigurationKeyPrefix + "Api";
    }

	public static class Pagination
	{
        public static readonly string PageNumberQueryStringParam = nameof(AtomicPagedRequestModel.PageNumber).ToFirstLower();
        public static readonly string PageSizeQueryStringParam = nameof(AtomicPagedRequestModel.PageSize).ToFirstLower();
    }

    public static class Api
    {
        public const string BaseApiUrl = "api/atomic";
    }
}
using Umbraco.Extensions;

namespace Atomic.Common.Api.PreviewRoute;

public static class TypeExtensions
{
	public static bool HasPreviewRouteAttribute(this Type type)
	{
		return type.HasCustomAttribute<PreviewRouteAttribute>(inherit: true /*could be configured on a base class */);
	}
}
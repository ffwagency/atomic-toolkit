using Umbraco.Extensions;

namespace Atomic.Common.Api.Preview;

public static class TypeExtensions
{
    public static bool HasPreviewRouteAttribute(this Type type)
    {
        return type.HasCustomAttribute<EnablePreviewRouteAttribute>(inherit: true /*could be configured on a base class */);
    }
}
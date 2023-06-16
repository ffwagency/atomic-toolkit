using System.Reflection;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Atomic.Api.Preview;

public static class TypeExtensions
{
	public static bool SupportsPreview(this Type type)
	{
		return SupportsPreview(type.GetTypeInfo());
	}

	public static bool SupportsPreview(this TypeInfo typeInfo)
	{
		return typeInfo.Inherits<UmbracoApiController>()
			   && typeInfo.Implements<IAtomicUmbracoApiController>()
			   && typeInfo.HasCustomAttribute<EnablePreviewAttribute>(inherit: true /*could be configured on a base class */);
	}
}
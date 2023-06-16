using Umbraco.Cms.Core.Web;

namespace Atomic.Api;

public interface IAtomicUmbracoApiController : IDisposable
{
	IUmbracoContext UmbracoContext { get; }
}
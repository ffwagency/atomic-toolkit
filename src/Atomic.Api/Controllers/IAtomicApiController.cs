using Umbraco.Cms.Core.Web;

namespace Atomic.Api.Controllers;

public interface IAtomicApiController : IDisposable
{
    IUmbracoContext UmbracoContext { get; }
}
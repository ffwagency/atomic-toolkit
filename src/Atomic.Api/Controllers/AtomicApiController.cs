using Atomic.Api.Preview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Atomic.Api.Controllers
{
    [EnablePreview]
    [SetContextCulture]
    [Authorize(Policy = PreviewAuthPolicy.Name)]
    public class AtomicApiController : UmbracoApiController, IAtomicApiController
    {
        private UmbracoContextReference? _umbracoContextReference;
        private bool _disposed;

        public IUmbracoContext UmbracoContext
        {
            get
            {
                _umbracoContextReference ??= HttpContext.RequestServices.GetRequiredService<IUmbracoContextFactory>().EnsureUmbracoContext();
                return _umbracoContextReference.UmbracoContext;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _umbracoContextReference?.Dispose();

            _disposed = true;
        }

        ~AtomicApiController()
        {
            Dispose(false);
        }
    }
}
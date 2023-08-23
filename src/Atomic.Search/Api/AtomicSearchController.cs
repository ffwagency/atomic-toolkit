using Atomic.Api.Controllers;
using Atomic.Search.Api.Models.Request;
using Atomic.Search.Api.Pipeline;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.Search.Api;

[Route(Atomic.Api.Constants.Api.BaseApiUrl)]
public class AtomicSearchController : AtomicApiController
{
    private readonly SearchApiPipeline _searchPipeline;

    public AtomicSearchController(SearchApiPipeline searchPipeline)
    {
        _searchPipeline = searchPipeline;
    }

    [HttpGet]
    [Route(Constants.SearchApiUrl)]
    public IActionResult Search([ModelBinder(BinderType = typeof(SearchRequestModelBinder))] SearchRequestModel requestModel)
    {
        var searchPipelineArgs = new SearchApiPipelineArgs(requestModel, UmbracoContext);
        _searchPipeline.Run(searchPipelineArgs);
        return this.AtomicSuccessResponse(searchPipelineArgs.SearchResponseModel);
    }
}
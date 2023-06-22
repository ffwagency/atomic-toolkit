using Atomic.Common.Backoffice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Authorization;
using Umbraco.Extensions;

namespace Atomic.Api.Auth;

public class AtomicAuthHandler : MustSatisfyRequirementAuthorizationHandler<AtomicAuthRequirement>
{
	private readonly IHttpContextAccessor _httpContextAccessor;
	private readonly IBackOfficeSecurityAccessor _backOfficeSecurity;
	private readonly IRuntimeState _runtimeState;
	private readonly AtomicApiOptions _options;

	public AtomicAuthHandler(IHttpContextAccessor httpContextAccessor,
		IBackOfficeSecurityAccessor backOfficeSecurity,
		IRuntimeState runtimeState,
		IOptions<AtomicApiOptions> options)
	{
		_httpContextAccessor = httpContextAccessor;
		_backOfficeSecurity = backOfficeSecurity;
		_runtimeState = runtimeState;
		_options = options.Value;
	}

	protected override Task<bool> IsAuthorized(AuthorizationHandlerContext context, AtomicAuthRequirement requirement)
	{
		var httpContext = _httpContextAccessor.HttpContext;

		if (_httpContextAccessor.HttpContext?.Request.IsPreviewRequest() != true)
			return IsAuthorizedForPublicApiContent(httpContext);
		else
			return IsAuthorizedForPreviewApiContent(requirement, httpContext);
    }

	private Task<bool> IsAuthorizedForPublicApiContent(HttpContext? httpContext)
	{
		if (_options.RequiresPublicApiAuthentication)
			return Task.FromResult(HasValidPublicApiTokenHeader(httpContext?.Request));
		return Task.FromResult(true);
	}

	private Task<bool> IsAuthorizedForPreviewApiContent(AtomicAuthRequirement requirement, HttpContext? httpContext)
	{
		switch (_runtimeState.Level)
		{
			case var _ when _runtimeState.EnableInstaller():
				return Task.FromResult(true);
			default:

				if (HasValidPreviewApiTokenHeader(httpContext?.Request))
					return Task.FromResult(true);

				if (!_backOfficeSecurity.BackOfficeSecurity?.IsAuthenticated() ?? false)
					return Task.FromResult(false);

				return Task.FromResult(UserApprovalSucceeded(requirement));
		}
	}

    // later we can enhance the token generation using OpenID or something. or if Umbraco provide token Auth OOB let's see
    private bool HasValidPreviewApiTokenHeader(HttpRequest? httpRequest)
	{
		if (string.IsNullOrWhiteSpace(_options.PreviewApiAuthToken))
			return false;

		var token = httpRequest?.Headers.GetValueAsString(AtomicAuthPolicy.PreviewApiAuthTokenName);

		if (string.IsNullOrWhiteSpace(token))
			return false;

		return _options.PreviewApiAuthToken.InvariantEquals(token);
	}

    // later we can enhance the token generation using OpenID or something. or if Umbraco provide token Auth OOB let's see
    private bool HasValidPublicApiTokenHeader(HttpRequest? httpRequest)
	{
		if (string.IsNullOrWhiteSpace(_options.PublicApiAuthToken))
			return false;

		var token = httpRequest?.Headers.GetValueAsString(AtomicAuthPolicy.PublicApiAuthTokenName);

		if (string.IsNullOrWhiteSpace(token))
			return false;

		return _options.PublicApiAuthToken.InvariantEquals(token);
	}

	private bool UserApprovalSucceeded(AtomicAuthRequirement requirement)
	{
		return !requirement.RequireApproval
			   || (_backOfficeSecurity.BackOfficeSecurity?.CurrentUser?.IsApproved ?? false);
	}
}
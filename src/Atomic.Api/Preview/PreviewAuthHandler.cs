using Atomic.Common.Backoffice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Authorization;
using Umbraco.Extensions;

namespace Atomic.Api.Preview;

public class PreviewAuthHandler : MustSatisfyRequirementAuthorizationHandler<PreviewAuthRequirement>
{
	private readonly IHttpContextAccessor _httpContextAccessor;
	private readonly IBackOfficeSecurityAccessor _backOfficeSecurity;
	private readonly IRuntimeState _runtimeState;

	public PreviewAuthHandler(IHttpContextAccessor httpContextAccessor,
		IBackOfficeSecurityAccessor backOfficeSecurity,
		IRuntimeState runtimeState)
	{
		_httpContextAccessor = httpContextAccessor;
		_backOfficeSecurity = backOfficeSecurity;
		_runtimeState = runtimeState;
	}

	protected override Task<bool> IsAuthorized(AuthorizationHandlerContext context, PreviewAuthRequirement requirement)
	{
		if (_httpContextAccessor.HttpContext?.Request.IsPreviewRequest() != true)
			return Task.FromResult(true);

		// if not configured (install or upgrade) then we can continue
		// otherwise we need to ensure that a user is logged in

		switch (_runtimeState.Level)
		{
			case var _ when _runtimeState.EnableInstaller():
				return Task.FromResult(true);
			default:
				if (!_backOfficeSecurity.BackOfficeSecurity?.IsAuthenticated() ?? false)
				{
					return Task.FromResult(false);
				}

				var userApprovalSucceeded = !requirement.RequireApproval ||
											(_backOfficeSecurity.BackOfficeSecurity?.CurrentUser?.IsApproved ?? false);
				return Task.FromResult(userApprovalSucceeded);
		}
	}
}
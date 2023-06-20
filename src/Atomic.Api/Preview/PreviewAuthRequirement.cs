using Microsoft.AspNetCore.Authorization;

namespace Atomic.Api.Preview;

public class PreviewAuthRequirement : IAuthorizationRequirement
{
	public PreviewAuthRequirement(bool requireApproval = true) => RequireApproval = requireApproval;

	public bool RequireApproval { get; }
}
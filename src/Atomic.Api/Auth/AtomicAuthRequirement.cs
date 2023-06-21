using Microsoft.AspNetCore.Authorization;

namespace Atomic.Api.Auth;

public class AtomicAuthRequirement : IAuthorizationRequirement
{
	public AtomicAuthRequirement(bool requireApproval = true) => RequireApproval = requireApproval;

	public bool RequireApproval { get; }
}
namespace Atomic.Api.Auth;

public static class AtomicAuthPolicy
{
	public const string Name = nameof(AtomicAuthPolicy);
    public const string PreviewApiAuthTokenName = "ATOMIC_PREVIEW_API_AUTH_TOKEN";
    public const string PublicApiAuthTokenName = "ATOMIC_PUBLIC_API_AUTH_TOKEN";
    public const string EnableApiDebuggingTokenName = "ATOMIC_API_ENABLE_DEBUGGING_TOKEN";
}
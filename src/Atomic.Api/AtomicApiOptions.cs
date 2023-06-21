using Atomic.Common.Configuration;
using System.Text.Json.Serialization;

namespace Atomic.Api;

[AtomicOptions(Constants.AtomicApiOptionsConfigurationKey)]
public class AtomicApiOptions
{
	public string? PreviewApiAuthToken { get; set; }

	public string? PublicApiAuthToken { get; set; }

	[JsonIgnore]
	public bool RequiresPublicApiAuthentication => !string.IsNullOrWhiteSpace(PublicApiAuthToken);
}
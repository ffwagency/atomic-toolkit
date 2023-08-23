using Atomic.Common.Configuration;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Atomic.Api;

[AtomicOptions(Constants.Configuration.AtomicApiOptionsKey)]
public class AtomicApiOptions
{
    public string? PreviewApiAuthToken { get; set; }

    public string? PublicApiAuthToken { get; set; }

    public string? EnableApiDebuggingToken { get; set; }

    [DefaultValue(new[] { "culture", "language", "locale" })]
    public string[] ApiParamsAffectingContextCulture { get; set; } = new[] { "culture", "language", "locale" };

    [JsonIgnore]
	public bool RequiresPublicApiAuthentication => !string.IsNullOrWhiteSpace(PublicApiAuthToken);
}
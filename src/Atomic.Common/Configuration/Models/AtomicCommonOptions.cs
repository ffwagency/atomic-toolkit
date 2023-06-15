using Atomic.Common.Configuration.Attributes;
using System.ComponentModel;

namespace Atomic.Common.Configuration.Models;

[AtomicOptions(Constants.AtomicCommonOptionsConfigurationKey)]
public class AtomicCommonOptions
{
	[DefaultValue("Shared Content")]
	public string WebsiteSharedContentRootName { get; set; } = "Shared Content";


	[DefaultValue("Settings")]
	public string WebsiteSettingsRootName { get; set; } = "Settings";

	[DefaultValue(new[] { "culture", "language", "locale" })]
	public string[] ApiParamsAffectingContextCulture { get; set; } = new[] { "culture", "language", "locale" };
}
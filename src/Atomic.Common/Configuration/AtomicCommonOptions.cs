using System.ComponentModel;

namespace Atomic.Common.Configuration;

[AtomicOptions(Constants.AtomicCommonOptionsConfigurationKey)]
public class AtomicCommonOptions
{
    [DefaultValue("Shared Content")]
    public string WebsiteSharedContentRootName { get; set; } = "Shared Content";


    [DefaultValue("Settings")]
    public string WebsiteSettingsRootName { get; set; } = "Settings";
}
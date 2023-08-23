using System.ComponentModel;

namespace Atomic.Common.Configuration;

[AtomicOptions(Constants.AtomicCommonOptionsConfigurationKey)]
public class AtomicCommonOptions
{
    public AtomicCommonOptions()
    {
        MediaOptions = new MediaOptions();
    }

    [DefaultValue("Shared Content")]
    public string WebsiteSharedContentRootName { get; set; } = "Shared Content";


    [DefaultValue("Settings")]
    public string WebsiteSettingsRootName { get; set; } = "Settings";

    public MediaOptions MediaOptions { get; set; }
}

public class MediaOptions
{
    [DefaultValue(95)]
    public int DefaultImageQuality { get; set; } = 95;

    [DefaultValue(true)]
    public bool ConvertToWebP { get; set; } = true;
}
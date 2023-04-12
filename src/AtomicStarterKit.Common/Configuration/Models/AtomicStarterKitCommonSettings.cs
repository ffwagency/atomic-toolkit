using AtomicStarterKit.Common.Configuration.Attributes;
using System.ComponentModel;

namespace AtomicStarterKit.Common.Configuration.Models;

[AtomicStarterKitOptions(Constants.Configuration.ConfigCommon)]
public class AtomicStarterKitCommonSettings
{
    internal const string WebsiteSharedContentRootDefaultName = "Shared Content";
    internal const string WebsiteSettingsRootDefaultName = "Settings";


    [DefaultValue(WebsiteSharedContentRootDefaultName)]
    public string WebsiteSharedContentRootName { get; set; } = WebsiteSharedContentRootDefaultName;


    [DefaultValue(WebsiteSettingsRootDefaultName)]
    public string WebsiteSettingsRootName { get; set; } = WebsiteSettingsRootDefaultName;
}
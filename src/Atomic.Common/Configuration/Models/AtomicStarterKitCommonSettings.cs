using Atomic.Common.Configuration.Attributes;
using System.ComponentModel;

namespace Atomic.Common.Configuration.Models;

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
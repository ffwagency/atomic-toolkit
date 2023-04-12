namespace AtomicStarterKit.Common.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class AtomicStarterKitOptionsAttribute : Attribute
{
    public AtomicStarterKitOptionsAttribute(string configurationKey) => ConfigurationKey = configurationKey;

    public string ConfigurationKey { get; }

    public bool BindNonPublicProperties { get; set; }
}
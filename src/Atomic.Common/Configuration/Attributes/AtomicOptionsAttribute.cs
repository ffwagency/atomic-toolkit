namespace Atomic.Common.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class AtomicOptionsAttribute : Attribute
{
	public AtomicOptionsAttribute(string configurationKey) => ConfigurationKey = configurationKey;

	public string ConfigurationKey { get; }

	public bool BindNonPublicProperties { get; set; }
}
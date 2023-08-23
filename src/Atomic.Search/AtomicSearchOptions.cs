using Atomic.Common.Configuration;
using System.ComponentModel;

namespace Atomic.Search;

[AtomicOptions(Constants.AtomicSearchOptionsConfigurationKey)]
public class AtomicSearchOptions
{
    [DefaultValue(true)]
    public bool Enabled { get; set; } = true;
}
namespace Atomic.Common.Multilanguage;

public sealed class ContextCultureSwitcher : IDisposable
{
	private readonly CulturesService _culturesService;

	public ContextCultureSwitcher(string culture, CulturesService culturesService)
	{
		_culturesService = culturesService;
		_culturesService.PushContextCulture(culture);
	}

	public void Dispose()
	{
		_culturesService.PopContextCulture();
	}
}
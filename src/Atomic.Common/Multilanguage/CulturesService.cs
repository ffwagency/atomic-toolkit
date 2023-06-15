using System.Globalization;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;

namespace Atomic.Common.Multilanguage;

public class CulturesService
{
	private CultureInfo? _prevCulture;
	private CultureInfo? _prevUICulture;
	private VariationContext? _prevVariationContext;

	private readonly IVariationContextAccessor _variationContextAccessor;
	private readonly ILocalizationService _localizationService;

	public CulturesService(IVariationContextAccessor variationContextAccessor,
		ILocalizationService localizationService)
	{
		_variationContextAccessor = variationContextAccessor;
		_localizationService = localizationService;
	}

	public ContextCultureSwitcher SwitchContextCulture(string culture) => new(culture, this);

	public void PushContextCulture(string culture)
	{
		InvalidUmbracoCultureException.ThrowIfCultureIsNotSupported(culture, _localizationService);

		_prevVariationContext = _variationContextAccessor.VariationContext;
		_prevCulture = Thread.CurrentThread.CurrentCulture;
		_prevUICulture = Thread.CurrentThread.CurrentUICulture;

		_variationContextAccessor.VariationContext = new VariationContext(culture);
		var newCultureInfo = new CultureInfo(culture);
		Thread.CurrentThread.CurrentCulture = newCultureInfo;
		Thread.CurrentThread.CurrentUICulture = newCultureInfo;
	}

	public void PopContextCulture()
	{
		_variationContextAccessor.VariationContext = _prevVariationContext ?? _variationContextAccessor.VariationContext;
		Thread.CurrentThread.CurrentCulture = _prevCulture ?? Thread.CurrentThread.CurrentCulture;
		Thread.CurrentThread.CurrentUICulture = _prevUICulture ?? Thread.CurrentThread.CurrentUICulture;
	}
}
using Umbraco.Cms.Core.Services;

namespace Atomic.Common.Multilanguage;

public class InvalidUmbracoCultureException : Exception
{
	public InvalidUmbracoCultureException()
	{ }

	public InvalidUmbracoCultureException(string? message) : base(message)
	{ }

	public InvalidUmbracoCultureException(string? message, Exception? innerException) : base(message, innerException)
	{ }

	public static void ThrowIfCultureIsNotSupported(string? culture, ILocalizationService localizationService)
	{
		var umbracoLanguage = localizationService.GetLanguageByIsoCode(culture);
		if (umbracoLanguage == null)
			throw new InvalidUmbracoCultureException($"'{culture}' is not a culture which the configured Umbraco languages currently support.");
	}
}
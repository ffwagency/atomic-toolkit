using System.ComponentModel.DataAnnotations;

namespace Atomic.StarterKit.Models;

public class ContactFormViewModel
{
	public ContactFormViewModel()
	{
		Name = string.Empty;
		Email = string.Empty;
		Message = string.Empty;
	}

	public string Name { get; set; }

	public string Email { get; set; }

	[Required]
	public string Message { get; set; }
}
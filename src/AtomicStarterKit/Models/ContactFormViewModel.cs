using System.ComponentModel.DataAnnotations;

namespace AtomicStarterKit.Models
{
    public class ContactFormViewModel
    {
        public ContactFormViewModel()
        {
            Message = string.Empty;
        }
        public string Name { get; set; }
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}

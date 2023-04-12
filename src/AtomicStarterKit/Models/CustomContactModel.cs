using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Models;

// TODO: Discuss maybe remove Custom from name
public class CustomContactModel
{
    public Contact Contact { get; set; }
    public ContactFormViewModel ContactFormModel { get; set; }
}

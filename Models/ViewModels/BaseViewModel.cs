using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace ContentManagementSystem.Models.ViewModels
{
  public abstract class BaseViewModel : ContentModel
  {
    protected BaseViewModel(IPublishedContent content) : base(content) { }

    public string PageTitle => Content.Value<string>("pageTitle") ?? Content.Name;
  }
}

using ContentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace ContentManagementSystem.Controllers
{
  /// <summary>
  /// Controller for the Home Page. 
  /// Handles the "Route Hijacking" to provide a custom ViewModel and search logic.
  /// </summary>
  public class HomePageController : RenderController
  {
    public HomePageController(
            ILogger<HomePageController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor) 
      : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
    }

    public override IActionResult Index()
    {
      var query = Request.Query["query"].ToString();

      var model = new HomeViewModel(CurrentPage!)
      {
        SearchQuery = query,
        SearchResults = CurrentPage!.Children
                          .Where(x => x.ContentType.Alias == "article" &&
                                 (string.IsNullOrEmpty(query) || x.Name.Contains(query, StringComparison.OrdinalIgnoreCase)))
                          ?? Enumerable.Empty<IPublishedContent>()

      };

      return CurrentTemplate(model);
    }
  }
}

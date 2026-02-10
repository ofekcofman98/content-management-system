using ContentManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MimeKit.Cryptography;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using ContentManagementSystem.Models;

namespace ContentManagementSystem.Controllers
{
  public class HomePageController : RenderController
  {
    private readonly IPublishedValueFallback _fallback;

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
      };

      return CurrentTemplate(model);
    }
  }
}

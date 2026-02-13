using ContentManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace ContentManagementSystem.Controllers
{
  /// <summary>
  /// Controller for the Article Document Type.
  /// Maps the IPublishedContent to a strongly-typed ArticleViewModel.
  /// </summary>
  public class ArticleController : RenderController
  {
    public ArticleController(
                ILogger<ArticleController> logger,
                ICompositeViewEngine compositeViewEngine,
                IUmbracoContextAccessor umbracoContextAccessor)
                : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
    }

    public override IActionResult Index()
    {
      if (CurrentPage == null)
      {
        return NotFound();
      }

      var viewModel = new ArticleViewModel(CurrentPage);

      return CurrentTemplate(viewModel);
    }
  }
}

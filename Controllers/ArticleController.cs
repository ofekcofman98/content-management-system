using ContentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace ContentManagementSystem.Controllers
{
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
      var viewModel = new ArticleViewModel(CurrentPage!);

      return CurrentTemplate(viewModel);
    }
  }
}

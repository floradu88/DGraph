using System.Linq;
using System.Web.Mvc;
using DGraph.Core.Repository;
using DGraph.Web.Models;

namespace DGraph.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IDependencyRepository _dependencyRepository;

        public SearchController(IDependencyRepository dependencyRepository)
        {
            _dependencyRepository = dependencyRepository;
        }

        // GET: Search
        public ActionResult Index()
        {
            return View(new SearchResultModel());
        }

        public ActionResult Search(SearchViewModel model)
        {
            var dependencies = _dependencyRepository.SearchDependecies();

            SearchResultModel result = new SearchResultModel() { Results = dependencies.ToList(), Search = model, Page = model.Page, Rows = model.Rows, TotalPages = 10 };
            return View("Index", result);
        }
    }
}
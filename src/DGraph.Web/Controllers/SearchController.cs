using System.Linq;
using System.Web.Mvc;
using DGraph.Core.Repository;

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
            return View();
        }

        public PartialViewResult Search(SearchViewModel model)
        {
            var dependencies = _dependencyRepository.SearchDependecies();

            SearchResultModel result = new SearchResultModel() { Results = dependencies.ToList(), Search = model };
            return PartialView("Search", result);
        }
    }

    public class SearchViewModel
    {
        public string Keywords { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }
        public int Rows { get; set; }

        public SearchViewModel()
        {
            Page = 1;
            Rows = 10;
        }
    }
}
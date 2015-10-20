using System.Web.Mvc;

namespace DGraph.Web.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Search(SearchViewModel model)
        {
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }

    public class SearchViewModel
    {
        public string Keywords { get; set; }
        public string Name { get; set; }
    }
}
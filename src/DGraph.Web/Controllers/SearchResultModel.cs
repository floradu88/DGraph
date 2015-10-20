using System.Collections.Generic;
using DGraph.Core.Domain;

namespace DGraph.Web.Controllers
{
    public class SearchResultModel
    {
        public IList<Dependency> Results { get; set; }
        public SearchViewModel Search { get; set; }

        public SearchResultModel()
        {
            Results = new List<Dependency>();
            Search = new SearchViewModel();
        }
    }
}

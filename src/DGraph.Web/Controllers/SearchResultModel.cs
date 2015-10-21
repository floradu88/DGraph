using System.Collections.Generic;
using DGraph.Core.Domain;
using DGraph.Web.Models;

namespace DGraph.Web.Controllers
{
    public class SearchResultModel
    {
        public IList<Dependency> Results { get; set; }
        public SearchViewModel Search { get; set; }
        public int Page { get; set; }
        public int Rows { get; set; }

        public SearchResultModel()
        {
            Results = new List<Dependency>();
            Search = new SearchViewModel();
            Page = 1;
            Rows = 10;
        }
    }
}

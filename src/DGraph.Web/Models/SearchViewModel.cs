namespace DGraph.Web.Models
{
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
using IisConfiguration.Configuration;

namespace DGraph.Config
{
    public class WebConfiguration : EnvironmentalConfig
    {
        public string SiteName
        {
            get
            {
                return "DGraph";
            }
        }

        public int PortNumber
        {
            get
            {
                return 1405;
            }
        }
    }
}

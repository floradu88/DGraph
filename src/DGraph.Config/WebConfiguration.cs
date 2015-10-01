using IisConfiguration.Configuration;

namespace DGraph.Core.Configuration
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
                return 410;
            }
        }
    }
}

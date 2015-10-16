using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace DGraph.Core.Configuration
{
    public class Configuration : IConfiguration
    {
        private readonly NameValueCollection _config;

        public Configuration()
            : this(ConfigurationManager.AppSettings)
        {
        }

        public Configuration(NameValueCollection config)
        {
            _config = config;
            if (_config == null)
            {
                throw new ArgumentNullException("config");
            }
            Initialize();
        }

        public void Initialize()
        {
            var applications = _config["applications"];
            var applicationFilePaths = _config["applicationFilePaths"];
            var includedEntries = _config["includedEntries"];
            var excludedEntries = _config["excludedEntries"];

            if (string.IsNullOrEmpty(applications))
                throw new InvalidOperationException("Oops! You have no applications defined. Add them to the web.config using <add key=\"applications\" value=\"app1,app2\" />");
            if (string.IsNullOrEmpty(applicationFilePaths))
                throw new InvalidOperationException(@"Oops! You have no servers defined. Add them to the web.config using <add key=""applicationFilePaths"" value=""\\localhost\d$\logs1,\\serverWithLongName.domain.com\Logs"" />");

            Applications = applications.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            ApplicationFilePaths = applicationFilePaths.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (!string.IsNullOrEmpty(includedEntries))
                IncludedTypes = includedEntries.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (!string.IsNullOrEmpty(excludedEntries))
                ExcludedTypes = excludedEntries.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public IList<string> Applications { get; private set; }

        public IList<string> ApplicationFilePaths { get; private set; }

        public IList<string> IncludedTypes { get; private set; }

        public IList<string> ExcludedTypes { get; private set; }
    }
}

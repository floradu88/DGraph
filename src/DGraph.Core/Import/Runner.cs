using CommandLine;
using DGraph.Core.Configuration;
using DGraph.Core.Repository;
using MongoDB.Driver;

namespace DGraph.Core.Import
{

    public class Runner
    {
        private readonly IDependencyRepository _repository;
        private readonly IConfiguration _configuration;

        public Runner()
            : this(new Configuration.Configuration(), new DependencyRepository(new MongoClient(), new Configuration.Configuration()))
        {
        }

        internal Runner(IConfiguration configuration, IDependencyRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
            _configuration.Initialize();
        }

        public string Run(string[] args)
        {
            var options = new Options();
            bool result = Parser.Default.ParseArguments(args, options);

            if (result == false)
            {
                // Display the default usage information
                return options.GetUsage();
            }
            else
            {
                if (options.WipeData)
                {
                    _repository.DeleteAll();
                }

                if (!string.IsNullOrEmpty(options.RootPath))
                {
                    //var logReader = new FileSystemLogReader(_configuration);
                    //var containerList = new List<ServerLogFileContainer>();

                    return "imported folder " + options.RootPath;
                }

                return "done";
            }
        }
    }
}

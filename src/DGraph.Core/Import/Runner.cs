using System;
using System.Linq;
using CommandLine;
using DGraph.Core.Configuration;
using DGraph.Core.Domain;
using DGraph.Core.IO;
using DGraph.Core.Repository;
using MongoDB.Driver;

namespace DGraph.Core.Import
{

    public class Runner
    {
        private readonly IConfiguration _configuration;
        private readonly IDependencyRepository _repository;
        private readonly ISearchFileManager _searchFileManager;

        public Runner()
        {
            _configuration = new Configuration.Configuration();
            _repository = new DependencyRepository(new MongoClient(), new Configuration.Configuration());
            _searchFileManager = new SearchFileManager(_configuration);
        }

        public Runner(IConfiguration configuration, IDependencyRepository repository, ISearchFileManager searchFileManager)
            : this()
        {
            _configuration = configuration;
            _repository = repository;
            _searchFileManager = searchFileManager;
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
                    var files = _searchFileManager.Search(true);

                    foreach (var file in files)
                    {
                        var dependencyExtractor = new PackageConfigDependencyExtractor(file);
                        _repository.BulkSave(dependencyExtractor.Dependencies());
#if DEBUG
                        Console.WriteLine("Extracted dependencies from file: {0}", file);
#endif
                    }

                    return "imported folder " + options.RootPath;
                }

                return "done";
            }
        }

        private DependencyEnum GetDependencyType(string entry)
        {
            if (string.IsNullOrEmpty(entry))
                return DependencyEnum.None;

            entry = entry.ToLower();

            if (entry.EndsWith("package.config"))
            {
                return DependencyEnum.Nuget;
            }

            return DependencyEnum.None;
        }
    }
}

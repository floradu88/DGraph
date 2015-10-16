using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DGraph.Core.IO
{
    public class SearchFileManager : ISearchFileManager
    {
        public const string AllPattern = "*.*";

        private readonly Configuration.IConfiguration configuration;

        public SearchFileManager(Configuration.IConfiguration configuration)
        {
            this.configuration = configuration;

            this.configuration.Initialize();
        }

        public List<string> Search(bool recursive = false)
        {
            IList<string> patterns = new List<string> { AllPattern };

            if (configuration.IncludedTypes.Any())
            {
                patterns = configuration.IncludedTypes;
            }

            List<string> results = new List<string>();

            foreach (var path in configuration.ApplicationFilePaths)
            {
                if (Directory.Exists(path))
                {
                    var files = GetFiles(path, patterns,
                        !recursive ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories);

                    results.AddRange(files);
                }
            }

            return results;
        }

        // Takes same patterns, and executes in parallel
        private static IEnumerable<string> GetFiles(string path,
                            IList<string> searchPatterns,
                            SearchOption searchOption = SearchOption.AllDirectories)
        {
            return searchPatterns.AsParallel()
                   .SelectMany(searchPattern =>
                          Directory.EnumerateFiles(path, searchPattern, searchOption));
        }
    }
}

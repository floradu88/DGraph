using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DGraph.Core.IO
{
    public class SearchFileManager : ISearchFileManager
    {
        public const string AllPattern = "*.*";

        public readonly Configuration.IConfiguration Configuration;

        public SearchFileManager(Configuration.IConfiguration configuration)
        {
            this.Configuration = configuration;

            this.Configuration.Initialize();
        }

        public List<string> Search(bool recursive = false)
        {
            IList<string> patterns = new List<string> { AllPattern };

            if (Configuration.IncludedTypes.Any())
            {
                patterns = Configuration.IncludedTypes;
            }

            List<string> results = new List<string>();

            foreach (var path in Configuration.ApplicationFilePaths)
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

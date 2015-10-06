using System.Collections.Generic;

namespace DGraph.Core.Configuration
{
    public interface IConfiguration
    {
        IList<string> Applications { get; }
        IList<string> ApplicationFilePaths { get; }
        IList<string> IncludedTypes { get; }
        IList<string> ExcludedTypes { get; }

        void Initialize();
    }
}

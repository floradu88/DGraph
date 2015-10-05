using System;

namespace DGraph.Core.Domain
{
    public class Dependency
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }

        public string SourcePath { get; set; }

        public string ApplicationName { get; set; }

        public DependencyEnum Type { get; set; }
    }
}



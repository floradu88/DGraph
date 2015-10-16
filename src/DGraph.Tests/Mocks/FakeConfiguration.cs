using System;
using System.Collections.Generic;
using System.Linq;
using DGraph.Core.Configuration;

namespace DGraph.Tests.Mocks
{
    class FakeConfiguration : IConfiguration
    {
        private readonly string _path;
        private readonly List<string> _includedFiles;

        public FakeConfiguration(string path = null, string includedFiles = "*.*")
        {
            this._path = path;
            this._includedFiles = includedFiles.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public IList<string> Applications
        {
            get
            {
                return new List<string>() { "app1" };
            }
        }
        public IList<string> ApplicationFilePaths
        {
            get
            {
                return new List<string>() { _path };
            }
        }

        public IList<string> IncludedTypes
        {
            get
            {
                return _includedFiles;
            }
        }

        public IList<string> ExcludedTypes { get; private set; }

        public void Initialize()
        {
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using DGraph.Core.Configuration;
using DGraph.Core.IO;
using DGraph.Tests.Mocks;
using NUnit.Framework;

namespace DGraph.Tests.Integration
{
    [TestFixture]
    public class SearchFileManagerTests
    {
        [Test]
        public void should_search_all_files_in_a_specific_folder()
        {
            IConfiguration configuration = new FakeConfiguration("c:\\code2");
            ISearchFileManager searchFileManager = new SearchFileManager(configuration);

            List<string> files = searchFileManager.Search();

            Assert.That(files, Is.Empty);
        }

        [Test]
        public void should_search_all_files_in_a_specific_folder_recursively()
        {
            IConfiguration configuration = new FakeConfiguration("c:\\code");
            ISearchFileManager searchFileManager = new SearchFileManager(configuration);

            List<string> files = searchFileManager.Search(true);

            Assert.That(files, Is.Not.Empty);
        }

        [Test]
        public void should_search_included_files_in_a_specific_folder_recursively()
        {
            IConfiguration configuration = new FakeConfiguration("c:\\code", "*.cs");
            ISearchFileManager searchFileManager = new SearchFileManager(configuration);

            List<string> files = searchFileManager.Search(true);

            Assert.That(files, Is.Not.Empty);
            Assert.IsTrue(files.All(x => x.EndsWith(".cs")));
        }
    }
}

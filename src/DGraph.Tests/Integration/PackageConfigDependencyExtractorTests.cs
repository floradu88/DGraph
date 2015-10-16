using DGraph.Core.Domain;
using DGraph.Core.IO;
using NUnit.Framework;
using System.Collections.Generic;

namespace DGraph.Tests.Integration
{
    [TestFixture]
    public class PackageConfigDependencyExtractorTests
    {
        [Test]
        public void should_extract_dependencies_from_an_existing_package_config()
        {
            IDependencyExtractor dependencyExtractor = new PackageConfigDependencyExtractor(@"C:\pathToAConfigFile\packages.config");

            IList<Dependency> dependencies = dependencyExtractor.Dependencies();

            Assert.That(dependencies, Is.Not.Null);
            Assert.That(dependencies, Is.Not.Empty);
        }
    }
}

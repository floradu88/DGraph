using DGraph.Core.Configuration;
using DGraph.Core.Domain;
using DGraph.Core.Repository;
using MongoDB.Driver;
using NUnit.Framework;
using System;
using System.Threading;

namespace DGraph.Tests.Integration
{
    [TestFixture]
    public class DependencyRepositoryTests
    {
        private IDependencyRepository _dependencyRepository;
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            _configuration = new Configuration();
            _dependencyRepository = new DependencyRepository(new MongoClient(), _configuration, "DGraph-tests");
            _dependencyRepository.DeleteAll();
        }

        [Test]
        public void should_retrieve_no_dependencies_from_empty_database()
        {
            //assert
            var dependencies = _dependencyRepository.SearchDependecies();

            //act
            Assert.That(dependencies, Is.Empty);
        }

        [Test]
        public void should_retrieve_all_added_entries_from_database()
        {
            const string applicationName = "someApplication";
            const string sourcePath = "someAppPathFromFileSystem";

            _dependencyRepository.Save(new Dependency() { ApplicationName = applicationName, DateTime = DateTime.Now, Id = Guid.NewGuid(), SourcePath = sourcePath, Type = DependencyEnum.Project });
            Thread.Sleep(1000);

            //assert
            var dependencies = _dependencyRepository.SearchDependecies();

            //act
            Assert.That(dependencies, Is.Not.Empty);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DGraph.Core.Configuration;
using DGraph.Core.Domain;
using DGraph.Core.Repository;
using MongoDB.Driver;
using NUnit.Framework;

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
            Assert.That(dependencies.ToList().Count, Is.EqualTo(1));
        }

        [Test]
        public void should_retrieve_all_added_entries_from_database_created_using_bulk_save()
        {
            const string applicationName = "someApplication";
            const string sourcePath = "someAppPathFromFileSystem";

            var entryList = new List<Dependency>();
            entryList.Add(new Dependency() { ApplicationName = applicationName, DateTime = DateTime.Now, Id = Guid.NewGuid(), SourcePath = sourcePath, Type = DependencyEnum.Project });
            entryList.Add(new Dependency() { ApplicationName = applicationName, DateTime = DateTime.Now, Id = Guid.NewGuid(), SourcePath = sourcePath, Type = DependencyEnum.Project });
            entryList.Add(new Dependency() { ApplicationName = applicationName, DateTime = DateTime.Now, Id = Guid.NewGuid(), SourcePath = sourcePath, Type = DependencyEnum.Project });
            entryList.Add(new Dependency() { ApplicationName = applicationName, DateTime = DateTime.Now, Id = Guid.NewGuid(), SourcePath = sourcePath, Type = DependencyEnum.Project });
            entryList.Add(new Dependency() { ApplicationName = applicationName, DateTime = DateTime.Now, Id = Guid.NewGuid(), SourcePath = sourcePath, Type = DependencyEnum.Project });

            _dependencyRepository.BulkSave(entryList);
            Thread.Sleep(1000);

            //assert
            var dependencies = _dependencyRepository.SearchDependecies();

            //act
            Assert.That(dependencies, Is.Not.Empty);
            Assert.That(dependencies.ToList().Count, Is.EqualTo(5));
        }

        [Test]
        public void should_retrieve_no_dependencies_from_dropped_database()
        {
            const string applicationName = "someApplication";
            const string sourcePath = "someAppPathFromFileSystem";

            _dependencyRepository.Save(new Dependency() { ApplicationName = applicationName, DateTime = DateTime.Now, Id = Guid.NewGuid(), SourcePath = sourcePath, Type = DependencyEnum.Project });
            Thread.Sleep(1000);

            //assert
            var dependencies = _dependencyRepository.SearchDependecies();

            //act
            Assert.That(dependencies, Is.Not.Empty);

            _dependencyRepository.DeleteCollection();

            dependencies = _dependencyRepository.SearchDependecies();

            //act
            Assert.That(dependencies, Is.Not.Empty);
        }
    }
}

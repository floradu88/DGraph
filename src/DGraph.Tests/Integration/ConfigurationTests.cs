using System.Collections.Generic;
using DGraph.Core.Configuration;
using NUnit.Framework;

namespace DGraph.Tests.Integration
{
    [TestFixture]
    public class ConfigurationTests
    {
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            _configuration = new Configuration();
            _configuration.Initialize();
        }

        [Test]
        public void should_test_that_configuration_values_are_loaded_from_app_config()
        {
            //arrange
            var applicationList = new List<string>() { "app1", "app2" };
            var applicationFilePaths = new List<string>() { @"\\localhost\d$\logs1", @"\\serverWithLongName.domain.com\Logs" };
            var includedTypes = new List<string>() { "*.*" };
            var excludedTypes = new List<string>() { "bin", "obj" };

            //act

            //assert
            Assert.That(_configuration.Applications, Is.EqualTo(applicationList));
            Assert.That(_configuration.ApplicationFilePaths, Is.EqualTo(applicationFilePaths));
            Assert.That(_configuration.IncludedTypes, Is.EqualTo(includedTypes));
            Assert.That(_configuration.ExcludedTypes, Is.EqualTo(excludedTypes));
        }
    }
}

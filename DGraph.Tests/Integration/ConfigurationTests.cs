using System.Collections.Generic;
using DGraph.Core.Configuration;
using NUnit.Framework;

namespace DGraph.Tests.Integration
{
    public class ConfigurationTests
    {
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            _configuration = new Configuration();
        }

        [Test]
        public void should_test_that_configuration_values_are_loaded_from_app_config()
        {
            //arrange
            var applicationList = new List<string>() { "app1", "app2" };
            var applicationFilePaths = new List<string>() { @"\\localhost\d$\logs1", @"\\serverWithLongName.domain.com\Logs" };

            //act

            //assert
            Assert.That(_configuration.Applications, Is.EqualTo(applicationList));
            Assert.That(_configuration.ApplicationFilePaths, Is.EqualTo(applicationFilePaths));
        }
    }
}

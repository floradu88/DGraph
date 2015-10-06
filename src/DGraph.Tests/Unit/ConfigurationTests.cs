using DGraph.Core.Configuration;
using DGraph.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Specialized;

namespace DGraph.Tests.Unit
{
    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void should_throw_exception_for_empty_configuration()
        {
            Assert.Throws<InvalidOperationException>(() => new FakeEmptyConfiguration().Initialize());
        }

        [Test]
        public void should_throw_exception_for_null_configuration()
        {
            Assert.Throws<ArgumentNullException>(() => new Configuration(null).Initialize());
        }

        [Test]
        public void should_throw_exception_for_missing_applications_in_configuration()
        {
            var appSettings = new NameValueCollection();
            appSettings["applications"] = null;

            Assert.Throws<InvalidOperationException>(() => new Configuration(appSettings).Initialize());
        }

        [Test]
        public void should_throw_exception_for_missing_application_paths_in_configuration()
        {
            var appSettings = new NameValueCollection();
            appSettings["applications"] = "app1";
            appSettings["applicationFilePaths"] = null;

            Assert.Throws<InvalidOperationException>(() => new Configuration(appSettings).Initialize());
        }
    }
}

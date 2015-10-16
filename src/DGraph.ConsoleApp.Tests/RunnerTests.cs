using DGraph.Core.Import;
using NUnit.Framework;

namespace DGraph.ConsoleApp.Tests
{
    [TestFixture]
    public class RunnerTests
    {
        [Test]
        public void should_pass_all_arguments_to_runner()
        {
            var args = new string[]
            {
                "--path=c:\\code",
                "--wipedata",
                "--smartupdate"
            };

            Runner runner = new Runner();
            Assert.That(runner.Run(args), Is.EqualTo("imported folder c:\\code"));
        }

        [Test]
        public void should_pass_help_argument_to_runner()
        {
            var args = new string[]
            {
                "--help"
            };

            Runner runner = new Runner();
            Assert.That(runner.Run(args), Is.Not.EqualTo("done"));
        }
    }
}

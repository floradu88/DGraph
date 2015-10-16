using NUnit.Framework;

namespace DGraph.ConsoleApp.Tests
{
    [TestFixture]
    public class ConsoleAppTests
    {
        [Test]
        public void should_scan_folder_for_files()
        {
            var args = new string[]
            {
                "p",
                "w",
                "u"
            };

            Program.Main(args);
        }
    }
}

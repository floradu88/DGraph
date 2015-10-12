using System.Collections.Specialized;
using DGraph.Core.Configuration;

namespace DGraph.Tests.Mocks
{
    internal class FakeEmptyConfiguration : Configuration, IConfiguration
    {
        public FakeEmptyConfiguration() :
            base(new NameValueCollection())
        { }
    }
}

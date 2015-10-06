using DGraph.Core.Configuration;
using System.Collections.Specialized;

namespace DGraph.Tests.Mocks
{
    internal class FakeEmptyConfiguration : Configuration, IConfiguration
    {
        public FakeEmptyConfiguration() :
            base(new NameValueCollection())
        {

        }
    }
}

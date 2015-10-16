namespace DGraph.Core.IO
{
    public interface IDependencyExtractor
    {
        System.Collections.Generic.IList<Domain.Dependency> Dependencies();
    }
}

using System.Collections.Generic;
namespace DGraph.Core.IO
{
    public interface ISearchFileManager
    {
        List<string> Search(bool recursive = false);
    }
}

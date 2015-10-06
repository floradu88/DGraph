using DGraph.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace DGraph.Core.Repository
{
    public interface IDependencyRepository
    {
        IQueryable<Dependency> SearchDependecies();
        
        void Save(Dependency entry);

        void DeleteAll();

        void BulkSave(IEnumerable<Dependency> entries);

        void DeleteCollection();
    }
}

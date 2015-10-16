using System.Collections.Generic;
using System.Linq;
using DGraph.Core.Domain;

namespace DGraph.Core.Repository
{
    public interface IDependencyRepository
    {
        IQueryable<Dependency> SearchDependecies();
        
        void Save(Dependency entry);

        void DeleteAll();

        void BulkSave(IEnumerable<Dependency> entries);

        void DropDatabase();
    }
}

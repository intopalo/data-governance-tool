using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class CollectionsRepository : Repository<Collection>, ICollectionsRepository
    {
        public CollectionsRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}

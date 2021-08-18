using DemoRepoAPi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepoAPi.InfraStructure.Data
{
    public class UnitofWork : IUnitOfWork
    {
        private readonly EmployeeDbContext _dbContext;

        public UnitofWork(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private int AffectedRows { get; set; }
        public int Commit()
        {
            AffectedRows = _dbContext.SaveChanges();
            return AffectedRows;
        }

        public async  Task<int> CommitAsync()
        {
            AffectedRows= await _dbContext.SaveChangesAsync();
            return AffectedRows;
        }
    }
}

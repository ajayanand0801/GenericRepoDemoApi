using DemoRepoAPi.Domain.Entities;
using DemoRepoAPi.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepoAPi.InfraStructure.Data.Repositories
{
    public class EmployeeRepository:RepositoryBase<Employee>,IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

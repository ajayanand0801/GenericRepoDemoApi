using DemoRepoAPi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DemoRepoAPi.InfraStructure.Data
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly EmployeeDbContext _dbcontext;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(EmployeeDbContext dbContext)
        {
            _dbcontext = dbContext;
            _dbSet = _dbcontext.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
             await _dbcontext.AddAsync(entity);
            return true;
            
        }

        public Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

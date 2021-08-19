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
             await _dbSet.AddAsync(entity);
            return true;
            
        }

        public Task<IEnumerable<T>> All()
        {
            var data = _dbSet.ToList();
           return  Task.FromResult(data.AsEnumerable());
        }

        public Task<bool> Delete(Guid id)
        {
            var result = _dbSet.Find(id.ToString());
            if (result==null)
                return Task.FromResult(false);

            _dbSet.Remove(result);

            return Task.FromResult(true);

        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            //var result = _dbcontext.Employee.Where(predicate) ;
           throw new NotImplementedException();
        }

        public   Task<T> GetById(Guid id)
        {
            var result = _dbSet.Find(id.ToString());
            return Task.FromResult(result);
           
            
        }

        public  Task<bool> Update(T entity)
        {
            var result = _dbSet.Find(entity);
            _dbSet.Update(result);
            return  Task.FromResult(true);
           
        }
    }
}

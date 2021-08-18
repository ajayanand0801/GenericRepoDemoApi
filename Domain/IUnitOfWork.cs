using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepoAPi.Domain
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}

using DemoRepoAPi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepoAPi.Domain.Repository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
    }
}

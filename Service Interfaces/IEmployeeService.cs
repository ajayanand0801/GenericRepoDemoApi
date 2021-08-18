using DemoRepoAPi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepoAPi.Service_Interfaces
{
    public interface IEmployeeService
    {
        Task<int> SaveEmployee(Employee employee);
    }
}

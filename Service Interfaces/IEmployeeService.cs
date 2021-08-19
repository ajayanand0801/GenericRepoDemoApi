using DemoRepoAPi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepoAPi.Service_Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> SaveEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(Guid id);
        Task<Employee> GetEmployeeByID(Guid id);
        Task<IEnumerable<Employee>> GetEmployees();
    }
}

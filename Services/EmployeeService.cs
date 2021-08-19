using DemoRepoAPi.Domain;
using DemoRepoAPi.Domain.Entities;
using DemoRepoAPi.Domain.Repository;
using DemoRepoAPi.Service_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRepoAPi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;

        }

        public Task<bool> DeleteEmployee(Guid id)
        {
          var isDeleted= _employeeRepository.Delete(id);
           _unitOfWork.Commit();
           return isDeleted;
        }

        public Task<Employee> GetEmployeeByID(Guid id)
        {
            var result = _employeeRepository.GetById(id);
            return result;
        }

        public async  Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.All();
        }

        public async Task<bool> SaveEmployee(Employee employee)
        {
            await _employeeRepository.Add(employee);
           int rowaffected= _unitOfWork.Commit();

            return rowaffected>0 ? true:false;
           
        }

        public async Task<bool>UpdateEmployee(Employee employee)
        {
            var result = await _employeeRepository.Find(x => x.EmpNumber == employee.EmpNumber);
            if (result == null)
                throw new ArgumentException("no record found");

            if(result.Any())
            {
                result.FirstOrDefault().FirstName = employee.FirstName;
                result.FirstOrDefault().LastName = employee.LastName;
            }
            await _employeeRepository.Update(result.FirstOrDefault());

            return true;
        }
    }
}

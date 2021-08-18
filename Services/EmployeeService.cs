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
        public async Task<int> SaveEmployee(Employee employee)
        {
            await _employeeRepository.Add(employee);
           int rowaffected= _unitOfWork.Commit();

            return rowaffected;
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoRepoAPi.Domain.Entities;
using DemoRepoAPi.Service_Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoRepoAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost,Route("")]
        public async Task<IActionResult>CreateEmployee(Employee employee)
        {
            employee.ID = Guid.NewGuid().ToString();
            employee.CreatedDate = DateTime.Now;
            employee.UpdatedDate = DateTime.Now;
            var result= await _employeeService.SaveEmployee(employee);
            string msg= result ? $"record saved successfully { employee.EmpNumber}" :"something went wrong";
            return Ok(msg);

        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetEmployee()
        {
            var result = await _employeeService.GetEmployees();
            return Ok(result);

        }
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {           
            var result = await _employeeService.GetEmployeeByID(id);
            return Ok(result);

        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var isDeleted = await _employeeService.DeleteEmployee(id);
            string msg = isDeleted ? "record deleted " : "something went wrong";
            return Ok(msg);
        }


      
    }
}

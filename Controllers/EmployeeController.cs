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
            return Ok($"record successfully saved with employeeId : {result}");

        }
    }
}

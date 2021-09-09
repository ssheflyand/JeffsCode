using EmployeesApi.Data;
using EmployeesApi.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class EmployeesController : ControllerBase
    {
        private readonly IManageEmployeeData _employeeData;

        public EmployeesController(IManageEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet("employees")]
        public async Task<ActionResult> GetAllEmployees()
        {
            GetEmployeesResponse response = await _employeeData.GetAllActiveEmployeesAsync();

            return Ok(response);
        }
    }
}

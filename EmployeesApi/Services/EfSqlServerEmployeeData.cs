using EmployeesApi.Data;
using EmployeesApi.Models.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Services
{
    public class EfSqlServerEmployeeData : IManageEmployeeData
    {
        private readonly EmployeesDataContext _context;

        public EfSqlServerEmployeeData(EmployeesDataContext context)
        {
            _context = context;
        }

        public async Task<GetEmployeesResponse> GetAllActiveEmployeesAsync()
        {
            var employees = await _context.Employees
               .Where(e => e.IsActive)
               .Select(e => new GetEmployeeResponseItem
               {
                   Id = e.Id,
                   FirstName = e.FirstName,
                   Department = e.Department,
                   LastName = e.LastName
               })
               .ToListAsync();

            var response = new GetEmployeesResponse
            {
                Data = employees
            };
            return response;
        }
    }
}

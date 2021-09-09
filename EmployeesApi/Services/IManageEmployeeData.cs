using EmployeesApi.Models.Employees;
using System.Threading.Tasks;

namespace EmployeesApi
{
    public interface IManageEmployeeData
    {
        Task<GetEmployeesResponse> GetAllActiveEmployeesAsync();
    }
}
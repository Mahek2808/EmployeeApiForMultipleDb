using EmployeeApi.Interface;
using EmployeeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace EmployeeApi.Controllers
{
    [Route("api/EmployeeController")]
    [ApiController]
    
    public class EmployeeController : Controller
    {
        private readonly IEmployee _Emp;
        public EmployeeController(IEmployee Emp)
        {
            _Emp = Emp;
        }

        [HttpGet]
        public async Task<List<TestModel>> GetAllEmployee()
        {
            return await _Emp.GetEmployees();
        }
        [HttpPost]
        public async Task<TestModel> AddEmployeeAsync(TestModel obj) 
        {
            await _Emp.AddEmployee(obj);
            return obj;
        }

        [HttpPut]
        public async Task<int> UpdateEmployeeAsync(int id,TestModel obj)
        {
            return await _Emp.UpdateEmployee(id, obj);
        }

        [HttpDelete]
        public async Task<int> DeleteEmployeeAsync(int id)
        {
            return await _Emp.DeleteEmployee(id);
        }
    }
}

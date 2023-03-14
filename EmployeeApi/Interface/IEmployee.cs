using EmployeeApi.Model;
using System.Collections.Generic;

namespace EmployeeApi.Interface
{
    public interface IEmployee
    {
        Task<List<TestModel>> GetEmployees();
        Task AddEmpoyeeContext1(TestModel obj);
        Task AddEmpoyeeContext2(TestModel obj);
        Task AddEmpoyeeContext3(TestModel obj);
        Task<TestModel> AddEmployee(TestModel obj);
        Task<int> UpdateEmployee(int id, TestModel obj);
        Task<int> UpdateEmployeeContext1(int id, TestModel obj);
        Task<int> UpdateEmployeeContext2(int id, TestModel obj);
        Task<int> UpdateEmployeeContext3(int id , TestModel obj);
        Task<int> DeleteEmployeeConetext1(int id);
        Task<int> DeleteEmployeeConetext2(int id);
        Task<int> DeleteEmployeeConetext3(int id);
        Task<int> DeleteEmployee(int id);
    }
}

using EmployeeApi.Interface;
using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Service
{
    public class EmployeeService : IEmployee
    {
        public readonly Context1 _context1;
        public readonly Context2 _context2;
        public readonly Context3 _context3;

        public EmployeeService(Context1 context1, Context2 context2, Context3 context3)
        {
            _context1 = context1;
            _context2 = context2;
            _context3 = context3;
        }

        public async Task<List<TestModel>> GetEmployees()
        {
            var response1 = _context1.Employee.ToListAsync();
            var response2 =  _context2.Employee.ToListAsync();
            var response3 = _context3.Employee.ToListAsync();
            await Task.WhenAll(response1, response2, response3);
            return response1.Result.Union(response2.Result).Union(response3.Result).ToList();
        }

        public async Task AddEmpoyeeContext1(TestModel obj)
        {
            obj.Gender = GetGender(obj.Gender);
            obj.EmployeeId = 0;
            await _context1.Employee.AddAsync(obj);
            await _context1.SaveChangesAsync();
            return;
        }

        public async Task AddEmpoyeeContext2(TestModel obj)
        {
            obj.Gender = GetGender(obj.Gender);
            obj.EmployeeId = 0;
            await _context2.Employee.AddAsync(obj);
            await _context2.SaveChangesAsync();
            return;
        }

        public async Task AddEmpoyeeContext3(TestModel obj)
        {
            obj.Gender = GetGender(obj.Gender);
            await _context3.Employee.AddAsync(obj);
            await _context3.SaveChangesAsync();
            return;
        }

        public async Task<TestModel> AddEmployee(TestModel obj)
        {
            await Task.WhenAll(AddEmpoyeeContext1(obj), AddEmpoyeeContext2(obj), AddEmpoyeeContext3(obj));
            return obj;
        }


        public static string GetGender(string gender)
        {
            switch (int.Parse(gender))
            {
                case 1:
                    return GenderEnum.Male.ToString();
                case 2:
                    return GenderEnum.Female.ToString();
                default:
                    return "UnKnown";
            }

        }

        public async Task<int> DeleteEmployeeConetext1(int id)
        {
            var emp = await _context1.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (emp != null) 
            {
                _context1.Employee.Remove(emp);
                return await _context1.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteEmployeeConetext2(int id)
        {
            var emp = await _context2.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if(emp != null)
            {
                _context2.Employee.Remove(emp);
                return await _context2.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteEmployeeConetext3(int id)
        {
            var emp = await _context3.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if(emp != null)
            {
                _context3.Employee.Remove(emp);
                return await _context3.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            await Task.WhenAll(DeleteEmployeeConetext1(id), DeleteEmployeeConetext2(id), DeleteEmployeeConetext3(id));
            return 1;
        }

        public async Task<int> UpdateEmployeeContext1(int id, TestModel obj)
        {
            var emp = await _context1.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (emp != null)
            {

                emp.FirstName = obj.FirstName;
                emp.MiddleName = obj.MiddleName;
                emp.LastName = obj.LastName;
                emp.EmpCode = obj.EmpCode;
                emp.Gender = obj.Gender;
                emp.DOB = obj.DOB;
                emp.Salary = obj.Salary;
                emp.DateOfJoining = obj.DateOfJoining;
                emp.ResignDate = obj.ResignDate;
                return await _context1.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateEmployeeContext2(int id, TestModel obj)
        {
            var emp = await _context2.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (emp != null)
            {

                emp.FirstName = obj.FirstName;
                emp.MiddleName = obj.MiddleName;
                emp.LastName = obj.LastName;
                emp.EmpCode = obj.EmpCode;
                emp.Gender = obj.Gender;
                emp.DOB = obj.DOB;
                emp.Salary = obj.Salary;
                emp.DateOfJoining = obj.DateOfJoining;
                emp.ResignDate = obj.ResignDate;
                return await _context2.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateEmployeeContext3(int id, TestModel obj)
        {
            var emp = await _context3.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (emp != null)
            {

                emp.FirstName = obj.FirstName;
                emp.MiddleName = obj.MiddleName;
                emp.LastName = obj.LastName;
                emp.EmpCode = obj.EmpCode;
                emp.Gender = obj.Gender;
                emp.DOB = obj.DOB;
                emp.Salary = obj.Salary;
                emp.DateOfJoining = obj.DateOfJoining;
                emp.ResignDate = obj.ResignDate;
                return await _context3.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateEmployee(int id, TestModel obj)
        {
            await Task.WhenAll(UpdateEmployeeContext1(id, obj), UpdateEmployeeContext2(id, obj), UpdateEmployeeContext3(id, obj));
            return 1;
        }    
    }
}

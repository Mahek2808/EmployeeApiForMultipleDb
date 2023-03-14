using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi
{
    public class Context3:DbContext
    {
        public Context3(DbContextOptions<Context3> options) : base(options)
        {

        }
        public DbSet<TestModel> Employee { get; set; }
    }
}

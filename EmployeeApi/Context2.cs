using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi
{
    public class Context2:DbContext
    {
        public Context2(DbContextOptions<Context2> options) : base(options)
        {

        }
        public DbSet<TestModel> Employee { get; set; }
    }
}

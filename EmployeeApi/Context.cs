using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi
{

    public class Context1 : DbContext
    {
        public Context1(DbContextOptions<Context1> options) : base(options){ }
        
        public DbSet<TestModel> Employee { get; set; }
        
         
    }
}

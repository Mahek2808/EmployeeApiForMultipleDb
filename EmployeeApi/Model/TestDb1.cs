using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace EmployeeApi.Model
{
    public class TestModel  
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int EmpCode { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public int Salary { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        public DateTime ResignDate { get; set; }

    }
}

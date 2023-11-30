using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Dtos
{
    public class EmployeeDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        [Range(21, 100)]
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}

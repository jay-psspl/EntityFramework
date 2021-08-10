using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFConventions.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string department { get; set; }

        //Collection Navigation Property

        public ICollection<Employee> Employees { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFConventions.Models
{
    public class Employee
    {
        public int employeeid { get; set; }
        public int empname { get; set; }

        //public Department Department { get; set; }  //one to one

        public IList<Department> Department { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int Address { get; set; }
    }
}
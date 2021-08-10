using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class DataContext :DbContext
    {
        public DataContext() : base("conn")
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
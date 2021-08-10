using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFConventions.Models
{
    public class DataContext :DbContext
    {
        public DataContext() : base("conn") 
        {
            
        }
        public DbSet<Employee> employees { get; set; }
    }
}
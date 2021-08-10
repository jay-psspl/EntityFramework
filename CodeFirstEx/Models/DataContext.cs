using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstEx.Models
{
    public class DataContext : DbContext
    {
        //Default Constructor
        public DataContext() : base("conn") { }
        public DbSet<Product> Products { get; set; }
    }
}
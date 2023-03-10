using EmployeePayroll_MVC_Ajax.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeePayroll_MVC_Ajax.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmployeeModel> PayrollDetails { get; set; }
    }
}

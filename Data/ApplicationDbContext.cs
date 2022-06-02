using Microsoft.EntityFrameworkCore;
using SICPASystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SICPASystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<EnterpriseModel> Enterprise { get; set; }
        public DbSet<DepartmentModel> Department { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<Department_EmployeeModel> Department_Employees { get; set; }
    }
}

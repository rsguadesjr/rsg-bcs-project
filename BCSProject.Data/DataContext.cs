using BCSProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProject.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<EmployeeHobby> EmployeeHobbies { get; set; }
        public DbSet<EmployeeInterest> EmployeeInterests { get; set; }
        public DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }

        public DataContext() : base("BCSProjectConnection")
        {
                
        }
    }
}

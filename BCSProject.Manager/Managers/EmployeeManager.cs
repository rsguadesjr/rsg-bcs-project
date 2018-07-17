using BCSProject.Data;
using BCSProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProject.Manager.Managers
{
    public class EmployeeManager
    {
        public List<Employee> GetEmployees(int take, int skip)
        {
            using (var db = new DataContext())
            {
                return db.Employees.Skip(skip).Take(take).ToList();
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var db = new DataContext())
            {
                return db.Employees.SingleOrDefault(x => x.Id == id);
            }
        }

        public bool AddEmployee(Employee emp)
        {
            try
            {
                using (var db = new DataContext())
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
            }
            return false;
        }

        public bool UpdateEmployee(Employee emp)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var existingEmployee = db.Employees.SingleOrDefault(x => x.Id == emp.Id);
                    if(existingEmployee != null)
                    {
                        //do the mapping here
                        db.Entry(existingEmployee).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err);
            }
            return false;
        }
    }
}

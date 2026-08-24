using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class EmployeeRepo
    {
        FoodmanagmentsystemContext db;

        public EmployeeRepo(FoodmanagmentsystemContext db)
        {
            this.db = db;
        }

        public List<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }


        public Employee GetEmployeeById(int id)
        {
            return db.Employees.Find(id);
        }

        public bool AddEmployee(Employee Employee)
        {
            db.Employees.Add(Employee);
            return db.SaveChanges() > 0;
        }

        public bool UpdateEmployee(Employee Employee)
        {
            var existingEmployee = db.Employees.Find(Employee.EmployeId);
            if (existingEmployee != null)
            {
                existingEmployee.EmployeeName = Employee.EmployeeName;
                existingEmployee.Phone = Employee.Phone;
                
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteEmployee(int id)
        {
            var Employee = db.Employees.Find(id);
            if (Employee != null)
            {
                db.Employees.Remove(Employee);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}

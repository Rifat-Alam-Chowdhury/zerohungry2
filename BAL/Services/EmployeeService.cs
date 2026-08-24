using AutoMapper;
using BAL.Model;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Services
{
    public class EmployeeService
    {
        EmployeeRepo repo;
        IMapper mapper;

        public EmployeeService(EmployeeRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }


        public List<EmployeeModel> GetAllEmployees()
        {
            var Employees = repo.GetAllEmployees();
            return mapper.Map<List<EmployeeModel>>(Employees);
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            var Employee = repo.GetEmployeeById(id);
            return mapper.Map<EmployeeModel>(Employee);
        }

        public bool AddEmployee(EmployeeModel EmployeeModel)
        {
            var Employee = mapper.Map<DAL.EF.Tables.Employee>(EmployeeModel);
            return repo.AddEmployee(Employee);
        }

        public bool UpdateEmployee(EmployeeModel EmployeeModel)
        {
            var Employee = mapper.Map<DAL.EF.Tables.Employee>(EmployeeModel);
            return repo.UpdateEmployee(Employee);
        }

        public bool DeleteEmployee(int id)
        {
            return repo.DeleteEmployee(id);

        }
    }
}

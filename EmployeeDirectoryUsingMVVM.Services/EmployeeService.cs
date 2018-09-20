using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDirectory;
using PetaPoco;

namespace EmployeeDirectoryUsingMVVM.Services
{
    public class EmployeeService
    {
        private Database database;
        public EmployeeService()
        {
            database = new Database("EmployeeDirectory");
            AutoMap automap = new AutoMap();
        }

        public int AddEmployee(Models.Employee employee)
        {
            EmployeeDirectory.Employee employeeModel = AutoMap.Mapper.Map<Models.Employee, EmployeeDirectory.Employee>(employee);
            if (employee.Image != null)
                employeeModel.Image = employee.Image;
            else
                employeeModel.Image = null;
            employeeModel.FillAuditFieldsOnCreate<EmployeeDirectory.Employee>();
            return (int)database.Insert(employeeModel);
        }

        public void DeleteEmployee(Models.Employee employee)
        {
            database.Delete<EmployeeDirectory.Employee>(employee.ID);
        }

        public void UpdateEmployee(Models.Employee employee)
        {
            EmployeeDirectory.Employee employeeModel = AutoMap.Mapper.Map<Models.Employee, EmployeeDirectory.Employee>(employee);
            employeeModel.ModifyAuditFieldsOnUpdate<EmployeeDirectory.Employee>();
            string[] args = { "FirstName", "LastName", "Gender", "Salary", "Email", "Mobile", "Department", "Team", "Skype", "BirthDate", "JoiningDate", "Address", "ProfessionalSummary", "Image", "ModifiedBy", "ModifiedDate" };
            database.Update(employeeModel, employeeModel.ID, args);
        }
        public List<Models.Employee> GetEmployeesData()
        {
            var employees = database.Fetch<Employee_Department>("Select * from EMPLOYEE_DEPARTMENT");
            List<Models.Employee> employeeModels = new List<Models.Employee>();
            foreach (var employee in employees)
            {
                Models.Employee employeeModel = AutoMap.Mapper.Map<EmployeeDirectory.Employee_Department, Models.Employee>(employee);
                employeeModels.Add(employeeModel);
            }
            return employeeModels;
        }
    }
}

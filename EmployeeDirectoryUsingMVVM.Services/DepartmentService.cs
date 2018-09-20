using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace EmployeeDirectoryUsingMVVM.Services
{
    public class DepartmentService
    {
        private Database database;        
        public DepartmentService()
        {
            database = new Database("EmployeeDirectory");            
            AutoMap automap = new AutoMap();
        }
        public List<Models.Department> GetDepartmentsData()
        {
            List<Models.Department> departmentModels = new List<Models.Department>();
            List<EmployeeDirectory.Department> departments = database.Fetch<EmployeeDirectory.Department>("").ToList();
            foreach (EmployeeDirectory.Department dept in departments)
            {
                Models.Department departmentModel = AutoMap.Mapper.Map<EmployeeDirectory.Department, Models.Department>(dept);
                departmentModels.Add(departmentModel);
            }
            return departmentModels;
        }
    }
}

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
            List<Models.Department> departments = new List<Models.Department>();
            foreach (EmployeeDirectory.Department dept in database.Fetch<EmployeeDirectory.Department>("").ToList())
            {
                var department = AutoMap.Mapper.Map<EmployeeDirectory.Department, Models.Department>(dept);
                departments.Add(department);
            }
            return departments;
        }
    }
}

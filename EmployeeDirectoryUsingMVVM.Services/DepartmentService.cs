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
            return AutoMap.Mapper.Map<IEnumerable<EmployeeDirectory.Department>, IEnumerable<Models.Department>>(database.Fetch<EmployeeDirectory.Department>("")).ToList();           
        }
    }
}

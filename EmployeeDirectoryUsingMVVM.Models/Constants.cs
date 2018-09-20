using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EmployeeDirectoryUsingMVVM.Models
{
    public static class Constants
    {
        public static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["EmployeeDirectory"].ConnectionString;
    }
}

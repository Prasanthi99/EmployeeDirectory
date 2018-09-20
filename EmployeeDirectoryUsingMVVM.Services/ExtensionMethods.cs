using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDirectory;
using PetaPoco;

namespace EmployeeDirectoryUsingMVVM.Services
{
    public static class ExtensionMethods
    {
        public static void FillAuditFieldsOnCreate<T>(this EmployeeDirectoryDB.Record<T> record) where T : new()
        {
            dynamic dbRecord = (dynamic)record;
            dbRecord.CreatedBy = "Prasanthi";
            dbRecord.CreatedDate = DateTime.Now;
            dbRecord.ModifiedBy = "Prasanthi";
            dbRecord.ModifiedDate = DateTime.Now;
        }
        public static void ModifyAuditFieldsOnUpdate<T>(this EmployeeDirectoryDB.Record<T> record) where T : new()
        {
            dynamic dbRecord = (dynamic)record;
            dbRecord.ModifiedBy = "Prasanthi";
            dbRecord.ModifiedDate = DateTime.Now;
        }
    }
}

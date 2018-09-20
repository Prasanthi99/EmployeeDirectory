




















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `EmployeeDirectory`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=.;database=EmployeeDirectory;Integrated Security=True`
//     Schema:                 ``
//     Include Views:          `False`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace EmployeeDirectory
{

	public partial class EmployeeDirectoryDB : Database
	{
		public EmployeeDirectoryDB() 
			: base("EmployeeDirectory")
		{
			CommonConstruct();
		}

		public EmployeeDirectoryDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			EmployeeDirectoryDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static EmployeeDirectoryDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new EmployeeDirectoryDB();
        }

		[ThreadStatic] static EmployeeDirectoryDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

		public class Record<T> where T:new()
		{
			public static EmployeeDirectoryDB repo { get { return EmployeeDirectoryDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }

			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }

			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

		}

	}
	



    

	[TableName("dbo.Department")]



	[PrimaryKey("ID")]




	[ExplicitColumns]

    public partial class Department : EmployeeDirectoryDB.Record<Department>  
    {



		[Column] public int ID { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string CreatedBy { get; set; }





		[Column] public DateTime CreatedDate { get; set; }





		[Column] public string ModifiedBy { get; set; }





		[Column] public DateTime ModifiedDate { get; set; }



	}

    

	[TableName("dbo.Employee")]



	[PrimaryKey("ID")]




	[ExplicitColumns]

    public partial class Employee : EmployeeDirectoryDB.Record<Employee>  
    {



		[Column] public string FirstName { get; set; }





		[Column] public string LastName { get; set; }





		[Column] public byte Gender { get; set; }





		[Column] public int Salary { get; set; }





		[Column] public string Email { get; set; }





		[Column] public long Mobile { get; set; }





		[Column] public byte Team { get; set; }





		[Column] public string Skype { get; set; }





		[Column] public DateTime BirthDate { get; set; }





		[Column] public DateTime JoiningDate { get; set; }





		[Column] public string Address { get; set; }





		[Column] public string ProfessionalSummary { get; set; }





		[Column] public DateTime CreatedDate { get; set; }





		[Column] public string CreatedBy { get; set; }





		[Column] public string ModifiedBy { get; set; }





		[Column] public DateTime ModifiedDate { get; set; }





		[Column] public int ID { get; set; }





		[Column] public string Image { get; set; }





		[Column] public int Department { get; set; }



	}

    [TableName("dbo.Employee_Department")]




    [ExplicitColumns]

    public partial class Employee_Department : EmployeeDirectoryDB.Record<Employee_Department>
    {



        [Column] public string FirstName { get; set; }





        [Column] public string LastName { get; set; }





        [Column] public byte Gender { get; set; }





        [Column] public int Salary { get; set; }





        [Column] public string Email { get; set; }





        [Column] public long Mobile { get; set; }





        [Column] public byte Team { get; set; }





        [Column] public string Skype { get; set; }





        [Column] public DateTime BirthDate { get; set; }





        [Column] public DateTime JoiningDate { get; set; }





        [Column] public string Address { get; set; }





        [Column] public string ProfessionalSummary { get; set; }




        [Column] public int departmentID { get; set; }




        [Column] public string Name { get; set; }




        [Column] public int employeeID { get; set; }





        [Column] public string Image { get; set; }





        [Column] public int Department { get; set; }

    }


}

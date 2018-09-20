using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeDirectoryUsingMVVM.Models
{
    public class Employee : INotifyPropertyChanged, IDataErrorInfo
    {
        private bool employeePropertyChanged;
        public bool EmployeeDataChanged
        {
            get
            {
                return employeePropertyChanged;
            }
            set
            {
                employeePropertyChanged = value;
                OnPropertyChanged("EmployeePropertyChanged");
            }
        }

        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private Gender gender;
        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private int salary;
        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
                OnPropertyChanged("Salary");
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        private long mobile;
        public long Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
                OnPropertyChanged("Mobile");
            }
        }

        private Department department;
        public Department Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
                OnPropertyChanged("Department");
            }
        }
        private TeamName team;
        public TeamName Team
        {
            get
            {
                return team;
            }
            set
            {
                team = value;
                OnPropertyChanged("Team");
            }
        }
        private string skype;
        public string Skype
        {
            get
            {
                return skype;
            }
            set
            {
                skype = value;
                OnPropertyChanged("Skype");
            }
        }
        private DateTime birthDate;
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }
        private DateTime joiningDate;
        public DateTime JoiningDate
        {
            get
            {
                return joiningDate;
            }
            set
            {
                joiningDate = value;
                OnPropertyChanged("JoiningDate");
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        private string professionalSummary;
        public string ProfessionalSummary
        {
            get
            {
                return professionalSummary;
            }
            set
            {
                professionalSummary = value;
                OnPropertyChanged("ProfessionalSummary");
            }
        }
        public Employee()
        {
            this.Department = new Department();
        }

        public string Error
        {
            get
            {
                return this[string.Empty];
            }
        }
        public string this[string data]
        {
            get
            {
                string result = null;
                if (EmployeeDataChanged)
                {
                    if (data == "FirstName")
                    {
                        if (string.IsNullOrEmpty(FirstName))
                        {
                            result = "First Name Cannot be Empty.";
                            return result;
                        }
                        String st = @"!|@|#|\$|%|\?|\>|\<|\^\)\(\*\[\[\{\}\;\:\+\-\?\*";
                        if (Regex.IsMatch(FirstName, st))
                        {
                            result = "Invalid Format";
                            return result;
                        }
                    }
                    if (data == "ProfessionalSummary")
                    {
                        if (string.IsNullOrEmpty(ProfessionalSummary))
                        {
                            result = "Professional Summary Cannot be Empty.";
                            return result;
                        }
                        String st = @"!|@|#|\$|%|\?|\>|\<|\^\)\(\*\[\[\{\}\;\:\+\-\?\*";
                        if (Regex.IsMatch(ProfessionalSummary, st))
                        {
                            result = "Invalid Format";
                            return result;
                        }
                    }
                    if (data == "LastName")
                    {
                        if (string.IsNullOrEmpty(LastName))
                        {
                            result = "Last Name Cannot be Empty";
                            return result;
                        }
                        String st = @"!|@|#|\$|%|\?|\>|\<|\^\)\(\*\[\[\{\}\;\:\+\-\?\*";
                        if (Regex.IsMatch(LastName, st))
                        {
                            result = "Invalid Format";
                            return result;
                        }
                    }
                    if (data == "Address")
                    {
                        if (string.IsNullOrEmpty(Address))
                        {
                            result = "Address Cannot be Empty";
                            return result;
                        }
                    }
                    if (data == "Mobile")
                    {
                        if (string.IsNullOrEmpty(Mobile.ToString()) || Mobile == 0)
                        {
                            result = "Mobile Number Cannot be Empty";
                            return result;
                        }
                        String st = @"^([0|\+[0-9]{1,5})?([7-9][0-9]{9})$";
                        if (!Regex.IsMatch(Mobile.ToString(), st))
                        {
                            result = "Invalid Number";
                            return result;
                        }
                    }
                    if (data == "BirthDate")
                    {
                        if (string.IsNullOrEmpty(BirthDate.ToString()))
                        {
                            result = "Birth Date Cannot be Empty";
                            return result;
                        }
                    }
                    if (data == "JoiningDate")
                    {
                        if (string.IsNullOrEmpty(JoiningDate.ToString()))
                        {
                            result = "Joining Date Cannot be Empty";
                            return result;
                        }
                    }
                    if (data == "Skype")
                    {
                        if (string.IsNullOrEmpty(Skype))
                        {
                            result = "Skype ID Cannot be Empty";
                            return result;
                        }
                    }
                    if (data == "Email")
                    {
                        if (string.IsNullOrEmpty(Email))
                        {
                            result = "Email Cannot be Empty";
                            return result;
                        }
                        String st = @"^([A-Za-z0-9_\-\.]+)\@([A-Za-z0-9_\-\.]+)\.([A-Za-z]{2,4})$";
                        if (!Regex.IsMatch(Email, st))
                        {
                            result = "Invalid Email Address";
                            return result;
                        }
                    }
                    if (data == "Salary")
                    {
                        if (string.IsNullOrEmpty(Salary.ToString()) || Salary == 0)
                        {
                            result = "Salary Cannot be Empty";
                            return result;
                        }
                        int integer;
                        if (!int.TryParse(Salary.ToString(), out integer) || Salary < 0)
                        {
                            result = "Invalid Data";
                            return result;
                        }
                    }
                }
                return null;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

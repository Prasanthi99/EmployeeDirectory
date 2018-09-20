using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EmployeeDirectoryUsingMVVM.Common;
using EmployeeDirectoryUsingMVVM.Models;
using EmployeeDirectoryUsingMVVM.Services;

namespace EmployeeDirectoryUsingMVVM.ViewModels
{
    public class EmployeeFormViewModel : BaseViewModel
    {
        private MainWindowViewModel mainWindow
        {
            get { return (MainWindowViewModel)System.Windows.Application.Current.MainWindow.DataContext; }
        }
        private DepartmentService departmentService;
        public ICommand CloseFormCommand
        {
            get
            {
                return new DelegateCommand(CloseEmployeeForm);
            }
        }

        private ICommand submitFormCommand;
        public ICommand SubmitFormCommand
        {
            get { return submitFormCommand; }
            set
            {
                submitFormCommand = value;
                OnPropertyChanged("SubmitFormCommand");
            }
        }

        private string buttonContent;
        public string ButtonContent
        {
            get
            {
                return buttonContent;
            }
            set
            {
                buttonContent = value;
                OnPropertyChanged("ButtonContent");
            }
        }

        private string formHeader;
        public string FormHeader
        {
            get
            {
                return formHeader;
            }
            set
            {
                formHeader = value;
                OnPropertyChanged("FormHeader");
            }
        }

        public ICommand UploadPictureCommand
        {
            get { return new DelegateCommand(UploadPicture); }            
        }
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get
            {
                return currentEmployee;
            }
            set
            {
                currentEmployee = value;
                OnPropertyChanged("CurrentEmployee");
            }
        }

        private ObservableCollection<TeamName> teamNames;
        public ObservableCollection<TeamName> TeamNames
        {
            get
            {
                return teamNames;
            }
            set
            {
                teamNames = value;
                OnPropertyChanged("TeamNames");
            }
        }

        private ObservableCollection<Models.Department> departments;
        public ObservableCollection<Models.Department> Departments
        {
            get
            {
                return departments;
            }
            set
            {
                departments = value;
                OnPropertyChanged("Departments");
            }
        }



        public EmployeeFormViewModel()
        {
            departmentService = new DepartmentService();
            //mainWindow = 
            var names = Enum.GetNames(typeof(TeamName)).ToList();
            TeamNames = new ObservableCollection<TeamName>(names.GetRange(1, names.Count - 1).Select(a => (TeamName)Enum.Parse(typeof(TeamName), a)));
            Departments = new ObservableCollection<Models.Department>(departmentService.GetDepartmentsData());
        }

        public void UploadPicture(object param)
        {
            ImageSource image;
            string filePath = null;
            OpenFileDialog op = new OpenFileDialog()
            {
                Title = "Select a picture",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                            "Portable Network Graphic (*.png)|*.png",
                Multiselect = false
            };
            if (op.ShowDialog() == DialogResult.OK)
            {
                filePath = op.FileName;
                image = new BitmapImage(new Uri(filePath));
            }
            string appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string fileName = System.IO.Path.GetFileName(filePath);
            appStartPath = appStartPath + "\\ProfilePictures\\";
            if (!Directory.Exists(appStartPath))
            {
                Directory.CreateDirectory(appStartPath);
            }
            appStartPath = String.Format(appStartPath + fileName, "ProfilePictures");
            if (!File.Exists(appStartPath))
            {
                File.Copy(filePath, appStartPath);
            }
            SelectedEmployee.Image = new BitmapImage(new Uri(appStartPath)).ToString();
        }

        public void SubmitForm(object param)
        {
            //SelectedEmployee.EmployeeDataChanged = true;
            mainWindow.EmployeesList.AddEmployee(SelectedEmployee);
        }

        public void UpdateEmployeeDetails(object param)
        {
            //SelectedEmployee.EmployeeDataChanged = true;
            mainWindow.EmployeesList.UpdateEmployee(SelectedEmployee);
        }

        public void SetFormFieldsToUpdate()
        {            
            this.ButtonContent = "Update";
            this.SubmitFormCommand = new DelegateCommand(this.UpdateEmployeeDetails);
            this.FormHeader = "Edit Employee";
            SelectedEmployee = new Employee()
            {
                ID = CurrentEmployee.ID,
                FirstName = CurrentEmployee.FirstName,
                LastName = CurrentEmployee.LastName,
                BirthDate = CurrentEmployee.BirthDate,
                JoiningDate = CurrentEmployee.JoiningDate,
                Mobile = CurrentEmployee.Mobile,
                Skype = CurrentEmployee.Skype,
                Team = CurrentEmployee.Team,
                Department = CurrentEmployee.Department,
                Gender = CurrentEmployee.Gender,
                Address = CurrentEmployee.Address,
                ProfessionalSummary = CurrentEmployee.ProfessionalSummary,
                Salary = CurrentEmployee.Salary,
                Image = CurrentEmployee.Image,
                Email = CurrentEmployee.Email
            };
            SelectedEmployee.Team = TeamNames.Single(m => m == SelectedEmployee.Team);
            SelectedEmployee.Department = Departments.Single(m => m.ID == SelectedEmployee.Department.ID);
        }

        public void SetFormDetailsToAdd()
        {
            this.SelectedEmployee = new Employee()
            {
                BirthDate = DateTime.Now,
                JoiningDate = DateTime.Now,
                Gender = Gender.Female,
                Department = this.Departments[0],
                Team = this.TeamNames[0]
            };
            this.ButtonContent = "Submit";
            this.SubmitFormCommand = new DelegateCommand(this.SubmitForm);
            this.FormHeader = "Add Employee";
        }
        public void CloseEmployeeForm(object param)
        {
            mainWindow.DisplayEmployeesList();
        }

    }
}

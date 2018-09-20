using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using EmployeeDirectoryUsingMVVM.Models;
using EmployeeDirectoryUsingMVVM.Services;
using System.Windows.Controls;
using System.Windows.Media;
using EmployeeDirectoryUsingMVVM.Common;

namespace EmployeeDirectoryUsingMVVM.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private EmployeesListViewModel employeesList;
        public EmployeesListViewModel EmployeesList
        {
            get
            {
                return employeesList;
            }
            set
            {
                employeesList = value;
                OnPropertyChanged("EmployeesList");
            }
        }
        private EmployeeDetailsViewModel employeeDetails;
        public EmployeeDetailsViewModel EmployeeDetails
        {
            get
            {
                return employeeDetails;
            }
            set
            {
                employeeDetails = value;
                OnPropertyChanged("EmployeeDetails");
            }
        }
        private EmployeeFormViewModel employeeForm;
        public EmployeeFormViewModel EmployeeForm
        {
            get
            {
                return employeeForm;
            }
            set
            {
                employeeForm = value;
                OnPropertyChanged("EmployeeForm");
            }
        }


        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                if (currentViewModel != value)
                {
                    currentViewModel = value;
                    OnPropertyChanged("CurrentViewModel");
                }
            }
        }
       
        public ICommand ToggleSideBarCommand
        {
            get { return new DelegateCommand(ToggleSideBar); }
        }

        public ICommand DisplayContainerCommand
        {
            get { return new DelegateCommand(DisplaySelectedContainer); }
        }

        private bool userControlVisibility=true;
        public bool UserControlVisibility
        {
            get { return userControlVisibility; }
            set
            {
                userControlVisibility = value;
                OnPropertyChanged("UserControlVisibility");
            }
        }

        private bool emptyContainerVisibility = false;
        public bool EmptyContainerVisibility
        {
            get { return emptyContainerVisibility; }
            set
            {
                emptyContainerVisibility = value;
                OnPropertyChanged("EmptyContainerVisibility");
            }
        }
        private bool textBlockVisibility = true;
        public bool TextBlockVisibility
        {
            get { return textBlockVisibility; }
            set
            {
                textBlockVisibility = value;
                OnPropertyChanged("TextBlockVisibility");
            }
        }
        private SolidColorBrush homeButtonBackground;
        public SolidColorBrush HomeButtonBackground
        {
            get
            {
                return homeButtonBackground;
            }
            set
            {
                homeButtonBackground = value;
                OnPropertyChanged("HomeButtonBackground");
            }
        }
        private SolidColorBrush calenderButtonBackground;
        public SolidColorBrush CalenderButtonBackground
        {
            get
            {
                return calenderButtonBackground;
            }
            set
            {
                calenderButtonBackground = value;
                OnPropertyChanged("CalenderButtonBackground");
            }
        }
        private SolidColorBrush myTeamButtonBackground;
        public SolidColorBrush MyTeamButtonBackground
        {
            get
            {
                return myTeamButtonBackground;
            }
            set
            {
                myTeamButtonBackground = value;
                OnPropertyChanged("MyTeamButtonBackground");
            }
        }
        private SolidColorBrush employeesButtonBackground = new SolidColorBrush(Color.FromRgb(41, 54, 76));
        public SolidColorBrush EmployeesButtonBackground
        {
            get
            {
                return employeesButtonBackground;
            }
            set
            {
                employeesButtonBackground = value;
                OnPropertyChanged("EmployeesButtonBackground");
            }
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

        public MainWindowViewModel()
        {
            this.EmployeesList = new EmployeesListViewModel();
            this.CurrentViewModel = EmployeesList;
        }

        private void ToggleSideBar(object param)
        {
            TextBlockVisibility = !TextBlockVisibility;
        }
               
        private void DisplaySelectedContainer(object param)
        {
            Button button = param as Button;
            EmptyContainerVisibility = !button.Name.Equals("EmployeesButton");
            SetButtonDefaultColor();
            button.Background = new SolidColorBrush(Color.FromRgb(41, 54, 76));
        }

        private void SetButtonDefaultColor()
        {
            HomeButtonBackground = EmployeesButtonBackground = CalenderButtonBackground = MyTeamButtonBackground = new SolidColorBrush(Color.FromRgb(51, 65, 75));
        }

        public void DisplayEmployeeDetails(Employee employee)
        {
            this.SelectedEmployee = employee;
            this.EmployeeDetails = new EmployeeDetailsViewModel();
            this.CurrentViewModel = EmployeeDetails;
            this.EmployeeDetails.SelectedEmployee = employee;
        }

        public void DisplayEmployeeFormToEdit()
        {
            DisplayEmployeeForm();    
            this.EmployeeForm.CurrentEmployee = this.SelectedEmployee;
            this.EmployeeForm.SetFormFieldsToUpdate();
        }

        public void DisplayEmployeeForm()
        {
            this.EmployeeForm = new EmployeeFormViewModel();
            this.CurrentViewModel = EmployeeForm;
        }

        public void DisplayEmployeeFormToAdd()
        {
            DisplayEmployeeForm();
            EmployeeForm.SetFormDetailsToAdd();
        }       

        public void DisplayEmployeesList()
        {
            this.CurrentViewModel = EmployeesList;
        }       
    }
}

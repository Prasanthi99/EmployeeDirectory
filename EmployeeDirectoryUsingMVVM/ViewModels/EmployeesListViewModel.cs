using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using EmployeeDirectoryUsingMVVM.Common;
using EmployeeDirectoryUsingMVVM.Models;
using EmployeeDirectoryUsingMVVM.Services;

namespace EmployeeDirectoryUsingMVVM.ViewModels
{
    public class EmployeesListViewModel:BaseViewModel
    {
        private EmployeeService employeeService;
        private MainWindowViewModel mainWindow
        {
            get { return (MainWindowViewModel)Application.Current.MainWindow.DataContext; }
        }
        public ICommand AddEmployeeCommand
        {
            get
            {
                return new DelegateCommand(AddEmployee);
            }           
        }
        private ICommand selectEmployeeCommand;
        public ICommand SelectEmployeeCommand
        {
            get { return selectEmployeeCommand; }
            set { selectEmployeeCommand = value;
                OnPropertyChanged("SelectEmployeeCommand");
            }
        }
        
        private bool gridViewVisibility = false;
        public bool GridViewVisibility
        {
            get { return gridViewVisibility; }
            set
            {
                gridViewVisibility = value;
                OnPropertyChanged("GridViewVisibility");
            }
        }

        private bool listViewVisibility = true;
        public bool ListViewVisibility
        {
            get { return listViewVisibility; }
            set
            {
                listViewVisibility = value;
                OnPropertyChanged("ListViewVisibility");
            }
        }
        private SolidColorBrush gridViewBackground;
        public SolidColorBrush GridViewBackground
        {
            get
            {
                return gridViewBackground;
            }
            set
            {
                gridViewBackground = value;
                OnPropertyChanged("GridViewBackground");
            }
        }
        private SolidColorBrush listViewBackground = new SolidColorBrush(Color.FromRgb(239, 239, 239));
        public SolidColorBrush ListViewBackground
        {
            get
            {
                return listViewBackground;
            }
            set
            {
                listViewBackground = value;
                OnPropertyChanged("ListViewBackground");
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

        private TeamName selectedDepartment = TeamName.All;
        public TeamName SelectedDepartment
        {
            get
            {
                return selectedDepartment;
            }
            set
            {
                selectedDepartment = value;
                OnPropertyChanged("SelectedDepartment");
                Filter();
            }
        }

        private string employeeGridTitle = "All Employees";
        public string EmployeeGridTitle
        {
            get
            {
                return employeeGridTitle;
            }
            set
            {
                employeeGridTitle = value;
                OnPropertyChanged("SelectedDepartment");
                OnPropertyChanged("EmployeeGridTitle");
            }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }

        private ObservableCollection<Employee> allEmployees;
        public ObservableCollection<Employee> AllEmployees
        {
            get { return allEmployees; }
            set
            {
                allEmployees = value;
            }
        }

        public ICommand ToggleViewCommand
        {
            get
            {
                return new DelegateCommand(ToggleEmployeeGridView);
            }
        }
        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged("SearchText");
                    Search();
                }
            }
        }

        public EmployeesListViewModel()
        {
            employeeService = new EmployeeService();
            Employees = new ObservableCollection<Employee>(employeeService.GetEmployeesData());
            SelectEmployeeCommand = new DelegateCommand(DisplayEmployeeDetails);
            AllEmployees = new ObservableCollection<Employee>(Employees);
        }

        public void DisplayEmployeeDetails(object param)
        {
            if(SelectedEmployee != null)
                mainWindow.DisplayEmployeeDetails(SelectedEmployee);
        }
        private void ToggleEmployeeGridView(object param)
        {
            GridViewVisibility = !((Button)param).Name.Equals("list");
            ListViewVisibility = ((Button)param).Name.Equals("list");
            ListViewBackground = ((Button)param).Name.Equals("list") ? new SolidColorBrush(Color.FromRgb(239, 239, 239)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
            GridViewBackground = !((Button)param).Name.Equals("list") ? new SolidColorBrush(Color.FromRgb(239, 239, 239)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
        private void Filter()
        {
            Employees = (SelectedDepartment.Equals(TeamName.All) ? AllEmployees : new ObservableCollection<Models.Employee>(AllEmployees.Where(x => x.Team.Equals(SelectedDepartment))));
            this.EmployeeGridTitle = SelectedDepartment == TeamName.All ? "All Employees" : $"{SelectedDepartment.ToString()} Team Employees";
        }

        private void Search()
        {
            string searchText=null;
            if (!string.IsNullOrEmpty(SearchText))
            {
                searchText = SearchText.ToLower().Trim();
                Employees = new ObservableCollection<Models.Employee>(AllEmployees.Where(x => ($"{x.FirstName} {x.LastName}".ToLower().Contains(searchText)) || (x.Salary.ToString().ToLower().Contains(searchText))));
            }
        }

        private void AddEmployee(object param)
        {
            mainWindow.DisplayEmployeeFormToAdd();            
        }

        public void AddEmployee(Employee employee)
        {
            employee.ID = employeeService.AddEmployee(employee);
            //Employees.Add(employee);
            AllEmployees.Add(employee);
            Filter();
            Search();
            mainWindow.DisplayEmployeesList();
        }

        public void UpdateEmployee(Employee employee)
        {
            employeeService.UpdateEmployee(employee);
            Employees[SelectedIndex] = employee;
            AllEmployees[AllEmployees.IndexOf(AllEmployees.FirstOrDefault(m => m.ID == employee.ID))] = employee;
            Filter();
            Search();
            mainWindow.DisplayEmployeesList();
        }

        public void DeleteEmployee(Employee employee)
        {
            employeeService.DeleteEmployee(employee);
            AllEmployees.Remove(employee);
            Filter();
            Search();
            mainWindow.DisplayEmployeesList();
        }
    }
}

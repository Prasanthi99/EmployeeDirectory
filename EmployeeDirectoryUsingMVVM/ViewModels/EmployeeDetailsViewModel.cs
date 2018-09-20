using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EmployeeDirectoryUsingMVVM.Common;
using EmployeeDirectoryUsingMVVM.Models;

namespace EmployeeDirectoryUsingMVVM.ViewModels
{
    public class EmployeeDetailsViewModel : BaseViewModel
    {
        private MainWindowViewModel mainWindow
        {
            get {  return (MainWindowViewModel)Application.Current.MainWindow.DataContext; }
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

        public ICommand ClosePopupCommand
        {
            get
            {
                return new DelegateCommand(CloseEmployeeDetailsPopup);
            }            
        }

        public ICommand DeleteEmployeeCommand
        {
            get
            {
                return new DelegateCommand(DeleteSelectedEmployee);
            }
        }

        public ICommand EditEmployeeDetailsCommand
        {
            get
            {
                return new DelegateCommand(EditEmployeeDetails);
            }
        }

        public EmployeeDetailsViewModel()
        {
           
        }

        private void EditEmployeeDetails(object param)
        {
            mainWindow.DisplayEmployeeFormToEdit();
        }

        private void CloseEmployeeDetailsPopup(object param)
        {
            mainWindow.DisplayEmployeesList();
        }

        private void DeleteSelectedEmployee(object param)
        {
            mainWindow.EmployeesList.DeleteEmployee(SelectedEmployee);
        }

    }
}

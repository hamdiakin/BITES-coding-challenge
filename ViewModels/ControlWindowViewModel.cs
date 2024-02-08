using HRManagementApp.Models;
using HRManagementApp.Models.Enums;
using HRManagementApp.Views;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;

namespace HRManagementApp.ViewModels
{
    class ControlWindowViewModel : ViewModelBase
    {
        #region Fields
        private readonly XmlSerializer serializer;
        private const int MaxPositions = 20;
        #endregion

        #region Constructor
        public ControlWindowViewModel()
        {
            Title = "User Dashboard";
            InitializeSampleData();
            serializer = new XmlSerializer(typeof(Employee));
        }
        #endregion

        #region Commands
        public ICommand AddCommand => new RelayCommand(Add, CanAdd);
        public ICommand RemoveCommand => new RelayCommand(Remove);
        public ICommand EditCommand => new RelayCommand(Edit);
        public ICommand SaveCommand => new RelayCommand(Save);
        public ICommand LoadCommand => new RelayCommand(Load);
        #endregion

        #region Properties
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public Employee SelectedPosition { get; set; }
        public Employee SelectedEmployee { get; set; }

        private ObservableCollection<Employee> activeEmployees;
        public ObservableCollection<Employee> ActiveEmployees
        {
            get { return activeEmployees; }
            set { activeEmployees = value; OnPropertyChanged(nameof(ActiveEmployees)); }
        }

        private ObservableCollection<Employee> positionsToUpdate;
        public ObservableCollection<Employee> PositionsToUpdate
        {
            get { return positionsToUpdate; }
            set { positionsToUpdate = value; OnPropertyChanged(nameof(PositionsToUpdate)); }
        }
        #endregion

        #region Initialization
        private void InitializeSampleData()
        {
            ActiveEmployees = new ObservableCollection<Employee>
            {
                new Employee { Name = "Ahmet", Surname = "Aslan", Position = PositionEnum.SoftwareEngineer, Experience = 3, Status = StatusEnum.Hiring },
                new Employee { Name = "Zeynep", Surname = "Aslım", Position = PositionEnum.SeniorSoftwareEngineer, Experience = 6, Status = StatusEnum.Hiring }
            };

            PositionsToUpdate = new ObservableCollection<Employee>
            {
                new Employee { Name = "Mehmet", Surname = "Kaya", Position = PositionEnum.LeadEngineer, Experience = 9, Status = StatusEnum.Firing },
            };
        }
        #endregion

        #region Command Methods
        private void Save()
        {
            try
            {
                var dialog = new SaveFileDialog();
                ConfigureDialog(dialog, "Select Save Location");

                if (dialog.ShowDialog() == true)
                {
                    string filePath = dialog.FileName;
                    SerializeSelectedEmployee(filePath);
                    MessageBox.Show("Success", "Data saved successfully!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                HandleException("An error occurred while saving data: " + ex.Message);
            }
        }

        private void Load()
        {
            try
            {
                var dialog = new OpenFileDialog();
                ConfigureDialog(dialog, "Select XML File to Load");

                if (dialog.ShowDialog() == true)
                {
                    string filePath = dialog.FileName;
                    if (IsXmlFileValid(filePath))
                    {
                        DeserializeEmployeeData(filePath);
                        MessageBox.Show("Success", "Data loaded successfully!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "The selected XML file is not valid.", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException("An error occurred while loading data: " + ex.Message);
            }
        }
        #endregion

        #region Private Methods
        private void ConfigureDialog(FileDialog dialog, string title)
        {
            dialog.Filter = "XML Files (*.xml)|*.xml";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Title = title;
        }

        private void SerializeSelectedEmployee(string filePath)
        {
            if (SelectedEmployee != null)
            {
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, SelectedEmployee);
                }
            }
            else
            {
                MessageBox.Show("Error", "No employee selected to save!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeserializeEmployeeData(string filePath)
        {
            using (TextReader reader = new StreamReader(filePath))
            {
                var loadedData = (Employee)serializer.Deserialize(reader);
                if (!ActiveEmployees.Any(e => e.Name == loadedData.Name && e.Surname == loadedData.Surname))
                {
                    ActiveEmployees.Add(loadedData);
                }
            }
        }

        private bool IsXmlFileValid(string filePath)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    while (reader.Read()) { }
                    return true;
                }
            }
            catch (XmlException)
            {
                return false;
            }
        }

        private void Add()
        {
            var viewModel = new EditAddEmployeeViewModel(isEditing: false);
            EditAddEmployeeWindow addWindow = new EditAddEmployeeWindow();

            Window controlWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(window => window.GetType() == typeof(ControlWindow));
            if (controlWindow != null)
            {
                addWindow.Owner = controlWindow;
            }
            addWindow.DataContext = viewModel;
            addWindow.ShowDialog();

            var result = FindEmployeeInList(viewModel.UpdatedEmployee, ActiveEmployees);
            if (result != null)
            {
                result.Status = viewModel.UpdatedEmployee.Status;
                HandleEmployeeAddition(result);
            }
            else if(viewModel.UpdatedEmployee != null)
            {
                HandleEmployeeAddition(viewModel.UpdatedEmployee);
            }
        }

        private void HandleEmployeeAddition(Employee employee)
        {
            switch (employee.Status)
            {
                case StatusEnum.Hiring:
                    PositionsToUpdate.Add(employee);
                    ActiveEmployees.Add(employee);
                    break;
                case StatusEnum.Firing:
                    PositionsToUpdate.Add(employee);
                    ActiveEmployees.Remove(employee);
                    break;
            }
        }

        private void Edit()
        {
            var viewModel = new EditAddEmployeeViewModel(isEditing: true, SelectedPosition);
            EditAddEmployeeWindow addWindow = new EditAddEmployeeWindow();
            addWindow.DataContext = viewModel;
            addWindow.ShowDialog();

            if (SelectedPosition != null)
            {
                SwapEmployee(SelectedPosition, viewModel.UpdatedEmployee, positionsToUpdate);
            }
        }

        private void Remove()
        {
            if (SelectedPosition != null)
            {
                PositionsToUpdate.Remove(SelectedPosition);
            }
        }

        private void SwapEmployee(Employee oldEmployee, Employee newEmployee, ObservableCollection<Employee> employeesList)
        {
            if (employeesList == null)
                return;

            if (oldEmployee != null && newEmployee != null && employeesList.Contains(oldEmployee))
            {
                int index = employeesList.IndexOf(oldEmployee);
                employeesList.RemoveAt(index);
                employeesList.Insert(index, newEmployee);
            }
        }

        private bool CanAdd()
        {
            return PositionsToUpdate.Count < MaxPositions;
        }

        private Employee FindEmployeeInList(Employee employee, ObservableCollection<Employee> employeesList)
        {
            if (employee == null || employeesList == null)
                return null;

            return employeesList.FirstOrDefault(e => e.Name == employee.Name && e.Surname == employee.Surname);
        }

        private void HandleException(string message)
        {
            MessageBox.Show("Error", message, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion
    }
}

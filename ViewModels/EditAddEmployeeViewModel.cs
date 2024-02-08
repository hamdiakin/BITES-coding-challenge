using HRManagementApp.Models;
using HRManagementApp.Models.Enums;
using HRManagementApp.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace HRManagementApp.ViewModels
{
    public class EditAddEmployeeViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields

        private string title;
        private string employeeName;
        private string employeeSurname;
        private int employeeExperience;
        private string employeeExperienceAsString;
        private PositionEnum? selectedPosition;
        private StatusEnum? selectedStatus;

        #endregion

        #region Properties

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public Employee? updatedEmployee { get; set; }
        public Employee UpdatedEmployee
        {
            get { return updatedEmployee; }
            set
            {
                updatedEmployee = value;
                OnPropertyChanged(nameof(UpdatedEmployee));
            }
        }

        public string EmployeeName
        {
            get { return employeeName; }
            set
            {
                employeeName = value;
                OnPropertyChanged(nameof(EmployeeName));
            }
        }

        public int EmployeeExperience
        {
            get { return employeeExperience; }
            set
            {
                employeeExperience = value;

                OnPropertyChanged(nameof(EmployeeExperience));
                OnPropertyChanged(nameof(SelectedPosition));
            }
        }

        public string EmployeeExperienceAsString
        {
            get { return employeeExperienceAsString; }
            set
            {
                if (int.TryParse(value, out int parsedValue))
                {
                    EmployeeExperience = parsedValue;
                }

                employeeExperienceAsString = value;
                OnPropertyChanged(nameof(EmployeeExperienceAsString));
                OnPropertyChanged(nameof(SelectedPosition));
            }
        }

        public string EmployeeSurname
        {
            get { return employeeSurname; }
            set
            {
                employeeSurname = value;
                OnPropertyChanged(nameof(EmployeeSurname));
            }
        }

        public PositionEnum? SelectedPosition
        {
            get { return selectedPosition; }
            set
            {
                selectedPosition = value;
                OnPropertyChanged(nameof(SelectedPosition));
                OnPropertyChanged(nameof(EmployeeExperience));
            }
        }

        public StatusEnum? SelectedStatus
        {
            get { return selectedStatus; }
            set
            {
                selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }

        public ObservableCollection<PositionEnum> Positions { get; set; }
        public ObservableCollection<int> ExperienceRange { get; set; }
        public ObservableCollection<StatusEnum> StatusOptions { get; set; }
        public ObservableCollection<PositionDisplayItem> PositionDisplayItems { get; set; }

        public string ButtonText { get; set; }
        public ICommand ButtonCommand { get; set; }

        #endregion

        #region Constructor

        public EditAddEmployeeViewModel()
        {
        }

        public EditAddEmployeeViewModel(bool isEditing)
        {
            InitializeViewModel(isEditing);
        }

        public EditAddEmployeeViewModel(bool isEditing, Employee employee)
        {
            InitializeViewModel(isEditing);
            InitializeEmployee(employee);
        }

        private void InitializeViewModel(bool isEditing)
        {
            if (isEditing)
            {
                ButtonText = "Edit";
                Title = "Edit Position Information";
            }
            else
            {
                ButtonText = "Add";
                Title = "Add New Position";
            }
            ButtonCommand = new RelayCommand(PrepareEmployee);
            InitializeComboBoxOptions();
        }

        private void InitializeEmployee(Employee employee)
        {
            if (employee != null)
            {
                EmployeeName = employee.Name;
                EmployeeSurname = employee.Surname;
                SelectedPosition = employee.Position;
                EmployeeExperience = employee.Experience;
                SelectedStatus = employee.Status;
            }
        }

        #endregion

        #region Initialization

        private void InitializeComboBoxOptions()
        {
            StatusOptions = new ObservableCollection<StatusEnum>(Enum.GetValues(typeof(StatusEnum)).Cast<StatusEnum>());
            PositionDisplayItems = new ObservableCollection<PositionDisplayItem>
            {
                new PositionDisplayItem(),
                new PositionDisplayItem("Software Engineer", PositionEnum.SoftwareEngineer),
                new PositionDisplayItem("Testing Engineer", PositionEnum.TestingEngineer),
                new PositionDisplayItem("Senior Software Engineer", PositionEnum.SeniorSoftwareEngineer),
                new PositionDisplayItem("Senior Test Engineer", PositionEnum.SeniorTestEngineer),
                new PositionDisplayItem("Lead Engineer", PositionEnum.LeadEngineer),
                new PositionDisplayItem("Senior Lead Engineer", PositionEnum.SeniorLeader),
            };
        }

        #endregion

        #region Command Method

        private void PrepareEmployee()
        {
            if (!HasValidationErrors())
            {
                UpdatedEmployee = new Employee
                {
                    Name = this.EmployeeName,
                    Surname = this.EmployeeSurname,
                    Experience = this.EmployeeExperience,
                    Position = (PositionEnum)this.SelectedPosition,
                    Status = this.SelectedStatus
                };

                
                var window = Application.Current.Windows.OfType<Window>().Where(x => x is EditAddEmployeeWindow).SingleOrDefault();
                window.DialogResult = true;
                window.Close();
            }
            else
            {
                MessageBox.Show("Error", "Please correct the validation errors.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region Validation

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case "EmployeeName":
                        if (string.IsNullOrWhiteSpace(EmployeeName) || !IsValidName(EmployeeName))
                        {
                            error = "Please enter a valid name (up to 10 alphabetical characters).";
                        }
                        break;
                    case "EmployeeSurname":
                        if (string.IsNullOrWhiteSpace(EmployeeSurname) || !IsValidSurname(EmployeeSurname))
                        {
                            error = "Please enter a valid surname (up to 15 alphabetical characters).";
                        }
                        break;
                    case "EmployeeExperienceAsString":
                        error = ValidateExperience();
                        break;
                    case "SelectedPosition":
                    case "SelectedExperience":
                        error = ValidatePositionAndExperience();
                        break;
                    default:
                        break;
                }

                return error;
            }
        }

        public string Error => null;

        private string ValidateExperience()
        {
            string error = null;

            if (string.IsNullOrWhiteSpace(EmployeeExperienceAsString))
            {
                error = "Please enter a valid numeric value for experience.";
            }
            else if (!IsNumeric(EmployeeExperienceAsString) || int.Parse(EmployeeExperienceAsString) < 0 || int.Parse(EmployeeExperienceAsString) > 15)
            {
                error = "Experience should be a numeric value between 0 and 15.";
            }

            return error;
        }


        private bool IsNumeric(string value)
        {
            return int.TryParse(value, out _);
        }

        private bool IsValidName(string name)
        {
            return name.All(char.IsLetter) && name.Length <= 10;
        }

        private bool IsValidSurname(string surname)
        {
            return surname.All(char.IsLetter) && surname.Length <= 15;
        }

        private string ValidatePositionAndExperience()
        {
            string error = null;
            if (SelectedPosition == PositionEnum.SoftwareEngineer || SelectedPosition == PositionEnum.TestingEngineer)
            {
                if (EmployeeExperience < 0 || EmployeeExperience > 3)
                {
                    error = "Experience range for Software/Test Engineers is [0,3].";
                }
            }
            else if (SelectedPosition == PositionEnum.SeniorSoftwareEngineer || SelectedPosition == PositionEnum.SeniorTestEngineer)
            {
                if (EmployeeExperience < 4 || EmployeeExperience > 7)
                {
                    error = "Experience range for Senior Software/Senior Test Engineers is [4,7].";
                }
            }
            else if (SelectedPosition == PositionEnum.LeadEngineer)
            {
                if (EmployeeExperience < 8 || EmployeeExperience > 11)
                {
                    error = "Experience range for Lead Engineers is [8,11].";
                }
            }
            else if (SelectedPosition == PositionEnum.SeniorLeader)
            {
                if (EmployeeExperience < 12 || EmployeeExperience > 15)
                {
                    error = "Experience range for Senior Lead Engineers is [12,15].";
                }
            }
            else if (SelectedPosition == null)
            {
                error = "Position cannot be empty";
            }
            return error;
        }

        public bool HasValidationErrors()
        {
            var errorProperties = GetType().GetProperties()
                .Where(prop => this[prop.Name] != null)
                .ToList();

            return errorProperties.Count > 0;
        }

        #endregion
    }
}

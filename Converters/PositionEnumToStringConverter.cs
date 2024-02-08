using HRManagementApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HRManagementApp.Converters
{
    public class PositionEnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is PositionEnum position)
            {
                switch (position)
                {
                    case PositionEnum.SoftwareEngineer:
                        return "Software Engineer";
                    case PositionEnum.TestingEngineer:
                        return "Testing Engineer";
                    case PositionEnum.SeniorSoftwareEngineer:
                        return "Senior Software Engineer";
                    case PositionEnum.SeniorTestEngineer:
                        return "Senior Test Engineer";
                    case PositionEnum.LeadEngineer:
                        return "Lead Engineer";
                    case PositionEnum.SeniorLeader:
                        return "Senior Leader";
                    default:
                        return "Unknown Position";
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

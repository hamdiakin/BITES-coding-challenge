using HRManagementApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementApp.Models
{
    public class PositionDisplayItem
    {
        public string? DisplayText { get; set; }
        public PositionEnum? EnumValue { get; set; }

        public PositionDisplayItem(string displayText, PositionEnum enumValue)
        {
            DisplayText = displayText;
            EnumValue = enumValue;
        }

        public PositionDisplayItem()
        {
        }
    }

}

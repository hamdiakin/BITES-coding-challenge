using HRManagementApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementApp.Models
{
    [Serializable]
    public class Employee
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public PositionEnum Position { get; set; }
        public int Experience { get; set; }
        public StatusEnum? Status { get; set; }

        public string GetPositionAsString()
        {
            switch (Position)
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
    }
}

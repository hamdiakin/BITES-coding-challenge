using HRManagementApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementApp.Models
{
    public class Employee
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public PositionEnum Position { get; set; }
        public int Experience { get; set; }
        public StatusEnum Status { get; set; }
    }
}

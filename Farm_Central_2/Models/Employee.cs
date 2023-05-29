using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Farm_Central_2.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeUsername { get; set; }
        public string EmployeePassword { get; set; }
    }
}

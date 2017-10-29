using System;
using System.ComponentModel;

namespace DemoEasyAccess.Models
{
    public class EasyTableModel
    {
        [DisplayName("ID")]
        public string EmployeeId { get; set; }

        [DisplayName("Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Job Title")]
        public string JobTitle { get; set; }
    }
}

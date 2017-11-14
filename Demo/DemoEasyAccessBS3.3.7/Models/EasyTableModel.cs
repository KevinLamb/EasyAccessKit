using System;
using System.ComponentModel;

namespace DemoEasyAccessBS3._3._7.Models
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

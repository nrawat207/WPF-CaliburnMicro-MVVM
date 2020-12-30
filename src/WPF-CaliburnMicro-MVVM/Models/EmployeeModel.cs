using Caliburn.Micro;
using System;

namespace WPF_CaliburnMicro_MVVM.Models
{
    public class EmployeeModel 
    {
        public EmployeeModel()
        {
            DOB = DateTime.Now;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime DOB { get; set; }
        public string DOBText { get { return (DOB.ToShortDateString()); } }

    }
}

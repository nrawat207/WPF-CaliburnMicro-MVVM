using System;

namespace WebApi.Models
{
    public class EmployeeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime DOB { get; set; }        
    }
}
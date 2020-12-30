using System;

namespace Domain
{
    public class Employee
    {
        public Employee()
        {
            TimeStamp = DateTime.Now;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime DOB { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

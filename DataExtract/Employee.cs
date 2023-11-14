using System;
namespace DataExtract
{
    public class Employee
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string DepartmentName { get; set; }

        public bool IsManager { get; set; }

        public IEnumerable<int> DirectReports { get; set; }
    }
}


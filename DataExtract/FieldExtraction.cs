using System;
namespace DataExtract
{
    public static class FieldExtraction
    {
        public static Dictionary<int, Validtor> Rules = new Dictionary<int, Validtor>()
        {
            {0, new Validtor(typeof(int), "ID", Constants.InvalidEmployee ) },
            {1, new Validtor(typeof(string),"CompanyName",  Constants.InvalidCompany) },
            {2, new Validtor(typeof(string), "DepartmentName", Constants.InvalidDept)},
            {3, new Validtor(typeof(EmployeeNameExtractor), propertyName: null, Constants.InvalidEmpName, true) },
            {4, new Validtor(typeof(ManagerFieldExtractor), "IsManager", Constants.InvalidManagerType, true) },
            {5, new Validtor(typeof(DirectReportFieldExtract), "DirectReports", Constants.InvalidDirectReports, true) }
        };
    }
}


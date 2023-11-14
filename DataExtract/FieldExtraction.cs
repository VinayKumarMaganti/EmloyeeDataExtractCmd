using System;
namespace DataExtract
{
    public static class FieldExtraction
    {
        public static Dictionary<int, Validator> Rules = new Dictionary<int, Validator>()
        {
            {0, new Validator(typeof(int), "ID", Constants.InvalidEmployee ) },
            {1, new Validator(typeof(string),"CompanyName",  Constants.InvalidCompany) },
            {2, new Validator(typeof(string), "DepartmentName", Constants.InvalidDept)},
            {3, new Validator(typeof(EmployeeNameExtractor), propertyName: null, Constants.InvalidEmpName, true) },
            {4, new Validator(typeof(ManagerFieldExtractor), "IsManager", Constants.InvalidManagerType, true) },
            {5, new Validator(typeof(DirectReportFieldExtract), "DirectReports", Constants.InvalidDirectReports, true) }
        };
    }
}


using System;
namespace DataExtract
{
	public static class Constants
	{
        public const char TopLevelDelimiter = ',';
        public const char NameLevelDelimiter = ';';
        public const char ReportingDelimiter = ';';
        public const string DelimitCountMisMatch = "Line doesn't contain proper top level fields";
        public const string InvalidEmployee = "Invalid Employee Id at line {0}";
        public const string InvalidCompany = "Invalid Company Name at line {0}";
        public const string InvalidDept = "Invalid Department Name at line {0}";
        public const string InvalidEmpName = "Invalid Employee Name at line {0}";
        public const string InvalidManagerType = "Invalid Manager type at line {0}";
        public const string InvalidDirectReports = "Invalid direct reports format at line {0}";
    }
}


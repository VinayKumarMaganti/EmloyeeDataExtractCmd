using System;
namespace DataExtract
{
    public class DirectReportFieldExtract
    {
        public string Field { get; set; }
        public DirectReportFieldExtract(string field)
        {
            Field = field;
        }

        public bool InvokeParse(Employee employee)
        {

            if (employee.IsManager)
            {
                var reportsField = Field.Split(Constants.ReportingDelimiter);
                bool isAllValid = true;
                //Extract direct reports by comparing their type
                var directreports = reportsField.Select(x =>
                {

                    int val;
                    bool isValid = int.TryParse(x, out val);
                    isAllValid = isAllValid && isValid;
                    return val;
                });
                if (isAllValid)
                {
                    employee.DirectReports = directreports;
                    return true;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Field))
                    return true;
            }
            return false;
        }
    }
}
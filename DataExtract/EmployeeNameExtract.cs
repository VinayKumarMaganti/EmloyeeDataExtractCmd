using System;
namespace DataExtract
{
    public class EmployeeNameExtractor
    {
        public EmployeeNameExtractor(string field)
        {
            Field = field;
        }

        private string Field { get; set; }

        public bool InvokeParse(Employee employee)
        {
            var nameFields = Field.Split(Constants.NameLevelDelimiter);
            if (nameFields.Length == 3)
            {
                if (!string.IsNullOrEmpty(nameFields[0]))
                {
                    employee.FirstName = nameFields[0];
                }
                else
                {


                    return false;
                }

                // Assumption :  middle name can be possibly empty
                employee.MiddleName = nameFields[1];

                if (!string.IsNullOrEmpty(nameFields[2]))
                {
                    employee.LastName = nameFields[2];
                }
                else
                {
                    return false;
                }

                return true;

            }
            return false;
        }
    }
}


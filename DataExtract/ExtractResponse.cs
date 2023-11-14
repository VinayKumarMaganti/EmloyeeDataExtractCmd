using System;
namespace DataExtract
{
    public class ExtractResponse
    {
        public ExtractResponse(IList<Employee> employees, IList<Error> errors)
        {

            Employees = employees;
            Errors = errors;
        }

        public IList<Error> Errors;

        public IList<Employee> Employees;
    }
}


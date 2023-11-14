using System;
namespace DataExtract
{
	public class ManagerFieldExtractor
	{
        public string Field { get; set; }

		public ManagerFieldExtractor(string field)
		{
            Field = field;
		}

        public bool InvokeParse(Employee employee)
        {
            if (Field.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                employee.IsManager = true;
                return true;
            }
            else if (Field.Equals("n", StringComparison.InvariantCultureIgnoreCase))
            {
                employee.IsManager = false;
                return true;
            }
            else
                return false;
        }
    }
}


using System;
using System.Reflection;

namespace DataExtract
{
    public class DataExtractBusiness
    {
        /// <summary>
        /// Read employee based on the validation rules
        /// </summary>
        /// <param name="employeeFields"></param>
        /// <param name="line"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        private Employee? ReadEmployee(string[] employeeFields, int line, out string? error)
        {
            var employee = new Employee();
            error = null;
            for (var i = 0; i < employeeFields.Length; i++)
            {
                var validtor = FieldExtraction.Rules[i];
                try
                {
                    //Basic type validations
                    if (!validtor.IsCustom)
                    {
                        var value = Convert.ChangeType(employeeFields[i]?.Trim(), validtor.Type);
                        var propertyInfo = employee.GetType().GetProperty(validtor.PropertyName);
                        if (propertyInfo != null)
                            propertyInfo.SetValue(employee, value);
                        else
                        {
                            error = string.Format(validtor.ErrorMessage, line);
                            return null;
                        }
                    }
                    // Custom type validation includes specific type class to invoke extraction
                    else
                    {
                        Type type = validtor.Type;
                        var obj = Activator.CreateInstance(type, employeeFields[i]?.Trim());
                        if (obj != null)
                        {
                            var methodInfo = obj.GetType().GetMethod("InvokeParse");
                            var methodResponse = methodInfo?.Invoke(obj, new object[1] { employee });
                            var responseObj = Convert.ToBoolean(methodResponse);
                            if (!responseObj)
                            {
                                error = string.Format(validtor.ErrorMessage, line);
                                return null;
                            }
                        }
                    }
                }
                catch (InvalidCastException ex)
                {
                    error = $"Exception {ex.Message} at {line}";
                }
            }
            return employee;
        }


        /// <summary>
        /// Extract file line by line into employee object
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal ExtractResponse ExtractFile(string path)
        {
            var extractResponse = new ExtractResponse(new List<Employee>(), new List<Error>());
            try
            {
                string[] lines = File.ReadAllLines(path);
                for (var line = 0; line < lines.Length; line++)
                {
                    var employeeFields = lines[line].Split(',');

                    if (employeeFields.Length < 5 || employeeFields.Length > 6)
                    {
                        extractResponse.Errors.Add(new Error(line + 1, Constants.DelimitCountMisMatch));
                    }
                    else
                    {
                        var employee = ReadEmployee(employeeFields, line + 1, out string? err);
                        if (string.IsNullOrEmpty(err) && employee != null)
                        {
                            extractResponse.Employees.Add(employee);
                        }
                        else
                        {
                            extractResponse.Errors.Add(new Error(line + 1, err));
                            break;
                        }
                    }
                }
                return extractResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}


using System;
namespace DataExtract
{
    public class Validator
    {
        public Validator(Type t, string propertyName, string errorMessage, bool isCustom = false)
        {
            Type = t;
            ErrorMessage = errorMessage;
            IsCustom = isCustom;
            PropertyName = propertyName;
        }

        public string PropertyName { get; set; }
        public bool IsCustom { get; set; }
        public Type Type { get; set; }
        public string ErrorMessage { get; set; }
    }
}
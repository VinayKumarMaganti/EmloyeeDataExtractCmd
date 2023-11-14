using System;
namespace DataExtract
{
    public class Error
    {
        public Error(int lnNumber, string msg)
        {

            LineNumber = lnNumber;
            Message = msg;
        }
        public int LineNumber { get; set; }
        public string Message { get; set; }
    }
}


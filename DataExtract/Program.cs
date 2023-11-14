using DataExtract;
using Newtonsoft.Json;

if (args.Length < 2)
{
    Console.WriteLine("Missing arguments");
    Environment.Exit(0);
}

if (!string.IsNullOrEmpty(args[0]) && File.Exists(args[0]))
{
    try    {
        var dataExtractObj = new DataExtractBusiness();
        var extractResponse  = dataExtractObj.ExtractFile(args[0]);
        if(extractResponse.Errors.Count > 0)
        {
            var error = JsonConvert.SerializeObject(extractResponse.Errors);
            Console.WriteLine(error);
        }
        else
        {
            var employeeList = JsonConvert.SerializeObject(extractResponse.Employees);
            Console.WriteLine(employeeList);

            if (!File.Exists(args[1]))
                File.Create(args[1]);

            File.WriteAllText(args[1], employeeList);
        }
    }
    catch(Exception ex)
    {
        Console.Write(ex.Message);
    }
}
else
{
    Console.WriteLine("Invalid File Path");
}
Console.Read();

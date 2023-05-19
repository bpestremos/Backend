using Backend.Data.Tables;
using System.ComponentModel.DataAnnotations;

namespace Backend.Extras;
public class Validations
{
    public ReturnList ValidateEmployee(Employees employees)
    {
        var list = new ReturnList();
        list.messages = new List<string>();

        if (string.IsNullOrEmpty(employees.FirstName) || string.IsNullOrEmpty(employees.LastName))
            list.messages.Add("FirstName/LastName must not be null!");

        if (!employees.Email.Contains("@") || !employees.Email.EndsWith(".com"))
            list.messages.Add("Invalid email format!");

        if (employees.City.All(char.IsDigit) || employees.Province.All(char.IsDigit) || employees.Country.All(char.IsDigit))
            list.messages.Add("Only letters are allowed in City/Province/Country!");


        if (list.messages.Count > 0)
            list.ErrorMessage = "Validation failed!";
        else
            list.ErrorMessage = "Validation passed! Record Added!";

        return list;
    }



    public class ReturnList 
    {
        public string ErrorMessage { get; set; }
        public List<string> messages { get; set; }
    }
}

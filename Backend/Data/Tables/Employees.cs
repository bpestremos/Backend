using Backend.Extras;
using System.ComponentModel.DataAnnotations;

namespace Backend.Data.Tables;


public class Employees : ColumnExtensions
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
    public string FirstName { get; set; }
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
    public string LastName { get; set; }
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
    public string MiddleName { get; set; }
    public string Description { get; set; }
    [RegularExpression("[^0-9]", ErrorMessage = "UPRN must be numeric")]
    public long Phone { get; set; }
    [RegularExpression("[^0-9]", ErrorMessage = "UPRN must be numeric")]
    public long PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
    public string Province { get; set; }
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
    public string Country { get; set; }
}

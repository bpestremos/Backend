using Backend.Data.DTO;
using Backend.Data.Tables;
using static Backend.Extras.Validations;

namespace Backend.Interface
{
    public interface ICMSService
    {
        List<Employees> GetEmployees();
        ReturnList CreateEmployee(EmployeesDto employees);
        EmployeesDto UpdateEmployee(EmployeesDto employees);
        int DeleteEmployee(int id);
    }
}

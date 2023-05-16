using Backend.Models;

namespace Backend.Interface
{
    public interface ICMSService
    {
        List<string> GetCMS();
        List<Employees> GetEmployees();
        EmployeesDto CreateEmployee(EmployeesDto employees);
        EmployeesDto UpdateEmployee(EmployeesDto employees);
        int DeleteEmployee(int id);
    }
}

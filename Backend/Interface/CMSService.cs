using Backend.Models;
using Backend.Data;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Backend.Interface
{
    public class CMSService : ICMSService
    {
        private readonly CMSDbContext _context;
        public CMSService(CMSDbContext context)
        {
            _context = context;
        }

        public List<string> GetCMS()
        {
            var rng = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                rng.Add(i.ToString());
            }

            return rng;
        }


        public List<Employees> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public EmployeesDto CreateEmployee(EmployeesDto employees)
        {
            if (employees == null)
            {
                return new EmployeesDto();
            };

            var newEmployee = new Employees
            {
                EmployeeId = employees.EmployeeId,
                Address = employees.Address,
                City = employees.City,
                Country = employees.Country,
                Description = employees.Description,
                Email = employees.Email,
                Name = employees.Name,
                Phone = employees.Phone,
                PhoneNumber = employees.PhoneNumber,
                PostalCode = employees.PostalCode,
                Region = employees.Region,
                CreatedBy = "brian",
                DateCreated = DateTime.Now,
            };

            _context.Employees.Add(newEmployee);
            _context.SaveChanges();

            return employees;

        }

        public EmployeesDto UpdateEmployee(EmployeesDto employees)
        {
            var allEmployee = GetEmployees();
            var employeeById = allEmployee.Find(q => q.Id == employees.Id);
            if (employeeById == null)
            {
                return new EmployeesDto();
            };

            employeeById.Address = employees.Address;
            employeeById.City = employees.City;
            employeeById.Country = employees.Country;
            employeeById.Description = employees.Description;
            employeeById.Email = employees.Email;
            employeeById.Name = employees.Name;
            employeeById.Phone = employees.Phone;
            employeeById.PhoneNumber = employees.PhoneNumber;
            employeeById.PostalCode = employees.PostalCode;
            employeeById.Region = employees.Region;
            employeeById.DateUpdated = DateTime.Now;
            employeeById.UpdatedBy = "brian";

            _context.SaveChanges();

            return employees;

        }

        public int DeleteEmployee(int id)
        {
            try
            {
                var allEmployee = GetEmployees();
                var employeeById = allEmployee.Find(q => q.Id == id);

                if (employeeById == null)
                    return 0;


                employeeById.IsDeleted = true;
                employeeById.DeletedBy = "brian";
                employeeById.DateDeleted = DateTime.Now;

                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

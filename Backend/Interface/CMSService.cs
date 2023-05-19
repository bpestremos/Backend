using Backend.Data;
using Backend.Extras;
using Microsoft.Identity.Client;
using System.Text;
using Backend.Data.Tables;
using Backend.Data.DTO;

namespace Backend.Interface
{
    public class CMSService : Validations, ICMSService
    {
        private readonly CMSDbContext _context;
        private Validations _validations;
        private readonly ILogger<CMSService> _logger;
        public CMSService(CMSDbContext context, ILogger<CMSService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Employees> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public ReturnList CreateEmployee(EmployeesDto employees)
        {
            var returnList = new ReturnList();
            if (employees == null)
            {
                returnList.messages.Add("No data to process.");
                return returnList;
            };

            var newEmployee = new Employees
            {
                EmployeeId = employees.EmployeeId,
                Address = employees.Address,
                City = employees.City,
                Description = employees.Description,
                Email = employees.Email,
                FirstName = employees.FirstName,
                LastName = employees.LastName,
                MiddleName = employees.MiddleName,
                Phone = employees.Phone,
                PhoneNumber = employees.PhoneNumber,
                PostalCode = employees.PostalCode,
                Region = employees.Region,
                Province = employees.Province,
                Country = employees.Country,
                CreatedBy = "brian",
                DateCreated = DateTime.Now,
            };

            var list = _validations.ValidateEmployee(newEmployee);

            if (list.messages.Count > 0)
            {
                throw new Exception(list.ErrorMessage);
            }

            _context.Employees.Add(newEmployee);
            _context.SaveChanges();

            return list;

        }

        public EmployeesDto UpdateEmployee(EmployeesDto employees)
        {
            var employeeById = GetEmployees().ToList().Find(q => q.Id == employees.Id);
            if (employeeById == null)
                return new EmployeesDto();

            employeeById.Address = employees.Address;
            employeeById.City = employees.City;
            employeeById.Description = employees.Description;
            employeeById.Email = employees.Email;
            employeeById.FirstName = employees.FirstName;
            employeeById.LastName = employees.LastName;
            employeeById.MiddleName = employees.MiddleName;
            employeeById.Phone = employees.Phone;
            employeeById.PhoneNumber = employees.PhoneNumber;
            employeeById.PostalCode = employees.PostalCode;
            employeeById.Region = employees.Region;
            employeeById.Province = employees.Province;
            employeeById.Country = employees.Country;
            employeeById.DateUpdated = DateTime.Now;
            employeeById.UpdatedBy = "brian";
            
            _context.SaveChanges();

            return employees;

        }

        public int DeleteEmployee(int id)
        {
            var employeeById = GetEmployees().ToList().Find(q => q.Id == id);

            if (employeeById == null)
                throw new Exception("No record to delete!");

            try
            {
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

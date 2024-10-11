using simpleWebCoreAPI.Data;
using simpleWebCoreAPI.Models;

namespace simpleWebCoreAPI.Repositories
{
    public class EmployeeService : IEmployeeRepository
    {
        readonly EmployeeContext _employeeContext;

        public EmployeeService(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public void Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            _employeeContext.Employees.Remove(entity);
            _employeeContext.SaveChanges();
        }

        public Employee? Get(long id)
        {
            return _employeeContext.Employees
                  .FirstOrDefault(e => e.EmployeeId == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }

        public void Update(Employee entity)
        {
            var employee = _employeeContext.Employees.Find(entity.EmployeeId);
            if (employee is not null)
            {
                employee.FirstName = entity.FirstName;
                employee.LastName = entity.LastName;
                employee.Email = entity.Email;
                employee.DateOfBirth = entity.DateOfBirth;
                employee.PhoneNumber = entity.PhoneNumber;
                _employeeContext.SaveChanges();
            }
        }
    }
}

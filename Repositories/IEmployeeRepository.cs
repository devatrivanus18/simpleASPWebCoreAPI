using simpleWebCoreAPI.Models;

namespace simpleWebCoreAPI.Repositories;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll();
    Employee? Get(long id);
    void Add(Employee entity);
    void Update(Employee entity);
    void Delete(Employee entity);
}

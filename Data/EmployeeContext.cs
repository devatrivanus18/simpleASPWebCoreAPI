using Microsoft.EntityFrameworkCore;
using simpleWebCoreAPI.Models;
using System.Collections.Generic;

namespace simpleWebCoreAPI.Data;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions options)
        : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }
}

﻿using Microsoft.AspNetCore.Mvc;
using simpleWebCoreAPI.Models;
using simpleWebCoreAPI.Repositories;

namespace simpleWebCoreAPI.Controllers;

[Route("api/employee")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _dataRepository;
    public EmployeeController(IEmployeeRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }
    // GET: api/Employee
    [HttpGet]
    public IActionResult Get()
    {
        IEnumerable<Employee> employees = _dataRepository.GetAll();
        return Ok(employees);
    }
    // GET: api/Employee/5
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(long id)
    {
        Employee employee = _dataRepository.Get(id);
        if (employee == null)
        {
            return NotFound("The Employee record couldn't be found.");
        }
        return Ok(employee);
    }
    // POST: api/Employee
    [HttpPost]
    public IActionResult Post([FromBody] Employee employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee is null.");
        }
        _dataRepository.Add(employee);
        return CreatedAtRoute(
              "Get",
              new { Id = employee.EmployeeId },
              employee);
    }
    // PUT: api/Employee/5
    [HttpPut("{id}")]
    public IActionResult Put([FromBody] Employee employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee is null.");
        }
        Employee employeeToUpdate = _dataRepository.Get(employee.EmployeeId);
        if (employeeToUpdate == null)
        {
            return NotFound("The Employee record couldn't be found.");
        }
        _dataRepository.Update(employee);
        return NoContent();
    }
    // DELETE: api/Employee/5
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        Employee employee = _dataRepository.Get(id);
        if (employee == null)
        {
            return NotFound("The Employee record couldn't be found.");
        }
        _dataRepository.Delete(employee);
        return NoContent();
    }
}

using CompaniesApp.API.Data;
using CompaniesApp.API.Data.DTOs;
using CompaniesApp.API.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //Marrim te gjithe punonjesit nga databaza
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployeesFromDb = FakeDb.EmployeesDb.ToList();
            return Ok(allEmployeesFromDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employeeFromDb = FakeDb.EmployeesDb.FirstOrDefault(x => x.Id == id);

            if (employeeFromDb == null)
            {
                return NotFound($"Employee with id = {id} not found");
            } else
            {
                return Ok(employeeFromDb);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeById(int id)
        {
            var employeeFromDb = FakeDb.EmployeesDb.FirstOrDefault(x => x.Id == id);

            if(employeeFromDb == null)
            {
                return NotFound($"Employee with id = {id} not found");
            } else
            {
                FakeDb.EmployeesDb.Remove(employeeFromDb);

                var latestList = FakeDb.EmployeesDb.ToList();
                return Ok($"Employee with id = {id} was removed");
            }
        }

        [HttpPost]
        public IActionResult PostEmployee([FromBody]PostEmployeeDto payload)
        {
            //1. Krijohet objekti
            var newEmployee = new Employee()
            {
                //Generate Id for new employee 10-99
                Id = new Random().Next(10, 100),

                FirstName = payload.FirstName,
                LastName = payload.LastName,
                DOB = payload.DOB,
                Role = payload.Role
            };

            //2. Shtohet objekti ne DB
            FakeDb.EmployeesDb.Add(newEmployee);

            return Ok("PostEmployee");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromBody] PutEmployeeDto newData, int id)
        {
            //1. Merr te dhenat e vjetra nga db
            var employeeFromDb = FakeDb.EmployeesDb.FirstOrDefault(x => x.Id == id);

            if(employeeFromDb == null)
            {
                return NotFound("Employee could not be updated");
            }

            //2. Perditeso te dhenat
            employeeFromDb.FirstName = newData.FirstName;
            employeeFromDb.LastName = newData.LastName;
            employeeFromDb.DOB = newData.DOB;
            employeeFromDb.Role = newData.Role;

            //3. Ruaj te ne database


            return Ok("Employee updated");
        }
    }
}

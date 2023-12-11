using CompaniesApp.API.Data;
using CompaniesApp.API.Data.DTOs;
using CompaniesApp.API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private AppDbContext _dbContext;
        public EmployeesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Marrim te gjithe punonjesit nga databaza
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployeesFromDb = _dbContext.Employees.ToList();
            return Ok(allEmployeesFromDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employeeFromDb = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
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
            var employeeFromDb = _dbContext.Employees.FirstOrDefault(x => x.Id == id);

            if(employeeFromDb == null)
            {
                return NotFound($"Employee with id = {id} not found");
            } else
            {
                _dbContext.Employees.Remove(employeeFromDb);
                _dbContext.SaveChanges();

                return Ok($"Employee with id = {id} was removed");
            }
        }

        [HttpPost]
        public IActionResult PostEmployee([FromBody]PostEmployeeDto payload)
        {
            //1. Krijohet objekti
            var newEmployee = new Employee()
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                DOB = payload.DOB,
                Role = payload.Role,
                Email = payload.Email
            };

            //2. Shtohet objekti ne DB
            _dbContext.Employees.Add(newEmployee);
            _dbContext.SaveChanges();

            return Ok("PostEmployee");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromBody] PutEmployeeDto newData, int id)
        {
            //1. Merr te dhenat e vjetra nga db
            var employeeFromDb = _dbContext.Employees.FirstOrDefault(x => x.Id == id);

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
            _dbContext.Update(employeeFromDb);
            _dbContext.SaveChanges();

            return Ok("Employee updated");
        }
    }
}

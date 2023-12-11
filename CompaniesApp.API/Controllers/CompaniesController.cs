using CompaniesApp.API.Data;
using CompaniesApp.API.Data.DTOs;
using CompaniesApp.API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private AppDbContext _dbContext;
        public CompaniesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            var companiesDb = _dbContext.Companies.ToList();
            return Ok(companiesDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var companyDb = _dbContext.Companies.FirstOrDefault(x => x.Id == id);
            
            if(companyDb == null)
            {
                return NotFound($"Company with id = {id} not found");
            } else
            {
                return Ok(companyDb);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCompanyById(int id)
        {
            var companyDb = _dbContext.Companies.FirstOrDefault(x => x.Id == id);

            if(companyDb == null)
            {
                return NotFound($"Company with id = {id} not found");
            } else
            {
                _dbContext.Companies.Remove(companyDb);
                _dbContext.SaveChanges();

                return Ok($"Company with id = {id} was removed");
            }
        }

        [HttpPost]
        public IActionResult PostCompany([FromBody]PostCompanyDto payload)
        {
            //1. Krijohet objekti
            var newEmployee = new Company()
            {
                Name = payload.Name,
                EstablishedYear = payload.EstablishedYear
            };

            //2. Shtohet objekti ne DB
            _dbContext.Companies.Add(newEmployee);
            _dbContext.SaveChanges();

            //3. Kthehet pergjigja
            return Ok("New employee created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompanyById(int id, [FromBody]PutCompanyDto payload)
        {
            var companyDb = _dbContext.Companies.FirstOrDefault(x => x.Id == id);

            if(companyDb == null)
            {
                return NotFound($"Company with id = {id} not found");
            } else
            {
                companyDb.Name = payload.Name;
                companyDb.EstablishedYear = payload.EstablishedYear;

                _dbContext.Companies.Update(companyDb);
                _dbContext.SaveChanges();

                return Ok($"Company with id = {id} was updated");
            }
        }
    }
}

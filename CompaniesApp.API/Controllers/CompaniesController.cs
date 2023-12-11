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
        //Marrim te gjitha kompanite nga databaza
        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            var companiesDb = FakeDb.CompaniesDb.ToList();

            return Ok(companiesDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var companyDb = FakeDb.CompaniesDb.FirstOrDefault(x => x.Id == id);

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
            var companyDb = FakeDb.CompaniesDb.FirstOrDefault(x => x.Id == id);
            if(companyDb == null)
            {
                return NotFound($"Company with id = {id} not found");
            } else
            {
                FakeDb.CompaniesDb.Remove(companyDb);
                return Ok($"Company with id = {id} was removed");
            }
        }

        [HttpPost]
        public IActionResult PostCompany([FromBody]PostCompanyDto payload)
        {
            //1. Krijohet objekti
            var newEmployee = new Company()
            {
                //Generate Id for new employee 10-99
                Id = new Random().Next(10, 100),
                Name = payload.Name,
                EstablishedYear = payload.EstablishedYear,
            };

            //2. Shtohet objekti ne DB
            FakeDb.CompaniesDb.Add(newEmployee);

            //3. Kthehet pergjigja
            return Ok("New employee created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompanyById(int id, [FromBody]PutCompanyDto payload)
        {
            var companyDb = FakeDb.CompaniesDb.FirstOrDefault(x => x.Id == id);

            if(companyDb == null)
            {
                return NotFound($"Company with id = {id} not found");
            } else
            {
                companyDb.Name = payload.Name;
                companyDb.EstablishedYear = payload.EstablishedYear;

                return Ok($"Company with id = {id} was updated");
            }
        }
    }
}

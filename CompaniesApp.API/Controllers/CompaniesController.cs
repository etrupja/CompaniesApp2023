using CompaniesApp.API.Data;
using CompaniesApp.API.Data.DTOs;
using CompaniesApp.API.Data.Models;
using Microsoft.AspNetCore.Http;
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
            var companiesDb = FakeDb.GetAllCompanies();

            return Ok(companiesDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var companyDb = new Company()
            {
                Name = "Microsoft",
                EstablishedYear = 1975,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
            return Ok(companyDb);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCompanyById(int id)
        {
            var companyDb = new Company();

            return Ok("Company was deleted");
        }

        [HttpPost]
        public IActionResult PostCompany([FromBody]PostCompanyDto payload)
        {
            //Shtohet kompania ne database
            var companyName = payload.Name;

            return Ok("Company was added");
        }
    }
}

using CompaniesApp.API.Data;
using CompaniesApp.API.Data.DTOs;
using CompaniesApp.API.Data.Models;
using CompaniesApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    { 
        private ICompaniesService _companiesService;
        public CompaniesController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            var companiesDb = _companiesService.GetCompanies();
            return Ok(companiesDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var companyDb = _companiesService.GetCompanyById(id);
            
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
            _companiesService.DeleteCompanyById(id);

            return Ok("Deleted");
        }

        [HttpPost]
        public IActionResult PostCompany([FromBody]PostCompanyDto payload)
        {
            _companiesService.PostCompany(payload);

            return Ok("New employee created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompanyById(int id, [FromBody]PutCompanyDto payload)
        {
            _companiesService.UpdateCompany(id, payload);

            return Ok("Updated");
        }
    }
}

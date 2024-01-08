using CompaniesApp.API.Data;
using CompaniesApp.API.Data.DTOs;
using CompaniesApp.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CompaniesApp.API.Services
{
    public class CompaniesService : ICompaniesService
    {
        private AppDbContext _dbContext;
        public CompaniesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            var allCompanies = await _dbContext.Companies.ToListAsync();
            return allCompanies;
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            var companyFromDb = await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            return companyFromDb;
        }

        public async Task PostCompanyAsync(PostCompanyDto company)
        {
            //1. Krijohet objekti
            var newCompany = new Company()
            {
                Name = company.Name,
                EstablishedYear = company.EstablishedYear
            };

            await _dbContext.Companies.AddAsync(newCompany);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Company> UpdateCompanyAsync(int id, PutCompanyDto company)
        {
            var companyFromDb = await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);

            if(companyFromDb != null)
            {
                companyFromDb.Name = company.Name;
                companyFromDb.EstablishedYear = company.EstablishedYear;

                await _dbContext.SaveChangesAsync();
            }

            return companyFromDb;
        }

        public async Task DeleteCompanyByIdAsync(int id)
        {
            var companyFromDb = await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);

            if (companyFromDb != null)
            {
                _dbContext.Companies.Remove(companyFromDb);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

using CompaniesApp.API.Data;
using CompaniesApp.API.Data.DTOs;
using CompaniesApp.API.Data.Models;

namespace CompaniesApp.API.Services
{
    public class CompaniesService : ICompaniesService
    {
        private AppDbContext _dbContext;
        public CompaniesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCompanyById(int id)
        {
            var companyFromDb = _dbContext.Companies.FirstOrDefault(x => x.Id == id);

            if(companyFromDb != null)
            {
                _dbContext.Companies.Remove(companyFromDb);
                _dbContext.SaveChanges();
            }
        }

        public List<Company> GetCompanies()
        {
            var allCompanies = _dbContext.Companies.ToList();
            return allCompanies;
        }

        public Company GetCompanyById(int id)
        {
            var companyFromDb = _dbContext.Companies.FirstOrDefault(x => x.Id == id);
            return companyFromDb;
        }

        public void PostCompany(PostCompanyDto company)
        {
            //1. Krijohet objekti
            var newCompany = new Company()
            {
                Name = company.Name,
                EstablishedYear = company.EstablishedYear
            };

            _dbContext.Companies.Add(newCompany);
            _dbContext.SaveChanges();
        }

        public Company UpdateCompany(int id, PutCompanyDto company)
        {
            var companyFromDb = _dbContext.Companies.FirstOrDefault(x => x.Id == id);

            if(companyFromDb != null)
            {
                companyFromDb.Name = company.Name;
                companyFromDb.EstablishedYear = company.EstablishedYear;

                _dbContext.SaveChanges();
            }

            return companyFromDb;
        }
    }
}

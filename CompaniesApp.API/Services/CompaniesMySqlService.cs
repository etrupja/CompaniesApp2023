using CompaniesApp.API.Data;
using CompaniesApp.API.Data.Models;

namespace CompaniesApp.API.Services
{
    public class CompaniesMySqlService : ICompaniesService
    {
        private AppDbContext _dbContext;
        public CompaniesMySqlService(AppDbContext dbContext)
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

        public void PostCompany(Company company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
        }

        public Company UpdateCompany(int id, Company company)
        {
            var companyFromDb = _dbContext.Companies.FirstOrDefault(x => x.Id == id);

            if(companyFromDb != null)
            {
                companyFromDb.Name = company.Name;
                companyFromDb.Address = company.Address;
                companyFromDb.EstablishedYear = company.EstablishedYear;

                _dbContext.SaveChanges();
            }

            return companyFromDb;
        }
    }
}

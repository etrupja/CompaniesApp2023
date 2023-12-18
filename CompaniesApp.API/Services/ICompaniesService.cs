using CompaniesApp.API.Data.DTOs;
using CompaniesApp.API.Data.Models;

namespace CompaniesApp.API.Services
{
    public interface ICompaniesService
    {
        List<Company> GetCompanies();
        Company GetCompanyById(int id);
        void PostCompany(PostCompanyDto company);
        Company UpdateCompany(int id, PutCompanyDto company);
        void DeleteCompanyById(int id);

    }
}

using CompaniesApp.API.Data.DTOs;
using CompaniesApp.API.Data.Models;

namespace CompaniesApp.API.Services
{
    public interface ICompaniesService
    {
        Task<List<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task PostCompanyAsync(PostCompanyDto company);
        Task<Company> UpdateCompanyAsync(int id, PutCompanyDto company);
        Task DeleteCompanyByIdAsync(int id);
    }
}

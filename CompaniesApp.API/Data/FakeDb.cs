using CompaniesApp.API.Data.Models;

namespace CompaniesApp.API.Data
{
    public static class FakeDb
    {
        public static List<Company> CompaniesDb = new List<Company>()
        {
            new Company()
            {
                Id = 1,
                Name = "Microsoft",
                EstablishedYear = 1975,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Company()
            {
                Id = 2,
                Name = "Apple",
                EstablishedYear = 1976,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Company()
            {
                Id = 3,
                Name = "Google",
                EstablishedYear = 1998,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Company()
            {
                Id = 4,
                Name = "Amazon",
                EstablishedYear = 1994,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Company()
            {
                Id = 5,
                Name = "Facebook",
                EstablishedYear = 2004,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Company()
            {
                Id = 6,
                Name = "Twitter",
                EstablishedYear = 2006,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Company()
            {
                Id = 7,
                Name = "Uber",
                EstablishedYear = 2009,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Company()
            {
                Id = 8,
                Name = "Airbnb",
                EstablishedYear = 2008,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
        };

        public static List<Company> GetAllCompanies()
        {
            return CompaniesDb;
        }
    }
}

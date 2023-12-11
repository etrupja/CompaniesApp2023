using CompaniesApp.API.Data.Base;

namespace CompaniesApp.API.Data.Models
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public int EstablishedYear { get; set; }

        public string Address { get; set; }
    }
}

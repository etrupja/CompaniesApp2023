using CompaniesApp.API.Data.Base;

namespace CompaniesApp.API.Data.Models
{
    public class Employee : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}

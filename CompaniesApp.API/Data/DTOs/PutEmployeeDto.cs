namespace CompaniesApp.API.Data.DTOs
{
    public class PutEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Role { get; set; }
    }
}

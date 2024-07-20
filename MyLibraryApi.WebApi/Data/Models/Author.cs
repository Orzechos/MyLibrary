namespace MyLibraryApi.WebApi.Data.Models
{
    public record Author
    {
        public Guid Id { get; set; } = new Guid();

        public string FirstName { get; set; } = "Author First Name";
        public string LastName { get; set; } = "Author Last Name";
    }
}

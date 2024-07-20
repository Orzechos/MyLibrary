using System.ComponentModel.DataAnnotations;

namespace MyLibraryApi.WebApi.Data.Models
{
    public record User
    {
        [Required]
        [MinLength(5)]
        public string LoginName { get; set; } = "User Login Name";
        [MinLength(5)]
        public string Password { get; set; } = "User Password";

        public string Mail { get; set; } = "User Email";
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyLibraryApi.WebApi.Data.Models
{
    public record Book
    {
        public Guid Id { get; set; } = new Guid();

        [Required]
        [MinLength(5)]
        public string Name { get; set; } = "Book Name";
        [Required]
        [MinLength(5)]   
        
        public Author Autor { get; set; } = new Author();

        public bool IsAvailable { get; set; } = true;

        [HiddenInput(DisplayValue = false)]
        public bool IsDeleted { get; internal set; } = false;
    }
}

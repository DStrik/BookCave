using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BookCave.Models.InputModels
{
    public class BookModifyInputModel
    {
        [Required]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required!")]
        [RegularExpression("^(97(8|9))?\\d{9}(\\d|X)$", ErrorMessage = "Invalid ISBN!")]
        public string Isbn { get; set; }

        [Required(ErrorMessage = "Author is required!")]
        public List<int> Author { get; set; }

        [Required(ErrorMessage = "Genre is required!")]
        public List<int> Genre { get; set; }

        [Required(ErrorMessage = "Publisher is required!")]
        public int? Publisher { get; set; }

        [Required(ErrorMessage = "Descripton is required!")]
        public string Description { get; set; }

        public byte[] CurrentCoverImage { get; set; }

        public IFormFile NewCoverImage { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Type is required!")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Publishing Year is required!")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900-2100")]
        public int? PublishingYear { get; set; }

        [Required(ErrorMessage = "Font is required!")]
        public string Font { get; set; }
        
        public int? PageCount { get; set; }

        public int? Length { get; set; }
    }
}
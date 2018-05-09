using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BookCave.Models.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        public IFormFile NewImage { get; set; }
        public byte[] Image { get; set; }
    }
}
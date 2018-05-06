using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace BookCave.Models.InputModels
{
    public class BookInputModel
    {
       public string Title { get; set; }
       public int Isbn { get; set; }
       public List<int> Author { get; set; }
       public List<int> Genre { get; set; }
       public int PublisherId { get; set; } 
       public string Description { get; set; }
       public IFormFile CoverImage { get; set; }
       public double Price { get; set; }
       public string Type { get; set; }
       public int PublishingYear { get; set; }
       public string Font { get; set; }
       public int PageCount { get; set; }
       public int Length { get; set; }
    }
}
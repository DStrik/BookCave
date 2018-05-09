using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class PublisherInputModel
    {

        [Required(ErrorMessage="Publisher's name is missing")]
        public string Name { get; set; }
    }
}
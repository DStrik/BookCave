using System.Collections.Generic;

namespace BookCave.Models.InputModels
{
    public class SearchInputModel
    {
        public string Title { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<int> GenreIds { get; set; }
    }
}
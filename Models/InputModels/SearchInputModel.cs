using System.Collections.Generic;

namespace BookCave.Models.InputModels
{
    public class SearchInputModel
    {
        public string Title { get; set; }
        public int? Isbn { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<int> GenreIds { get; set; }
        public List<int> PublisherIds { get; set; }
        public List<string> Types { get; set; }
    }
}
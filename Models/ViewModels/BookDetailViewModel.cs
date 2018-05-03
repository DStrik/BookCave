using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public List<AuthorViewModel> Author { get; set; }
        public PublisherViewModel Publisher { get; set; }
        public GenreViewModel Genre { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public string CoverImage { get; set; }
        public int PbIsbn { get; set; }
        public int PbPublishingYear { get; set; }
        public string PbFont { get; set; }
        public int PbPageCount { get; set; }
        public int PbQuantity { get; set; }
        public double PbPrice { get; set; }
        public int HcIsbn { get; set; }
        public int HcPublishingYear { get; set; }
        public string HcFont { get; set; }
        public int HcPageCount { get; set; }
        public int HcQuantity { get; set; }
        public double HcPrice { get; set; }
        public int AbIsbn { get; set; }
        public int AbPublishingYear { get; set; }
        public int AbAudioLength { get; set; }
        public double AbPrice { get; set; }
        public int EbIsbn { get; set; }
        public int EbPublishingYear { get; set; }
        public int EbPageCount { get; set; }
        public double EbPrice { get; set; }

    }
}
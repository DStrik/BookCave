using System.Collections.Generic;

namespace BookCave.Models.InputModels
{
    public class BookInputModel
    {
       public string Title { get; set; }
       public List<int> Author { get; set; }
       public List<int> Genre { get; set; }
       public int Publisher { get; set; } 
       public string Description { get; set; }
       public List<string> Image { get; set; }
       public string CoverImage { get; set; }
       public int PbIsbn { get; set; }
       public int PbPublishingYear { get; set; }
       public string PbFont { get; set; }   
       public int PbPageCount { get; set; }
       public double PbPrice { get; set; }
       public int HcIsbn { get; set; }
       public int HcPublishingYear { get; set; }
       public string HcFont { get; set; }   
       public int HcPageCount { get; set; }
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
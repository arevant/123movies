using System.Collections.Generic;

namespace Movies.Core.Models
{
    public class MoviesList
    {
        public int Id { get; set; }
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public string Plot { get; set; }
        public ListingStatus ListingStatus { get; set; }
        public string ImdbRating { get; set; }
        public string Poster { get; set; }
        public List<string> Stills { get; set; }
        public List<string> SoundEffects { get; set; }
    }
}
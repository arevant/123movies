using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Core.Models
{
    public class MovieDetails
    {
        [Key]
        public int Id { get; set; }
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public string Plot { get; set; }
        public ListingStatus ListingStatus { get; set; }
        public string ImdbRating { get; set; }
        public string Poster { get; set; }
        public string Stills { get; set; }
        public string SoundEffects { get; set; }
    }
}
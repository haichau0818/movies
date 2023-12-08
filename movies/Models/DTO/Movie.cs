using System.ComponentModel.DataAnnotations;

namespace movies.Models.DTO
{
    public class Movie
    {
        public int Id { get; set; }
        [Required, StringLength(500)]
        public string? Title { get; set; }
        [StringLength(4)]
        public string? ReleaseYear { get; set; }
        [StringLength(int.MaxValue)]
        public string? MovieImage { get; set; }
        [Required, StringLength(500)]
        public string? Cast { get; set; }
        [Required, StringLength(500)]
        public string? Director { get; set; }
    }
}

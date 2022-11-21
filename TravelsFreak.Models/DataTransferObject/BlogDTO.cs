using System.ComponentModel.DataAnnotations;
using TravelsFreak.Data;

namespace TravelsFreak.Models.DataTransferObject
{
    public class BlogDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter description...")]
        public string? BlogDescription { get; set; }

        [Required(ErrorMessage = "please enter description...")]
        public string? BlogImageUrl { get; set; }

        [Required(ErrorMessage = "please enter description...")]
        public string? BlogTittle { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter destination...")]
        public int DestinationsId { get; set; }
        public Destinations? Destinations { get; set; }
    }
}

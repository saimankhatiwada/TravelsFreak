using System.ComponentModel.DataAnnotations;

namespace TravelsFreak.Models.DataTransferObject
{
    public class DestinationsDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Destination Tittle is required.....")]
        public string? DestinationTittle { get; set; }

        [Required(ErrorMessage = "Location is required.....")]
        public string? Location { get; set; }
    }
}

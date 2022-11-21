using System.ComponentModel.DataAnnotations;

namespace TravelsFreak.Data
{
    public class Destinations
    {
        [Key]
        public int Id { get; set; }

        public string? DestinationTittle { get; set; }

        public string? Location { get; set; }
    }
}

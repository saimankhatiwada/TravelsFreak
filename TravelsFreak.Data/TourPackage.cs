using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelsFreak.Data
{
    public class TourPackage
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public int Days { get; set; }
        public string? TourPackageDescription { get; set; }
        public string? TourPackageLocation { get; set; }
        public string? TourPackageImageUrl { get; set; }
        public int DestinationsId { get; set; }
        [ForeignKey("DestinationsId")]
        public Destinations? Destinations { get; set; }
    }
}

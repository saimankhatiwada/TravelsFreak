using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelsFreak.Data
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        public string? BlogDescription { get; set; }
        public string? BlogImageUrl { get; set; }
        public string? BlogTittle { get; set; }
        public int DestinationsId { get; set; }
        [ForeignKey("DestinationsId")]
        public Destinations? Destinations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

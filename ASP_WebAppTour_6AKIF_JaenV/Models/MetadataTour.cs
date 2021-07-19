using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_WebAppTour_6AKIF_JaenV.Models
{
    [MetadataType(typeof(MetadataTour))]
    public partial class Tour
    {
    }

        public class MetadataTour
    {
        [Required]
        [Display(Name = "Tourname")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 60 characters.")]
        public string To_Bezeichnung { get; set; }

    }



}
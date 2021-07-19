using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_WebAppTour_6AKIF_JaenV.Models
{
    [MetadataType(typeof(MetadataFremdenfuehrer))]
    public partial class Fremdenfuehrer
    {

    }

        public class MetadataFremdenfuehrer
    {
        [Required]
        [Display(Name = "Vorname")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters.")]
        public string F_Vorname { get; set; }

        [Required]
        [Display(Name = "Nachnamename")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters.")]
        public string F_Nachname { get; set; }

        [Display(Name = "Toursprache")]
        public Nullable<short> F_S_Sprach_Id { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_WebAppTour_6AKIF_JaenV.Models
{
    [MetadataType(typeof(MetadataTreffpunkt))]

    public partial class Treffpunkt
    {

    }
    public class MetadataTreffpunkt
    {
        [Required]
        [Display(Name = "Strasse")]
        [StringLength(120, ErrorMessage = "Name must be 120 characters.")]
        public string T_Strasse { get; set; }
        
        [Display(Name = "Hausnummer")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 10 characters.")]
        public string T_Hausnr { get; set; }

        [Required]
        [Display(Name = "Stadt")]
        [StringLength(30, ErrorMessage = "Name must be max. 30 characters.")]
        public string T_Ort { get; set; }
        
        [Display(Name = "PLZ")]
        [StringLength(10, ErrorMessage = "Name must be max. 10 characters.")]
        public string T_PLZ { get; set; }

        [Display(Name = "Gesamtpreis")]
        public Nullable<int> T_B_Buchung_Id { get; set; }

        [Required]
        [Display(Name = "Tourbezeichnung")]
        public Nullable<short> T_To_Tour_Id { get; set; }
    }
}
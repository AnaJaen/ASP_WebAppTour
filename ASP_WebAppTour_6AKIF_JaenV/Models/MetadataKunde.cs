using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_WebAppTour_6AKIF_JaenV.Models
{
   
    [MetadataType(typeof(MetadataKunde))]
    
    public partial class Kunde
    {
        public string Name
        {
            get { return this.K_Vorname + "  " + this.K_Nachname ; }
            
        }

        public string Anschrift
        {
            get { return this.K_Strasse + "  " + this.K_Hausnr; }

        }
    }

        

        public class MetadataKunde
    {
        [Required]
        [Display(Name = "Vorname")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 25 characters.")]
        public string K_Vorname { get; set; }

        [Required]
        [Display(Name = "Nachname")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 30 characters.")]
        public string K_Nachname { get; set; }

        [Display(Name = "Geburtsdatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> K_GebDatum { get; set; }

        [Display(Name = "Anschrift")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Anschrift must be between 4 and 30 characters.")]
        public string K_Strasse { get; set; }

        [Display(Name = "Hausnummer")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Hausnummer must be between 1 and 10 characters.")]
        public string K_Hausnr { get; set; }

        [Display(Name = "Stadt")]
        [StringLength(30, ErrorMessage = "Stadt must be max. 30 characters.")]
        public string K_Ort { get; set; }

        [Display(Name = "Land")]
        [StringLength(30, ErrorMessage = "Land must be max. 30 characters.")]
        public string K_Land { get; set; }

        [Display(Name = "PLZ / CP")]
        [StringLength(30, ErrorMessage = "Land must be max. 10 characters.")]
        public string K_PLZ { get; set; }

        [Display(Name = "E-Mail")]
        [StringLength(50, ErrorMessage = "e-Mail must be max. 50 characters.")]
        public string K_Email { get; set; }


    }
}
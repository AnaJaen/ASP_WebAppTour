using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_WebAppTour_6AKIF_JaenV.Models
{
    [MetadataType(typeof(MetadataBuchung))]

    public partial class Buchung
    {
       
    }

    public class MetadataBuchung
    {
        [Required]
        [Display(Name = "Buchungsdatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> B_Datum { get; set; }

        [Display(Name = "Personen")]
        public Nullable<int> B_Personenanzahl { get; set; }

        [Display(Name = "Gesamtpreis")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Gesamtpreis must be between 2 and 50 characters.")]
        public string B_Preis { get; set; }

        [Required]
        [Display(Name = "Kundenname")]
        public Nullable<int> B_K_Kunde_Id { get; set; }

        [Required]
        [Display(Name = "Tourname")]
        public Nullable<short> B_To_Tour_Id { get; set; }

        [Display(Name = "Fremdenführer")]
        public Nullable<short> B_F_Fremdenfuehrer_Id { get; set; }

        [Display(Name = "Toursprache")]
        public Nullable<short> B_S_Sprach_Id { get; set; }

        [Display(Name = "Treffpunkt")]
        public Nullable<int> B_T_Treffpunkt_Id { get; set; }

    }


}
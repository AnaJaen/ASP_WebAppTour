using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_WebAppTour_6AKIF_JaenV.Models
{
    public class LoginModel
    {
        // 3 properties: string UserName, string Passwort und bool RememberMe

        [Required]
        [Display(Name = "Benutzer")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Passwort")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
using ASP_WebAppTour_6AKIF_JaenV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASP_WebAppTour_6AKIF_JaenV.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            Kunde klogin;
            Fremdenfuehrer flogin;

            if (ModelState.IsValid)
            {
                using (var db = new Tour_DBEntities())
                {
                    var erg1 = from k in db.Kundes
                               where k.K_Nachname == model.UserName && k.K_Vorname == model.Password
                               select k;


                    var erg2 = from f in db.Fremdenfuehrers
                               where f.F_Nachname == model.UserName && f.F_Vorname == model.Password
                               select f;

                    klogin = erg1.FirstOrDefault();
                    flogin = erg2.FirstOrDefault();

                }

                if (klogin != null)
                {

                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    Session["loginidk"] = klogin.K_Kunde_Id;
                    return RedirectToLocal(returnUrl);  // Url  ?? "~/Home/Index"
                }
                else
                {
                    if (flogin != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        Session["loginidf"] = flogin.F_Fremdenfuehrer_Id;
                        Session["Isadmin"] = flogin.F_Admin;
                        return RedirectToLocal(returnUrl);  // Url  ?? "~/Home/Index"
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid username or password.");
                    }
                    
                }
            }



            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["loginidk"] = null;
            Session["loginidf"] = null;
            Session["Isadmin"] = null;
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }








    }
}

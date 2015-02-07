using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using MvcCompleto.Models.ViewModel;

namespace MvcCompleto.Controllers
{
   public class LoginController:Controller
    {
       public ActionResult Index()
       {
           return View(new UsuarioView());
       }
       [HttpPost]
       public ActionResult Index(UsuarioView model,String returnUrl="/")
       {
           if (Membership.ValidateUser(model.Login, model.Password))
           {
               FormsAuthentication.RedirectFromLoginPage(model.Login,false);
               return null;
           }

           ModelState.AddModelError("","Login Incorrecto");

           return View(model);
       }

       public ActionResult Logout()
       {
           Session.Clear();
          FormsAuthentication.SignOut();
           return RedirectToAction("Index");
       }
    }
}

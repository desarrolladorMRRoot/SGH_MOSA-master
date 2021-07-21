using DIServer.Connector;
using DIServer.Connector.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIServer.Models;

namespace SGH_MOSA.Controllers
{
    public class UserController : Controller
    {
        string DISessionId = (System.Web.HttpContext.Current.Session["DISSessionID"] != null) ? System.Web.HttpContext.Current.Session["DISSessionID"] as string : null;
        DISSession DISession = new DISSession();


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            //There is other ways to store the route
            System.Web.HttpContext.Current.Session["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection userForm)
        {
            string urls = (System.Web.HttpContext.Current.Session["ReturnUrl"]).ToString();


            //Recibo los datos y creo la session con los datos de usuario
            UsersManager UManager = new UsersManager(DISession);
            User user = UManager.IsAutentic(userForm["UserName"], userForm["UserPassword"]);
            if (user != null)
            {
                System.Web.HttpContext.Current.Session["UserSession"] = user;
                return 
                    Redirect(System.Web.HttpContext.Current.Session["ReturnUrl"].ToString());
            }

            return View("Login");

        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult GetLogOut()
        {
           
            //System.Web.HttpContext.Current.Session.Abandon();
            // System.Web.HttpContext.Current.User = null;
            //System.Web.Security.FormsAuthentication.SignOut(); // if forms auth is used
            if (DISession.Start(DISessionId))
            {
                DISession.Off2(DISessionId);
                System.Web.HttpContext.Current.Session.Clear();
                
                   return RedirectToAction("Login", "User");

            }
            return RedirectToAction("Index", "Home");
            //return Redirect(System.Web.HttpContext.Current.Session["ReturnUrl"].ToString());

        }


    }
}

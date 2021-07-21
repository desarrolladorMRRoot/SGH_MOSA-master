using DIServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SGH_MOSA.Filters
{
    public class AuthSAP : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public AuthSAP(params string[] roles)
        {
            this.allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (User)HttpContext.Current.Session["UserSession"]; // checking active users with allowed roles.  

            if (user != null)
            {
                foreach (var roleAlowed in allowedroles)
                {
                    if (user.Role == roleAlowed)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }  
    }
}
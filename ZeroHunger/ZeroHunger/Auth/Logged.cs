using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ZeroHunger.Auth
{
    public class Logged : AuthorizeAttribute  
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["user"] == null)
            {
                return false;
            }
            return true;
        }
    }
}
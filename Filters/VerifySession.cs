using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaCRUD.Models;
using System.Web.Mvc;

namespace TiendaCRUD.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var oUsuario = (usuario)HttpContext.Current.Session["User"];
                base.OnActionExecuting(filterContext);
                if (filterContext.HttpContext.Session["User"] == null)
                {
                    if (filterContext.Controller is Controllers.AccessController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Access/Index");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "Controller", "Access" }, { "Action", "Index" } });
            }
        }   
    }
}
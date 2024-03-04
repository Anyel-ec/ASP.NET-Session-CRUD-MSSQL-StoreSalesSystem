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
                var oUsuario = (usuarios)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {
                    // si no hay usuario en la sesion
                    if (filterContext.Controller is Controllers.AccessController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Access/Index");
                    }
                }
                else
                {
                    // si hay usuario en la sesion
                    if (filterContext.Controller is Controllers.AccessController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Home/Index");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaCRUD.Models;

namespace TiendaCRUD.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string usuario, string clave)
        {
            try
            {
                using (dotnetEntities db = new dotnetEntities())
                {
                    var lst = from d in db.usuarios
                              where (d.usuario == usuario || d.correo == usuario) && d.clave == clave
                              select d;

                    if (lst.Count() > 0)
                    {
                        usuarios oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario o clave incorrecta");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }

        public ActionResult CloseSession()
        {
            Session["User"] = null;
            return RedirectToAction("Index");
        }
    }
}
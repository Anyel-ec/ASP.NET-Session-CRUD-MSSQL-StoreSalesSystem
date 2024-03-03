using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaCRUD.Models;
using TiendaCRUD.Models.TableViewModel;

namespace TiendaCRUD.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (dotnetEntities db = new dotnetEntities())
            {
                lst = (from d in db.usuarios
                       select new UserTableViewModel
                       {
                           Nombre = d.usuario,
                           Correo = d.correo
                       }).ToList();
            }
            return View(lst);

              
            }
        }
    }

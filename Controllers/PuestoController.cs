using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaCRUD.Models;
using TiendaCRUD.Models.ViewModels;

namespace TiendaCRUD.Controllers
{
    public class PuestoController : Controller
    {
        // GET: Puesto
        public ActionResult Index()
        {
            List<ListPuestoViewModel> listPuestoViewModels
                ;
            using (dotnetEntities db = new dotnetEntities())
            {
                listPuestoViewModels = (from d in db.puesto
                                                        
                                                                              select new ListPuestoViewModel
                                                                              {
                        id_puesto = d.id_puesto,
                        nombre = d.nombre
                    }).ToList();
            }
            return View(listPuestoViewModels);


        }
    }
}
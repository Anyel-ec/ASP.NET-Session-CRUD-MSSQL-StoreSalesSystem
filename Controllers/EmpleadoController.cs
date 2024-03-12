using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaCRUD.Models;
using TiendaCRUD.Models.ViewModels;

namespace TiendaCRUD.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<ListEmpleadoViewModel> listaEmpleado;
            using (dotnetEntities db = new dotnetEntities())
            {
                listaEmpleado = (from d in db.empleado
                                 where d.eliminado == false
                                 select new ListEmpleadoViewModel
                                 {
                                     id_empleado = d.id_empleado,
                                     nombre = d.nombre,
                                     apellido = d.apellido,
                                     telefono = d.telefono,
                                     cedula = d.cedula,
                                     eliminado = d.eliminado,
                                     id_puesto = d.id_puesto
                                 }).ToList();
            }
            return View(listaEmpleado);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(EmpleadoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dotnetEntities db = new dotnetEntities())
                    {
                        var oEmpleado = new empleado();
                        oEmpleado.nombre = model.nombre;
                        oEmpleado.apellido = model.apellido;
                        oEmpleado.telefono = model.telefono;
                        oEmpleado.cedula = model.cedula;
                        oEmpleado.eliminado = false;
                        oEmpleado.id_puesto = model.id_puesto;
                        db.empleado.Add(oEmpleado);
                        db.SaveChanges();
                    }
                    return Redirect("~/Empleado/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            EmpleadoViewModel model = new EmpleadoViewModel();
            using (dotnetEntities db = new dotnetEntities())
            {
                var oEmpleado = db.empleado.Find(id);
                model.id_empleado = oEmpleado.id_empleado;
                model.nombre = oEmpleado.nombre;
                model.apellido = oEmpleado.apellido;
                model.telefono = oEmpleado.telefono;
                model.cedula = oEmpleado.cedula;
                model.id_puesto = oEmpleado.id_puesto;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
               using (dotnetEntities db = new dotnetEntities())
            {
                var oEmpleado = db.empleado.Find(id);
                oEmpleado.eliminado = true;
                db.SaveChanges();
            }
            return Redirect("~/Empleado/Index");
        }
    }
}
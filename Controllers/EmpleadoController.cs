﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                                 join p in db.puesto on d.id_puesto equals p.id_puesto
                                 where d.eliminado == false
                                 select new ListEmpleadoViewModel
                                 {
                                     id_empleado = d.id_empleado,
                                     nombre = d.nombre,
                                     apellido = d.apellido,
                                     telefono = d.telefono,
                                     cedula = d.cedula,
                                     eliminado = d.eliminado,
                                     nombre_puesto = p.nombre // Nombre del puesto en lugar de ID
                                 }).ToList();
            }
            return View(listaEmpleado);
        }


        public ActionResult Nuevo()
        {
            using (dotnetEntities db = new dotnetEntities())
            {
                var puestos = db.puesto.ToList().Select(p => new SelectListItem { Value = p.id_puesto.ToString(), Text = p.nombre }).ToList();
                ViewBag.Puestos = puestos;
            }
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
                using (dotnetEntities db = new dotnetEntities())
                {
                    var puestos = db.puesto.ToList().Select(p => new SelectListItem { Value = p.id_puesto.ToString(), Text = p.nombre }).ToList();
                    ViewBag.Puestos = puestos;
                }
                return View();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            using (dotnetEntities db = new dotnetEntities())
            {
                var oEmpleado = db.empleado.Find(id);
                if (oEmpleado == null)
                {
                    return HttpNotFound();
                }

                var model = new EmpleadoViewModel
                {
                    id_empleado = oEmpleado.id_empleado,
                    nombre = oEmpleado.nombre,
                    apellido = oEmpleado.apellido,
                    telefono = oEmpleado.telefono,
                    cedula = oEmpleado.cedula,
                    id_puesto = oEmpleado.id_puesto
                };

                var puestos = db.puesto.ToList().Select(p => new SelectListItem { Value = p.id_puesto.ToString(), Text = p.nombre }).ToList();
                ViewBag.Puestos = puestos;

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Editar(EmpleadoViewModel model)
        {
            using (dotnetEntities db = new dotnetEntities())

                try
                {

                if (ModelState.IsValid)
                {
                    {
                        var oEmpleado = db.empleado.Find(model.id_empleado);
                        if (oEmpleado == null)
                        {
                            return HttpNotFound();
                        }

                        oEmpleado.nombre = model.nombre;
                        oEmpleado.apellido = model.apellido;
                        oEmpleado.telefono = model.telefono;
                        oEmpleado.cedula = model.cedula;
                        oEmpleado.id_puesto = model.id_puesto;

                        db.Entry(oEmpleado).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                var puestos = db.puesto.ToList().Select(p => new SelectListItem { Value = p.id_puesto.ToString(), Text = p.nombre }).ToList();
                ViewBag.Puestos = puestos;

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaCRUD.Models;
using TiendaCRUD.Models.ViewModels;

namespace TiendaCRUD.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ListClienteViewModel> listClienteViewModels;
            using (dotnetEntities db = new dotnetEntities())
            {
                listClienteViewModels = (from d in db.cliente
                                         where d.eliminado == false
                                            select new ListClienteViewModel
                                            {
                                            id_cliente = d.id_cliente,
                                            nombre = d.nombre,
                                            apellido = d.apellido,
                                            direccion = d.direccion,
                                            telefono = d.telefono,
                                            cedula = d.cedula,
                                            eliminado = d.eliminado
                                        }).ToList();
            }
            return View(listClienteViewModels);
        }

        public ActionResult Nuevo()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Nuevo(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dotnetEntities db = new dotnetEntities())
                    {
                        var oCliente = new cliente();
                        oCliente.nombre = model.nombre;
                        oCliente.apellido = model.apellido;
                        oCliente.direccion = model.direccion;
                        oCliente.telefono = model.telefono;
                        oCliente.cedula = model.cedula;
                        oCliente.eliminado = false;
                        db.cliente.Add(oCliente);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Index");
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
            ClienteViewModel model = new ClienteViewModel();
            using (dotnetEntities db = new dotnetEntities())
            {
                var oCliente = db.cliente.Find(id);
                model.nombre = oCliente.nombre;
                model.apellido = oCliente.apellido;
                model.direccion = oCliente.direccion;
                model.telefono = oCliente.telefono;
                model.cedula = oCliente.cedula;
                model.id_cliente = oCliente.id_cliente;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dotnetEntities db = new dotnetEntities())
                    {
                        var oCliente = db.cliente.Find(model.id_cliente);
                        oCliente.nombre = model.nombre;
                        oCliente.apellido = model.apellido;
                        oCliente.direccion = model.direccion;
                        oCliente.telefono = model.telefono;
                        oCliente.cedula = model.cedula;
                        db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }

    

}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaCRUD.Models;
using TiendaCRUD.Models.ViewModels;

namespace TiendaCRUD.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            List<ListPedidoViewModel> listaPedidos;
            using (dotnetEntities db = new dotnetEntities())
            {
                listaPedidos = (from d in db.pedido
                                join c in db.cliente on d.id_cliente equals c.id_cliente
                                join e in db.empleado on d.id_empleado equals e.id_empleado
                                join ep in db.estado_pedido on d.id_estado_pedido equals ep.id_estado_pedido
                                select new ListPedidoViewModel
                                {
                                    id_pedido = d.id_pedido,
                                    id_cliente = d.id_cliente,
                                    nombre_cliente = c.nombre,
                                    id_empleado = d.id_empleado,
                                    nombre_empleado = e.nombre,
                                    id_estado_pedido = d.id_estado_pedido,
                                    nombre_estado_pedido = ep.nombre,
                                    total = d.total
                                }).ToList();
            }
            return View(listaPedidos);
        }

        public ActionResult Nuevo()
        {
            using (dotnetEntities db = new dotnetEntities())
            {
                var clientes = db.cliente.ToList().Select(c => new SelectListItem { Value = c.id_cliente.ToString(), Text = c.nombre }).ToList();
                ViewBag.Clientes = clientes;
                var empleados = db.empleado.ToList().Select(e => new SelectListItem { Value = e.id_empleado.ToString(), Text = e.nombre }).ToList();
                ViewBag.Empleados = empleados;
                var estados = db.estado_pedido.ToList().Select(ep => new SelectListItem { Value = ep.id_estado_pedido.ToString(), Text = ep.nombre }).ToList();
                ViewBag.Estados = estados;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PedidoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dotnetEntities db = new dotnetEntities())
                    {
                        var oPedido = new pedido();
                        oPedido.id_cliente = model.id_cliente;
                        oPedido.id_empleado = model.id_empleado;
                        oPedido.id_estado_pedido = model.id_estado_pedido;
                        oPedido.total = model.total;
                        db.pedido.Add(oPedido);
                        db.SaveChanges();
                    }
                    return Redirect("~/Pedido/Index");
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
           
            using (dotnetEntities db = new dotnetEntities())
            {
                var oPedido = db.pedido.Find(id);
                if (oPedido == null)
                {
                    return HttpNotFound();
                }

                var model = new PedidoViewModel
                {
                    id_pedido = oPedido.id_pedido,
                    id_cliente = oPedido.id_cliente,
                    id_empleado = oPedido.id_empleado,
                    id_estado_pedido = oPedido.id_estado_pedido,
                    total = oPedido.total
                };

                var clientes = db.cliente.ToList().Select(c => new SelectListItem { Value = c.id_cliente.ToString(), Text = c.nombre }).ToList();
                ViewBag.Clientes = clientes;
                var empleados = db.empleado.ToList().Select(e => new SelectListItem { Value = e.id_empleado.ToString(), Text = e.nombre }).ToList();
                ViewBag.Empleados = empleados;
                var estados = db.estado_pedido.ToList().Select(ep => new SelectListItem { Value = ep.id_estado_pedido.ToString(), Text = ep.nombre }).ToList();
                ViewBag.Estados = estados;

                return View(model);

            }
        }

        [HttpPost]
        public ActionResult Editar(PedidoViewModel model)
        {
            using (dotnetEntities db = new dotnetEntities())

                try
                {

                if (ModelState.IsValid)
                    {
                        {
                        var oPedido = db.pedido.Find(model.id_pedido);
                        if (oPedido == null)
                            {
                            return HttpNotFound();
                        }
                        oPedido.id_cliente = model.id_cliente;
                        oPedido.id_empleado = model.id_empleado;
                        oPedido.id_estado_pedido = model.id_estado_pedido;
                        oPedido.total = model.total;
                        db.Entry(oPedido).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Pedido/Index");
                }
                var clientes = db.cliente.ToList().Select(c => new SelectListItem { Value = c.id_cliente.ToString(), Text = c.nombre }).ToList();
                ViewBag.Clientes = clientes;
                var empleados = db.empleado.ToList().Select(e => new SelectListItem { Value = e.id_empleado.ToString(), Text = e.nombre }).ToList();
                    ViewBag.Empleados = empleados;
                var estados = db.estado_pedido.ToList().Select(ep => new SelectListItem { Value = ep.id_estado_pedido.ToString(), Text = ep.nombre }).ToList();
                    ViewBag.Estados = estados;
                return View(model);
            }
            catch (Exception ex)
                {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (dotnetEntities db = new dotnetEntities())
            {
                var oPedido = db.pedido.Find(id);
                db.pedido.Remove(oPedido);
                db.SaveChanges();
            }
            return Redirect("~/Pedido/Index");
        }
    }
}
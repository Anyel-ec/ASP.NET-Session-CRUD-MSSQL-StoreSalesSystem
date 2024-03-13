using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaCRUD.Models;
using TiendaCRUD.Models.ViewModels;

namespace TiendaCRUD.Controllers
{
    public class DetallePedidoController : Controller
    {
        // GET: DetallePedido
        public ActionResult Index()
        {
            List<ListDetallePedidoViewModel> listaDetallePedido;
            using (dotnetEntities db = new dotnetEntities())
            {
                listaDetallePedido = ( from d in db.detalle_pedido
                                       join p in db.producto on d.id_producto equals p.id_producto
                                       select new ListDetallePedidoViewModel
                                       {
                                           id_detalle_pedido = d.id_detalle_pedido,
                                           id_pedido = d.id_pedido,
                                           id_producto = d.id_producto,
                                           nombre_producto = p.nombre,
                                           cantidad = d.cantidad,
                                           subtotal = d.subtotal
                                       }).ToList();
            }
            return View(listaDetallePedido);
        }

        public ActionResult Nuevo()
        {
            using (dotnetEntities db = new dotnetEntities())
            {
                var pedidos = db.pedido.ToList().Select(p => new SelectListItem { Value = p.id_pedido.ToString(), Text = p.id_pedido.ToString() }).ToList();
                ViewBag.Pedidos = pedidos;
                var productos = db.producto.ToList().Select(p => new SelectListItem { Value = p.id_producto.ToString(), Text = p.nombre }).ToList();
                ViewBag.Productos = productos;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(DetallePedidoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dotnetEntities db = new dotnetEntities())
                    {
                        var oDetallePedido = new detalle_pedido();
                        oDetallePedido.id_pedido = model.id_pedido;
                        oDetallePedido.id_producto = model.id_producto;
                        oDetallePedido.cantidad = model.cantidad;
                        oDetallePedido.subtotal = model.subtotal;
                        db.detalle_pedido.Add(oDetallePedido);
                        db.SaveChanges();
                    }
                    return Redirect("~/DetallePedido/Index");
                }
                using (dotnetEntities db = new dotnetEntities())
                {
                    var pedidos = db.pedido.ToList().Select(p => new SelectListItem { Value = p.id_pedido.ToString(), Text = p.id_pedido.ToString() }).ToList();
                    ViewBag.Pedidos = pedidos;
                    var productos = db.producto.ToList().Select(p => new SelectListItem { Value = p.id_producto.ToString(), Text = p.nombre }).ToList();
                    ViewBag.Productos = productos;
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
                var oDetallePedido = db.detalle_pedido.Find(id);
                if (oDetallePedido == null)
                {
                    return HttpNotFound();
                }
                var model = new DetallePedidoViewModel
                {
                    id_detalle_pedido = oDetallePedido.id_detalle_pedido,
                    id_pedido = oDetallePedido.id_pedido,
                    id_producto = oDetallePedido.id_producto,
                    cantidad = oDetallePedido.cantidad,
                    subtotal = oDetallePedido.subtotal
                };

                var pedidos = db.pedido.ToList().Select(p => new SelectListItem { Value = p.id_pedido.ToString(), Text = p.id_pedido.ToString() }).ToList();
                ViewBag.Pedidos = pedidos;
                var productos = db.producto.ToList().Select(p => new SelectListItem { Value = p.id_producto.ToString(), Text = p.nombre }).ToList();
                ViewBag.Productos = productos;
                return View(model);

            }
              
        }

        [HttpPost]
        public ActionResult Editar(DetallePedidoViewModel model)
        {
            using (dotnetEntities db = new dotnetEntities())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        {
                            var oDetallePedido = db.detalle_pedido.Find(model.id_detalle_pedido);
                            if (oDetallePedido == null)
                            {
                                return HttpNotFound();
                            }
                            
                            
                            oDetallePedido.id_pedido = model.id_pedido;
                            oDetallePedido.id_producto = model.id_producto;
                            oDetallePedido.cantidad = model.cantidad;
                            oDetallePedido.subtotal = model.subtotal;
                            db.Entry(oDetallePedido).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        return Redirect("~/DetallePedido/");

                    }
                    
                        var pedidos = db.pedido.ToList().Select(p => new SelectListItem { Value = p.id_pedido.ToString(), Text = p.id_pedido.ToString() }).ToList();
                        ViewBag.Pedidos = pedidos;
                        var productos = db.producto.ToList().Select(p => new SelectListItem { Value = p.id_producto.ToString(), Text = p.nombre }).ToList();
                        ViewBag.Productos = productos;
                    return View();

                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                using (dotnetEntities db = new dotnetEntities())
                {
                    var oDetallePedido = db.detalle_pedido.Find(id);
                    db.detalle_pedido.Remove(oDetallePedido);
                    db.SaveChanges();
                }
                return Redirect("~/DetallePedido/");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }   
    }
}
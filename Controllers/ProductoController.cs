using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaCRUD.Models;
using TiendaCRUD.Models.ViewModels;

namespace TiendaCRUD.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ListProductoViewModel> listaProductos;
            using (dotnetEntities db = new dotnetEntities())
            {
                listaProductos = (from d in db.producto
                                   where d.eliminado == false
                                      select new ListProductoViewModel
                                      {
                                      id_producto = d.id_producto,
                                      codigo_producto = d.codigo_producto,
                                      descripcion = d.descripcion,
                                      nombre = d.nombre,
                                      precio = d.precio,
                                      eliminado = d.eliminado
                                  }).ToList();
            }
            return View(listaProductos);
        }
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dotnetEntities db = new dotnetEntities())
                    {
                        var oProducto = new producto();
                        oProducto.codigo_producto = model.codigo_producto;
                        oProducto.descripcion = model.descripcion;
                        oProducto.nombre = model.nombre;
                        oProducto.precio = model.precio;
                        oProducto.eliminado = false;
                        db.producto.Add(oProducto);
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/");
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
            ProductoViewModel model = new ProductoViewModel();
            using (dotnetEntities db = new dotnetEntities())
            {
                var oProducto = db.producto.Find(id);
                model.id_producto = oProducto.id_producto;
                model.codigo_producto = oProducto.codigo_producto;
                model.descripcion = oProducto.descripcion;
                model.nombre = oProducto.nombre;
                model.precio = oProducto.precio;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dotnetEntities db = new dotnetEntities())
                    {
                        var oProducto = db.producto.Find(model.id_producto);
                        oProducto.codigo_producto = model.codigo_producto;
                        oProducto.descripcion = model.descripcion;
                        oProducto.nombre = model.nombre;
                        oProducto.precio = model.precio;
                        db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/");
                }
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
                var oProducto = db.producto.Find(id);
                oProducto.eliminado = true;
                db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect("~/Producto/");
        }
    }
}
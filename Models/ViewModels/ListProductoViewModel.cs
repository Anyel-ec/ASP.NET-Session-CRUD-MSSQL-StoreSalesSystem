using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaCRUD.Models.ViewModels
{
    public class ListProductoViewModel
    {
        public int id_producto { get; set; }
        public Nullable<int> codigo_producto { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> precio { get; set; }
        public Nullable<bool> eliminado { get; set; }

    }
}
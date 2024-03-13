using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaCRUD.Models.ViewModels
{
    public class ListDetallePedidoViewModel
    {
        public int id_detalle_pedido { get; set; }
        public Nullable<int> id_pedido { get; set; }
        public Nullable<int> id_producto { get; set; }
        public string nombre_producto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> subtotal { get; set; }

        public virtual pedido pedido { get; set; }
        public virtual producto producto { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaCRUD.Models.ViewModels
{
    public class DetallePedidoViewModel
    {
        public int id_detalle_pedido { get; set; }
        public Nullable<int> id_pedido { get; set; }
        public Nullable<int> id_producto { get; set; }
        public string nombre_producto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public Nullable<int> cantidad { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El subtotal debe ser mayor a 0")]
        public Nullable<decimal> subtotal { get; set; }

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaCRUD.Models.ViewModels
{
    public class PedidoViewModel
    {
        public int id_pedido { get; set; }
        [Required]
        public Nullable<int> id_cliente { get; set; }

        
        public string nombre_cliente { get; set; } // Cambiado de id_puesto a nombre_puesto


        public Nullable<int> id_empleado { get; set; }
       
        public string nombre_empleado { get; set; } // Cambiado de id_puesto a nombre_puesto
        public Nullable<int> id_estado_pedido { get; set; }
        public string nombre_estado_pedido { get; set; } // Cambiado de id_puesto a nombre_puesto


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El subtotal debe ser mayor a 0")]
        public Nullable<decimal> total { get; set; }
    }
}
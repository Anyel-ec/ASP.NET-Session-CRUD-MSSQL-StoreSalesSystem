using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaCRUD.Models.ViewModels
{
    public class ListClienteViewModel
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string cedula { get; set; }
        public Nullable<bool> eliminado { get; set; }
    }
}
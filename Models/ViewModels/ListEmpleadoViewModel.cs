using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaCRUD.Models.ViewModels
{
    public class ListEmpleadoViewModel
    {
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string cedula { get; set; }
        public Nullable<bool> eliminado { get; set; }
        public Nullable<int> id_puesto { get; set; }
        public string nombre_puesto { get; set; } // Cambiado de id_puesto a nombre_puesto

        // Si deseas mantener la propiedad virtual de 'puesto' puedes dejarla como está
        public virtual puesto puesto { get; set; }


    }
}
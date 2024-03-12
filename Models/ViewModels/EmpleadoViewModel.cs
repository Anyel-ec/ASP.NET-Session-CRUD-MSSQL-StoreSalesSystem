using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaCRUD.Models.ViewModels
{
    public class EmpleadoViewModel
    {
        public int id_empleado { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        // validar que el telefono sea de 10 digitos y dar un mensaje de error si no lo es
        [StringLength(10)
        public string telefono { get; set; }
        [Required]
        [Display(Name = "Cédula")]
        // validar que la cedula sea de 10 digitos 
        [StringLength(10)]
        public string cedula { get; set; }
        public Nullable<bool> eliminado { get; set; }
        public Nullable<int> id_puesto { get; set; }

    }
}
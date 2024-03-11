using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaCRUD.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int id_cliente { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Required]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }
        [Required]
        [Display(Name = "Cédula")]
        public string cedula { get; set; }
        public Nullable<bool> eliminado { get; set; }
    }
}
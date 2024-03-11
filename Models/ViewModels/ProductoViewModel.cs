using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaCRUD.Models.ViewModels
{
    public class ProductoViewModel
    {
        
        public int id_producto { get; set; }
        [Required]
        [Display(Name = "codigo_producto")]
        [Range(0, 1000000, ErrorMessage = "El codigo debe ser mayor a 0")]
        public Nullable<int> codigo_producto { get; set; }
        [Required]
        [Display(Name = "descripcion")]
        [StringLength(50, ErrorMessage = "La descripcion no puede tener mas de 50 caracteres")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "nombre")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "precio")]
        [Range(0, 1000000, ErrorMessage = "El precio debe ser mayor a 0")]
        public Nullable<decimal> precio { get; set; }
        public Nullable<bool> eliminado { get; set; }   
    }
}
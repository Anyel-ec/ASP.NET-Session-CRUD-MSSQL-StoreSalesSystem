//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaCRUD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            this.detalle_pedido = new HashSet<detalle_pedido>();
        }
    
        public int id_producto { get; set; }
        public Nullable<int> codigo_producto { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> precio { get; set; }
        public Nullable<bool> eliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_pedido> detalle_pedido { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CRUD_en_asp_.net.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        [Display (Name = "Nombre de Producto")]
        public string NombreProducto { get; set; }
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set;}
        [Display(Name = "Cantidad en stock")]
        public string EndStock { get; set;}
        public string Precio { get; set;}
        [Display(Name = "Fecha de Creacion")]
        public DateTime FechaCreacion { get; set;}
    }
}

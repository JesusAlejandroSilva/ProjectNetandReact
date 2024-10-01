using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Posicion { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}

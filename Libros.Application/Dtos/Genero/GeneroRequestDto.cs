using System.ComponentModel.DataAnnotations;

namespace Libros.Application.Dtos.Genero
{
    public class GeneroRequestDto
    {
        [StringLength(25)]
        public string Nombre { get; set; }
    }
}

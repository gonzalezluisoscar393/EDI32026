using Libros.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Libros.Entitties
{
    public class Autor: IEntidad
    {
        public Autor()
        {
            AutoresPorLibros = new HashSet<AutorPorLibro>();
        }
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public virtual ICollection<AutorPorLibro> AutoresPorLibros { get; set; }
    }
}

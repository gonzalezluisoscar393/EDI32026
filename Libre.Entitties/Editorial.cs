using Libros.Abstractions;

namespace Libros.Entitties
{
    public class Editorial : IEntidad
    {
        public Editorial()
        {
            Libros = new HashSet<Libro>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
    }
}

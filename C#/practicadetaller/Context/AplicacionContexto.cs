using Microsoft.EntityFrameworkCore;
using practicadetaller.Models;

namespace practicadetaller.Context
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto(DbContextOptions<AplicacionContexto>options): base(options) { }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Universidad> Universidad { get; set; }
        public DbSet<Materia> Materia { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace practicadetaller.Models
{
    public class Materia
    {
        [Key]
        public int idMateria { get; set; }
        public string Nombre { get; set; }
        public int idDocente { get; set; }

    }
}
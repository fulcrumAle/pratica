using System.ComponentModel.DataAnnotations;

namespace practicadetaller.Models
{
    public class Universidad
    {
        [Key]
        public int idUniversidad { get; set; }
        public string Nombre { get; set; }
    }
}

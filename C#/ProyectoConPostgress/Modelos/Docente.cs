using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConPostgress.Modelos
{
    public class Docente
    {
        public int idDocente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ubicacion { get; set; }
        public bool Sexo { get; set; }
        public string CI { get; set; }
    }
}

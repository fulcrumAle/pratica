﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConPostgress.Modelos
{
    public class Estudiante
    {
        public int idEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public bool Sexo { get; set; }

    }
}

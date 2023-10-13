using System;
using System.Threading;
using ProyectoConPostgress.Conector;
using ProyectoConPostgress.Controlador;
using ProyectoConPostgress.Modelos;
using ProyectoConPostgress.Modelos;

namespace ProyectoConPostgress
{
    public class Program {
        public static void Main()
        {
            Estudiante estudiante1 = new Estudiante() { idEstudiante = 9, Nombre = "Adrian", Edad = 18, Ubicacion = "mis huevos" };
            EstudianteController estudianteController = new EstudianteController();
            Estudiante estudianteun = estudianteController.create(estudiante1);
            estudianteController.delete(1);

            List<Estudiante> estudiantes = estudianteController.get();
            for (int i = 0; i < estudiantes.Count; i++)
            {
                Console.WriteLine("El codigo es: " + estudiantes[i].idEstudiante);
                Console.WriteLine("El nombre es: "+estudiantes[i].Nombre);
                Console.WriteLine("La edad es: " + estudiantes[i].Edad);
                Console.WriteLine("La ubicacion es: " + estudiantes[i].Ubicacion);
            }
        }
    }
}
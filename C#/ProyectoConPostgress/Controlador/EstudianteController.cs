using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoConPostgress.Conector;
using Microsoft.AspNetCore.Mvc;
using ProyectoConPostgress.Modelos;
using Npgsql;

namespace ProyectoConPostgress.Controlador
{
    [Route("api/[controller")]
    [ApiController]
    public class EstudianteController
    {
        private string db = Conexion.conexionConPostgress();
        [HttpGet]
        public List<Estudiante> get()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            string select = "SELECT * FROM PUBLIC.\"Estudiante\"";
            using NpgsqlConnection connection = new NpgsqlConnection(db);
            try
            {
                connection.Open();
                Console.WriteLine("Conexión obtenida");
                NpgsqlCommand command = new NpgsqlCommand(select, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Estudiante estudiante = new Estudiante();
                        estudiante.idEstudiante = int.Parse(reader.GetValue(0).ToString());
                        estudiante.Nombre = reader.GetValue(1).ToString();
                        estudiante.Apellido = reader.GetValue(1).ToString();
                        estudiante.Edad = int.Parse(reader.GetValue(2).ToString());
                        estudiante.Sexo = bool.Parse(reader.GetValue(3).ToString());

                        estudiantes.Add(estudiante);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return estudiantes;
        }
        [HttpPost]
        public Estudiante create([FromBody] Estudiante estudiante)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            string select = "INSERT INTO PUBLIC.\"Estudiante\"(\r\n\t\"idEstudiante\", Nombre, Apellido, Edad, Sexo)\r\n\tVALUES (@idEstudiante, @Nombre, @Apellido, @Edad, @Sexo);";
            using (NpgsqlConnection connection = new NpgsqlConnection(db))
            {
                NpgsqlCommand command = new NpgsqlCommand(select, connection);
                command.Parameters.AddWithValue("@idEstudiante", estudiante.idEstudiante);
                command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                command.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                command.Parameters.AddWithValue("@Edad", estudiante.Edad);
                command.Parameters.AddWithValue("@Sexo", estudiante.Sexo);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                return estudiante;
            }
        }
        [HttpDelete]
        public void delete(int idEstudiante)
        {
            string select = "DELETE FROM PUBLIC.\"Estudiante\" WHERE \"idEstudiante\" =" + idEstudiante + ";";

            using (NpgsqlConnection connection = new NpgsqlConnection(db))
            {
                NpgsqlCommand command = new NpgsqlCommand(select, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("Estudiante eliminado");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                
            }
        }
    }
}

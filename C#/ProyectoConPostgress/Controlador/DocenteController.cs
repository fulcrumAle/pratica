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
    public class DocenteController
    {
        private string db = Conexion.conexionConPostgress();
        [HttpGet]
        public List<Docente> get()
        {
            List<Docente> docentes = new List<Docente>();
            string select = "SELECT * FROM PUBLIC.\"Docente\"";
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
                        Docente docente = new Docente();
                        docente.idDocente = int.Parse(reader.GetValue(0).ToString());
                        docente.Nombre = reader.GetValue(1).ToString();
                        docente.Apellido = reader.GetValue(1).ToString();
                        docente.Ubicacion = reader.GetValue(2).ToString();
                        docente.Sexo = bool.Parse(reader.GetValue(3).ToString());
                        docente.CI = reader.GetValue(3).ToString();

                        docentes.Add(docente);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return docentes;
        }
        [HttpPost]
        public Docente create([FromBody] Docente docente)
        {
            List<Docente> docentes = new List<Docente>();
            string select = "INSERT INTO PUBLIC.\"Docentes\"(\r\n\t\"idDocente\", Nombre, Apellido, Ubicacion, Sexo, CI)\r\n\tVALUES (@idDocente, @Nombre, @Apellido, @Ubicacion, @Sexo, @CI);";
            using (NpgsqlConnection connection = new NpgsqlConnection(db))
            {
                NpgsqlCommand command = new NpgsqlCommand(select, connection);
                command.Parameters.AddWithValue("@idDocente", docente.idDocente);
                command.Parameters.AddWithValue("@Nombre", docente.Nombre);
                command.Parameters.AddWithValue("@Apellido", docente.Apellido);
                command.Parameters.AddWithValue("@Ubicacion", docente.Ubicacion);
                command.Parameters.AddWithValue("@Sexo", docente.Sexo);
                command.Parameters.AddWithValue("@CI", docente.CI);

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
                return docente;
            }
        }
        [HttpDelete]
        public void delete(int idDocente)
        {
            string select = "DELETE FROM PUBLIC.\"Docente\" WHERE \"idDocente\" =" + idDocente + ";";

            using (NpgsqlConnection connection = new NpgsqlConnection(db))
            {
                NpgsqlCommand command = new NpgsqlCommand(select, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("Docente eliminado");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }
        }
    }
}

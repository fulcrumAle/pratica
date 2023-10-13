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
    public class UniversidadController
    {
        private string db = Conexion.conexionConPostgress();
        [HttpGet]
        public List<Universidad> get()
        {
            List<Universidad> universidades = new List<Universidad>();
            string select = "SELECT * FROM PUBLIC.\"Universidad\"";
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
                        Universidad universidad = new Universidad();
                        universidad.idUniversidad = int.Parse(reader.GetValue(0).ToString());
                        universidad.Nombre = reader.GetValue(1).ToString();
                   
                        universidades.Add(universidad);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return universidades;
        }
        [HttpPost]
        public Universidad create([FromBody] Universidad universidad)
        {
            List<Universidad> universidades = new List<Universidad>();
            string select = "INSERT INTO PUBLIC.\"Universidad\"(\r\n\t\"idUniversidad\", Nombre)\r\n\tVALUES (@idUniversidad, @Nombre);";
            using (NpgsqlConnection connection = new NpgsqlConnection(db))
            {
                NpgsqlCommand command = new NpgsqlCommand(select, connection);
                command.Parameters.AddWithValue("@idUniversidad", universidad.idUniversidad);
                command.Parameters.AddWithValue("@Nombre", universidad.Nombre);
                

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
                return universidad;
            }
        }
        [HttpDelete]
        public void delete(int idUniversidad)
        {
            string select = "DELETE FROM PUBLIC.\"Universidad\" WHERE \"idUniversidad\" =" + idUniversidad + ";";

            using (NpgsqlConnection connection = new NpgsqlConnection(db))
            {
                NpgsqlCommand command = new NpgsqlCommand(select, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("Universidad eliminada");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }
        }
    }
}

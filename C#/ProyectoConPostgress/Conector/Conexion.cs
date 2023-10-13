using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ProyectoConPostgress.Conector { 

public class Conexion
{
    public static string conexionConPostgress()
    {
        Console.WriteLine("Se establecio la conexión...");
        var builder = new NpgsqlConnectionStringBuilder();
        builder.Host = "Localhost";
        builder.Username = "postgres";
        builder.Password="huevos1";
        builder.Database = "Universidad";
        Console.WriteLine(builder.ConnectionString);
        return builder.ConnectionString;
        /*using NpgsqlConnection connection=new NpgsqlConnection(builder.ConnectionString);
        try
        {
            connection.Open();
            Console.WriteLine("Conexión obtenida");
            NpgsqlCommand command = new NpgsqlCommand("Select version();",connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0));
                    }
                }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }*/
    }
    }

}

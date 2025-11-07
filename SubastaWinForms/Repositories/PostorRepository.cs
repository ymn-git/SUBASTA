using System;
using System.Collections.Generic;
using SubastaWinForms.Model.Entities;
using Microsoft.Data.Sqlite;

namespace SubastaWinForms.Repositories
{
    public class PostorRepository
    {
        private readonly string connectionString = "Data Source=subasta.db";

        public List<Postor> ObtenerTodos()
        {
            List<Postor> lista = new List<Postor>();

            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT Id, Nombre, Email, Contrasena, SubastaGanada FROM Postores";

                using (var cmd = new SqliteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Postor postor = new Postor(
                            reader["Nombre"].ToString() ?? string.Empty,
                            reader["Email"].ToString() ?? string.Empty,
                            reader["Contrasena"].ToString() ?? string.Empty
                        )
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            SubastaGanada = Convert.ToInt32(reader["SubastaGanada"]) == 1
                        };

                        lista.Add(postor);
                    }
                }
            }

            return lista;
        }

        public Postor? ObtenerPorId(int id)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Email, Contrasena, SubastaGanada FROM Postores WHERE Id=@id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Postor(
                                reader["Nombre"].ToString() ?? string.Empty,
                                reader["Email"].ToString() ?? string.Empty,
                                reader["Contrasena"].ToString() ?? string.Empty
                            )
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                SubastaGanada = Convert.ToInt32(reader["SubastaGanada"]) == 1
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Postor? ObtenerPorEmail(string email)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Email, Contrasena, SubastaGanada FROM Postores WHERE Email=@e";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@e", email);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Postor(
                                reader["Nombre"].ToString() ?? string.Empty,
                                reader["Email"].ToString() ?? string.Empty,
                                reader["Contrasena"].ToString() ?? string.Empty
                            )
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                SubastaGanada = Convert.ToInt32(reader["SubastaGanada"]) == 1
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Agregar(Postor postor)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Postores (Nombre, Email, Contrasena, SubastaGanada) VALUES (@n,@e,@c,@s)";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", postor.Nombre);
                    cmd.Parameters.AddWithValue("@e", postor.Email);
                    cmd.Parameters.AddWithValue("@c", postor.Contrasena);
                    cmd.Parameters.AddWithValue("@s", postor.SubastaGanada ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarPorId(int idSeleccionado)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Postores WHERE Id=@id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ActualizarNombre(Postor postor, string nuevoNombre)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Postores SET Nombre=@n WHERE Id=@id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", nuevoNombre);
                    cmd.Parameters.AddWithValue("@id", postor.Id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarEmail(Postor postor, string nuevoEmail)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Postores SET Email=@e WHERE Id=@id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@e", nuevoEmail);
                    cmd.Parameters.AddWithValue("@id", postor.Id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}


/*namespace SubastaWinForms.Repositories
{
    public class PostorRepository
    {
        private static List<Postor> postores = new List<Postor>();
        private int siguienteId = 1;
        public PostorRepository()
        {
        }
        public List<Postor> ObtenerTodos()
        {
            return postores;
        }
        public Postor ObtenerPorId(int id)
        {
            return postores.FirstOrDefault(p => p.Id == id);
        }
        public Postor ObtenerPorEmail(string email)
        {
            return postores.FirstOrDefault(e => e.Email == email);
        }

        public bool ActualizarNombre(Postor postor, string nuevoNombre)
        {
            postor.Nombre = nuevoNombre;
            return true;
        }
        public bool ActualizarEmail(Postor postor, string nuevoEmail)
        {
            postor.Email = nuevoEmail;
            return true;
        }
        public void Agregar(Postor postor)
        {
            postor.Id = siguienteId++;
            postores.Add(postor);
        }

        public void EliminarPorId(int idSeleccionado)
        {
            int indice = -1;
            for (int i = 0; i < postores.Count; i++)
            {
                if (postores[i].Id == idSeleccionado)
                {
                    indice = i;
                    break;
                }
            }
            if (indice >= 0)
            {
                postores.RemoveAt(indice);
            }
        }



    }

}*/

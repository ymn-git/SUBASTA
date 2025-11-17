using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SubastaWinForms.Model.Entities;

namespace SubastaWinForms.Repositories
{
    public class SubastadorRepository
    {
        private readonly string connectionString = "Data Source=subasta.db";

        public List<Subastador> ObtenerTodos()
        {
            List<Subastador> lista = new List<Subastador>();
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Email, Contrasena FROM Subastadores";
                using (var cmd = new SqliteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Subastador subastador = new Subastador(
                            reader["Nombre"].ToString() ?? string.Empty,
                            reader["Email"].ToString() ?? string.Empty,
                            reader["Contrasena"].ToString() ?? string.Empty
                        )
                        {
                            Id = Convert.ToInt32(reader["Id"])
                        };
                        lista.Add(subastador);
                    }
                }
            }
            return lista;
        }

        public Subastador? ObtenerPorId(int id)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Email, Contrasena FROM Subastadores WHERE Id=@id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Subastador(
                                reader["Nombre"].ToString() ?? string.Empty,
                                reader["Email"].ToString() ?? string.Empty,
                                reader["Contrasena"].ToString() ?? string.Empty
                            )
                            {
                                Id = Convert.ToInt32(reader["Id"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Subastador? ObtenerPorEmail(string email)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Email, Contrasena FROM Subastadores WHERE Email=@e";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@e", email);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Subastador(
                                reader["Nombre"].ToString() ?? string.Empty,
                                reader["Email"].ToString() ?? string.Empty,
                                reader["Contrasena"].ToString() ?? string.Empty
                            )
                            {
                                Id = Convert.ToInt32(reader["Id"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Agregar(Subastador subastador)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Subastadores (Nombre, Email, Contrasena) VALUES (@n,@e,@c); SELECT last_insert_rowid();";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", subastador.Nombre);
                    cmd.Parameters.AddWithValue("@e", subastador.Email);
                    cmd.Parameters.AddWithValue("@c", subastador.Contrasena);

                    // Ejecutar y recuperar el Id generado
                    long id = (long)cmd.ExecuteScalar();
                    subastador.Id = (int)id;
                }
            }
        }


        public bool EliminarPorId(int id)
        {
            try
            {
                using (var conn = new SqliteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Subastadores WHERE Id=@id";
                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede eliminar el Subastador porque está en uso o relacionado con una subasta activa.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }



        public bool ActualizarNombre(Subastador subastador, string nuevoNombre)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Subastadores SET Nombre=@n WHERE Id=@id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", nuevoNombre);
                    cmd.Parameters.AddWithValue("@id", subastador.Id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool ActualizarEmail(Subastador subastador, string nuevoEmail)
{
    using (var conn = new SqliteConnection(connectionString))
    {
        conn.Open();
        string sql = "UPDATE Subastadores SET Email=@e WHERE Id=@id";
        using (var cmd = new SqliteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@e", nuevoEmail);
            cmd.Parameters.AddWithValue("@id", subastador.Id);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}


    }
}


/*namespace SubastaWinForms.Repositories
{
    public class SubastadorRepository
    {
        private int siguienteId = 1;
        private static List<Subastador> subastadores = new List<Subastador>();

        public SubastadorRepository() { }
        public List<Subastador> ObtenerTodos()
        {
            return subastadores;
        }
        public Subastador ObtenerPorId(int id)
        {
            for (int i = 0; i < subastadores.Count; i++)
            {
                if (subastadores[i].Id == id)
                {
                    return subastadores[i];
                }
            }
            return null;
        }
        public Subastador ObtenerPorEmail(string email)
        {
            for (int i = 0; i < subastadores.Count; i++)
            {
                if (subastadores[i].Email == email)
                {
                    return subastadores[i];
                }
            }
            return null;
        }

        public void Agregar(Subastador subastador)
        {
            subastador.Id = siguienteId++;
            subastadores.Add(subastador);
        }

        public void Eliminar(int id)
        {
            int indice = -1;
            for (int i = 0; i < subastadores.Count; i++)
            {
                if (subastadores[i].Id == id)
                {
                    indice = i;
                    break;
                }
            }
            if (indice >= 0)
            {
                subastadores.RemoveAt(indice);
            }
        }


        public void ModificarSubastador(Subastador subastador)
        {
            for (int i = 0; i < subastadores.Count; i++)
            {
                if (subastadores[i].Email == subastador.Email)
                {
                    subastadores[i].Nombre = subastador.Nombre;
                    break;
                }
            }
        }
    }
}*/

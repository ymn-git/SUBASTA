using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SubastaWinForms.Model.Entities;

namespace SubastaWinForms.Repositories
{
    public class ArticuloRepository
    {
        private readonly string connectionString = "Data Source=subasta.db";

        public void Agregar(Articulo articulo)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Articulos (Name, Detalle) VALUES (@n,@d); SELECT last_insert_rowid();";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", articulo.Name);
                    cmd.Parameters.AddWithValue("@d", articulo.Detalle);

                    // Ejecutar y recuperar el NumeroArticulo generado
                    long id = (long)cmd.ExecuteScalar();
                    articulo.NumeroArticulo = (int)id;
                }
            }
        }


        public List<Articulo> ObtenerTodos()
        {
            List<Articulo> lista = new List<Articulo>();
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT NumeroArticulo, Name, Detalle FROM Articulos";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Articulo articulo = new Articulo(
                            reader["Name"].ToString(),
                            reader["Detalle"].ToString()
                        )
                        {
                            NumeroArticulo = Convert.ToInt32(reader["NumeroArticulo"])
                        };
                        lista.Add(articulo);
                    }
                }
            }
            return lista;
        }

        public Articulo ObtenerArticuloPorNumero(int numeroArticulo)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT NumeroArticulo, Name, Detalle FROM Articulos WHERE NumeroArticulo=@id";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", numeroArticulo);
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Articulo(
                                reader["Name"].ToString(),
                                reader["Detalle"].ToString()
                            )
                            {
                                NumeroArticulo = Convert.ToInt32(reader["NumeroArticulo"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Eliminar(int numeroArticulo)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Articulos WHERE NumeroArticulo=@id";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", numeroArticulo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ActualizarNombre(Articulo articulo, string nuevoNombre)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Articulos SET Name=@n WHERE NumeroArticulo=@id";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", nuevoNombre);
                    cmd.Parameters.AddWithValue("@id", articulo.NumeroArticulo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarDetalle(Articulo articulo, string nuevoDetalle)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Articulos SET Detalle=@d WHERE NumeroArticulo=@id";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@d", nuevoDetalle);
                    cmd.Parameters.AddWithValue("@id", articulo.NumeroArticulo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}


/*namespace SubastaWinForms.Repositories
{
    public class ArticuloRepository
    {
        private static List<Articulo> articulos;
        private int siguienteId = 1;

        public ArticuloRepository()
        {
            articulos = new List<Articulo>();
        }
        public void Agregar(Articulo articulo)
        {
            articulo.NumeroArticulo = siguienteId++;
            articulos.Add(articulo);
        }
        public List<Articulo> ObtenerTodos()
        {
            return articulos;
        }
        public Articulo ObtenerArticuloPorNumero(int numoeroArticulo)
        {
            for (int i = 0; i < articulos.Count; i++)
            {
                if (articulos[i].NumeroArticulo == numoeroArticulo)
                {
                    return articulos[i];
                }
            }

            return null;
        }


        public void Eliminar(int numeroArticulo)
        {
            int indice = -1;
            for (int i = 0; i < articulos.Count; i++)
            {
                if (articulos[i].NumeroArticulo == numeroArticulo)
                {
                    indice = i;
                    break;
                }
            }
            if (indice >= 0)
            {
                articulos.RemoveAt(indice);
            }
        }

        public bool ActualizarNombre(Articulo articulo, string nuevoNombre)
        {
            articulo.Name = nuevoNombre;
            return true;
        }

        public bool ActualizarDetalle(Articulo articulo, string nuevoDetalle)
        {
            articulo.Detalle = nuevoDetalle;
            return true;
        }

    }
}*/

using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SubastaWinForms.Model.Entities;

namespace SubastaWinForms.Repositories
{
    public class SubastaRepository
    {
        private readonly string connectionString = "Data Source=subasta.db";

        public List<Subasta> ObtenerTodos()
        {
            var lista = new List<Subasta>();
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = @"
            SELECT s.Id, s.PujaInicial, s.MontoActual, s.PujaDeAumento, s.FechaInicio, s.DuracionMinutos,
                   sub.Id as SubastadorId, sub.Nombre as SubastadorNombre, sub.Email as SubastadorEmail,
                   art.NumeroArticulo, art.Name as ArticuloNombre, art.Detalle as ArticuloDetalle,
                   p.Id as GanadorId, p.Nombre as GanadorNombre, p.Email as GanadorEmail
            FROM Subastas s
            JOIN Subastadores sub ON s.SubastadorId = sub.Id
            JOIN Articulos art ON s.ArticuloId = art.NumeroArticulo
            LEFT JOIN Postores p ON s.GanadorId = p.Id";

                using (var cmd = new SqliteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var subastador = new Subastador(
                            reader.GetString(reader.GetOrdinal("SubastadorNombre")),
                            reader.GetString(reader.GetOrdinal("SubastadorEmail")),
                            "" // contrasena no la necesitás mostrar
                        )
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("SubastadorId"))
                        };

                        var articulo = new Articulo(
                            reader.GetString(reader.GetOrdinal("ArticuloNombre")),
                            reader.GetString(reader.GetOrdinal("ArticuloDetalle"))
                        )
                        {
                            NumeroArticulo = reader.GetInt32(reader.GetOrdinal("NumeroArticulo"))
                        };

                        Postor? ganador = null;
                        if (!reader.IsDBNull(reader.GetOrdinal("GanadorId")))
                        {
                            ganador = new Postor(
                                reader.GetString(reader.GetOrdinal("GanadorNombre")),
                                reader.GetString(reader.GetOrdinal("GanadorEmail")),
                                ""
                            )
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("GanadorId"))
                            };
                        }

                        var subasta = new Subasta(
                            Convert.ToDecimal(reader["PujaInicial"]),
                            Convert.ToDecimal(reader["PujaDeAumento"]),
                            TimeSpan.FromMinutes(Convert.ToInt32(reader["DuracionMinutos"])),
                            subastador,
                            articulo
                        )
                        {
                            NumeroDeSubasta = Convert.ToInt32(reader["Id"]),
                            MontoActual = Convert.ToDecimal(reader["MontoActual"]),
                            FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString() ?? DateTime.MinValue.ToString()),
                            Ganador = ganador
                        };

                        lista.Add(subasta);
                    }
                }
            }
            return lista;
        }


        public Subasta? ObtenerUltima()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT Id, PujaInicial, MontoActual, PujaDeAumento, FechaInicio, DuracionMinutos, 
                              SubastadorId, ArticuloId, GanadorId
                       FROM Subastas
                       ORDER BY Id DESC
                       LIMIT 1";
                using (var cmd = new SqliteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Subasta(
                            Convert.ToDecimal(reader["PujaInicial"]),
                            Convert.ToDecimal(reader["PujaDeAumento"]),
                            TimeSpan.FromMinutes(Convert.ToInt32(reader["DuracionMinutos"])),
                            null,
                            null
                        )
                        {
                            NumeroDeSubasta = Convert.ToInt32(reader["Id"]),
                            MontoActual = Convert.ToDecimal(reader["MontoActual"]),
                            FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString() ?? DateTime.MinValue.ToString())
                        };
                    }
                }
            }
            return null;
        }

        public Subasta? ObtenerPorNumeroSubasta(int numeroSubasta)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, PujaInicial, MontoActual, PujaDeAumento, FechaInicio, DuracionMinutos, SubastadorId, ArticuloId, GanadorId FROM Subastas WHERE Id=@id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", numeroSubasta);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Subasta(
                                Convert.ToDecimal(reader["PujaInicial"]),
                                Convert.ToDecimal(reader["PujaDeAumento"]),
                                TimeSpan.FromMinutes(Convert.ToInt32(reader["DuracionMinutos"])),
                                null,
                                null
                            )
                            {
                                NumeroDeSubasta = Convert.ToInt32(reader["Id"]),
                                MontoActual = Convert.ToDecimal(reader["MontoActual"]),
                                FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString() ?? DateTime.MinValue.ToString())
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Agregar(Subasta subasta)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Subastas 
                               (PujaInicial, MontoActual, PujaDeAumento, FechaInicio, DuracionMinutos, SubastadorId, ArticuloId, GanadorId) 
                               VALUES (@pi,@ma,@pa,@fi,@dm,@sid,@aid,@gid)";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pi", subasta.PujaInicial);
                    cmd.Parameters.AddWithValue("@ma", subasta.MontoActual);
                    cmd.Parameters.AddWithValue("@pa", subasta.PujaDeAumento);
                    cmd.Parameters.AddWithValue("@fi", subasta.FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@dm", subasta.Duracion.TotalMinutes);
                    cmd.Parameters.AddWithValue("@sid", subasta.Subastador?.Id ?? 0);
                    cmd.Parameters.AddWithValue("@aid", subasta.Articulo?.NumeroArticulo ?? 0);
                    cmd.Parameters.AddWithValue("@gid", (object?)subasta.Ganador?.Id ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int numeroSubasta)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Subastas WHERE Id=@id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", numeroSubasta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarSubasta(Subasta subasta)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Subastas 
                               SET PujaInicial=@pi, PujaDeAumento=@pa, SubastadorId=@sid, ArticuloId=@aid 
                               WHERE Id=@id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pi", subasta.PujaInicial);
                    cmd.Parameters.AddWithValue("@pa", subasta.PujaDeAumento);
                    cmd.Parameters.AddWithValue("@sid", subasta.Subastador?.Id ?? 0);
                    cmd.Parameters.AddWithValue("@aid", subasta.Articulo?.NumeroArticulo ?? 0);
                    cmd.Parameters.AddWithValue("@id", subasta.NumeroDeSubasta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarPostorGanador(Subasta subasta)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Subastas SET GanadorId=@gid, MontoActual=@ma WHERE Id=@id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@gid", subasta.Ganador?.Id ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ma", subasta.MontoActual);
                    cmd.Parameters.AddWithValue("@id", subasta.NumeroDeSubasta);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}



/*namespace SubastaWinForms.Repositories
{
    public class SubastaRepository
    {
        private static List<Subasta> subastas;
        private int siguienteNumero = 1;
        public SubastaRepository()
        {
            subastas = new List<Subasta>();
        }
        public List<Subasta> ObtenerTodos()
        {
            return subastas;
        }
        //el ? en Subasta? lo puse en toda la cadena para evitar la advertencia de posible valor null
        //ya que se que no va a ocurrir porque siempre va a haber al menos una
        public Subasta? ObtenerUltima()
        {
            return subastas.LastOrDefault();
        }

        public Subasta ObtenerPorNumeroSubasta(int numeroSubasta)
        {
            foreach (Subasta subasta in subastas)
            {
                if (subasta.NumeroDeSubasta == numeroSubasta)
                {
                    return subasta;
                }
            }

            return null;
        }
        public void Agregar(Subasta subasta)
        {
            subasta.NumeroDeSubasta = siguienteNumero++; // ← asignación aquí
            subastas.Add(subasta);
        }

        public void Eliminar(int numeroSubasta)
        {
            int indice = -1;
            for (int i = 0; i < subastas.Count; i++)
            {
                if (
                    subastas[i].NumeroDeSubasta == numeroSubasta)
                {
                    indice = i;
                    break;
                }
            }
            if (indice >= 0)
            {
                subastas.RemoveAt(indice);
            }
        }

        public void ModificarSubasta(Subasta subasta)
        {
            Subasta sub = ObtenerPorNumeroSubasta(subasta.NumeroDeSubasta);

            if (sub != null)
            {
                sub.PujaInicial = subasta.PujaInicial;
                sub.Subastador = subasta.Subastador;
                sub.Articulo = subasta.Articulo;
            }

        }
        public void ActualizarPostorGanador(Subasta subasta)
        {
            Subasta sub = ObtenerPorNumeroSubasta(subasta.NumeroDeSubasta);

            if (sub != null)
            {
                sub.Ganador = subasta.Ganador;
            }

        }
    }
}*/

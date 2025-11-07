using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace SubastaWinForms.Data
{
    public class DatabaseInitializer
    {
        private readonly string connectionString = "Data Source=subasta.db";


        public void CrearBaseSiNoExiste()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS Postores (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT NOT NULL,
                        Email TEXT NOT NULL UNIQUE,
                        Contrasena TEXT NOT NULL,
                        SubastaGanada INTEGER DEFAULT 0
                    );

                    CREATE TABLE IF NOT EXISTS Subastadores (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT NOT NULL,
                        Email TEXT NOT NULL UNIQUE,
                        Contrasena TEXT NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS Subastas (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PujaInicial REAL NOT NULL,
                        MontoActual REAL NOT NULL,
                        PujaDeAumento REAL NOT NULL,
                        FechaInicio TEXT NOT NULL,       
                        DuracionMinutos INTEGER NOT NULL, 
                        SubastadorId INTEGER NOT NULL,
                        ArticuloId INTEGER NOT NULL,
                        GanadorId INTEGER,                
                        FOREIGN KEY(SubastadorId) REFERENCES Subastadores(Id),
                        FOREIGN KEY(ArticuloId) REFERENCES Articulos(NumeroArticulo),
                        FOREIGN KEY(GanadorId) REFERENCES Postores(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Articulos (
                        NumeroArticulo INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Detalle TEXT
                    );


                    "
                ;

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


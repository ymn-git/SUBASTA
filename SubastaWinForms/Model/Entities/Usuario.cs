using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubastaWinForms.Model.Entities
{
    public class Usuario
    {
        private string contrasena = null;
        public string Nombre { get; set; }
        public string Email { get; set; }


        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }


        public Usuario(string nombre, string email, string contrasena)
        {
            Nombre = nombre;
            Email = email;
            Contrasena = contrasena;
        }
        public Usuario() { }


    }
}


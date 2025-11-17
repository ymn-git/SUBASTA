using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubastaWinForms.Model.Entities
{
    public class Subastador : Usuario
    {
        private int id;
        public Subastador()
        { }

        public Subastador(string nombre, string email, string contrasena)
            : base(nombre, email, contrasena)
        {
        }

        public override string ToString()
        {
            return this.Nombre; // Usa la propiedad heredada de Usuario
        }

        public int Id
        {
            get { return id; }
            internal set { id = value; }
        }
    }
}

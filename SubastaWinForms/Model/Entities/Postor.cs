using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubastaWinForms.Model.Entities
{
    public class Postor : Usuario
    {
        private int id;
        private bool subastaGanada;

        // 🏗️ Constructores
        public Postor(string nombre, string email, string contrasena)
            : base(nombre, email, contrasena)
        {
            subastaGanada = false;
        }

        public Postor() : base()
        {
            subastaGanada = false;
        }

        public override string ToString()
        {
            return this.Nombre; // Usa la propiedad heredada de Usuario
        }

        // 🧩 Propiedades específicas
        public int Id
        {
            get { return id; }
            internal set { id = value; }
        }

        public bool SubastaGanada
        {
            get { return subastaGanada; }
            set { subastaGanada = value; }
        }
    }
}


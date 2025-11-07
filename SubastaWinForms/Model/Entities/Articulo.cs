using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubastaWinForms.Model.Entities
{
    public class Articulo
    {
        private int numeroArticulo;
        string name;
        string detalle;

        public Articulo(string name, string detalle)
        {
            Name = name;
            this.detalle = detalle;
        }

        public string Name { get { return name; } set { name = value; } }
        public string Detalle { get { return detalle; } set { detalle = value; } }

        public int NumeroArticulo
        {
            get { return numeroArticulo; }
            internal set { numeroArticulo = value; }
        }

        public override string ToString() {
            return this.name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubastaWinForms.Model.Entities;
using SubastaWinForms.Services;

namespace SubastaWinForms.Controllers
{
    public class ArticuloController
    {
        private readonly ArticuloService service;

        public ArticuloController()
        {
            service = new KundeServiceAdapter();
        }
        private class KundeServiceAdapter : ArticuloService;

        public List<Articulo> ObtenerArticulos()
        {
            return service.ObtenerArticulos();
        }
        public Articulo ObtenerArticuloPorNumero(int numeroArticulo)
        {
            return service.ObtenerArticuloPorNumero(numeroArticulo);
        }

        public Articulo AgregarArticulo(string nombre, string detalle)
        {
            Articulo articulo = new Articulo(nombre, detalle);
            bool ok = service.RegistrarArticulo(articulo);
            return ok ? articulo : null;
        }


        public bool EliminarArticulo(int numeroArticulo)
        {
            return service.EliminarArticulo(numeroArticulo);
        }

        public bool ModificarDetalleArticulo(int numeroArticulo, string nuevoDetalle)
        {
            return service.ModificarDetalleArticulo(numeroArticulo, nuevoDetalle);
        }
        public bool ModificarNombreArticulo(int numeroArticulo, string nuevoNombre)
        {
            return service.ModificarNombreArticulo(numeroArticulo, nuevoNombre);
        }

    }
}

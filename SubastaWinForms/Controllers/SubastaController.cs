using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubastaWinForms.Model.Entities;
using SubastaWinForms.Services;

namespace SubastaWinForms.Controllers
{
    public class SubastaController
    {
        private readonly SubastaService service;


        public SubastaController()
        {
            service = new KundeServiceAdapter();
        }
        private class KundeServiceAdapter : SubastaService;

        //esto devuelve la lista completa
        public List<Subasta> ObtenerSubastas()
        {
            return service.ObtenerSubastas();
        }
        //este devuelve la ultima en ingresar en la lista
        public Subasta? ObtenerUltimaSubasta()
        {
            return service.ObtenerUltimaSubasta();
        }
        public Subasta? AgregarSubasta(Subastador subastador, Articulo articulo, decimal montoInicial, decimal pujaDeAumento, TimeSpan duracion)
        {
            Subasta subasta = new Subasta(montoInicial, pujaDeAumento, duracion, subastador, articulo);
            return service.RegistrarSubasta(subasta);
        }

        /*public bool AgregarSubasta(Subastador subastador, Articulo articulo, decimal montoInicial, decimal pujaDeAumento, TimeSpan duracion)
        {
            Subasta subasta = new Subasta(montoInicial, pujaDeAumento, duracion, subastador, articulo);
            return service.RegistrarSubasta(subasta);
        }*/
        public bool ModificarNombreArticuloSubasta(int numeroSubasta, string nuevoNombre)
        {
            var subasta = service.ObtenerPorNumeroSubasta(numeroSubasta);
            if (subasta == null) return false;

            var articulo = subasta.Articulo;
            if (articulo == null) return false;

            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre del artículo no puede estar vacío.");
            return AppContext.ArticuloController.ModificarNombreArticulo(articulo.NumeroArticulo, nuevoNombre);

        }

        public bool EliminarSubasta(int numeroSubasta)
        {
            return service.EliminarSubasta(numeroSubasta);
        }

        //camino para registrar postor que va ganando
        public bool RegistrarPostorGanador(int numeroSubasta, Postor postor)
        {
            Subasta subasta = service.ObtenerPorNumeroSubasta(numeroSubasta);
            if (subasta == null || postor == null) return false;
            if (subasta.EstaFinalizada) return false;

            // 1. Actualizar en memoria
            subasta.RegistrarGanador(postor);

            // 2. Persistir en BD
            service.ActualizarPostorGanador(subasta);

            return true;
        }


        /*public bool RegistrarSubastaCompleta(
           string nombreSubastador, string emailSubastador,
           string nombreArticulo, string detalleArticulo,
           decimal montoInicial, decimal pujaDeAumento, TimeSpan duracion)
        {
            // Paso 1: registrar o reutilizar subastador
            Subastador subastador = AppContext.SubastadorController.ObtenerSubastadorPorEmail(emailSubastador);
            if (subastador == null)
            {
                subastador = AppContext.SubastadorController.AgregarSubastador(emailSubastador, nombreSubastador);
                if (subastador == null) return false;
            }

            // Paso 2: registrar artículo
            Articulo articulo = AppContext.ArticuloController.AgregarArticulo(nombreArticulo, detalleArticulo);
            if (articulo == null) return false;

            // Paso 3: crear subasta
            return AgregarSubasta(subastador, articulo, montoInicial, pujaDeAumento, duracion);
        }
        */
        public Subasta? RegistrarSubastaCompleta(Subastador subastador,
                                          string nombreArticulo, string detalleArticulo,
                                          decimal montoInicial, decimal pujaDeAumento,
                                          TimeSpan duracion)
        {
            // 1. Registrar el artículo en la BD
            var articulo = AppContext.ArticuloController.AgregarArticulo(nombreArticulo, detalleArticulo);
            if (articulo == null) return null;

            // 2. Crear la subasta con objetos que ya tienen IDs válidos
            var subasta = new Subasta(montoInicial, pujaDeAumento, duracion, subastador, articulo)
            {
                MontoActual = montoInicial,
                FechaInicio = DateTime.Now,
                Ganador = null
            };

            // 3. Guardar la subasta en la BD
            var registrada = service.RegistrarSubasta(subasta);
            return registrada; // devuelve la subasta creada o null
        }




    }
}

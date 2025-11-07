using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubastaWinForms.Model.Entities;
using SubastaWinForms.Repositories;

namespace SubastaWinForms.Services
{
    public class SubastaService
    {
        private readonly SubastaRepository repository;
        public SubastaService() //Constructor: instancia el repositorio, quien arranca con una lista vacía.
        {
            repository = new SubastaRepository();
        }
        public Subasta ObtenerPorNumeroSubasta(int numeroSubasta)
        {
            return repository.ObtenerPorNumeroSubasta(numeroSubasta);
        }

        //La siguiente funcion chequea si existe un Postor ya creado con ese mail y retorna T o F segun.
       /* public bool RegistrarSubasta(Subasta nuevaSubasta)
        {
            if (nuevaSubasta == null || nuevaSubasta.Articulo == null || nuevaSubasta.Subastador == null)
                return false;

            repository.Agregar(nuevaSubasta);
            return true;
        }
        */
         public Subasta? RegistrarSubasta(Subasta nuevaSubasta)
         {
            if (nuevaSubasta == null || nuevaSubasta.Articulo == null || nuevaSubasta.Subastador == null)
                return null;

            repository.Agregar(nuevaSubasta);
            return nuevaSubasta;
         }

         
        public List<Subasta> ObtenerSubastas() //simplemente devuelve la lista almacenada en el rep
        {
            return repository.ObtenerTodos();
        }
        public Subasta? ObtenerUltimaSubasta()
        {
            Subasta? ultima = repository.ObtenerUltima();
            if (ultima == null)
            {
                // No hay ninguna subasta registrada
                return null;
            }
            return ultima;
        }


        public bool EliminarSubasta(int numeroSubasta)
        {
            Subasta existente = repository.ObtenerPorNumeroSubasta(numeroSubasta);
            if (existente == null)
            { return false; }
            repository.Eliminar(numeroSubasta);
            return true;
        }

        public bool ModificarSubasta(Subasta subasta)
        {
            Subasta existente = repository.ObtenerPorNumeroSubasta(subasta.NumeroDeSubasta);
            if (existente == null)
            {
                return false;
            }
            repository.ModificarSubasta(subasta);
            return true;
        }
        
        public bool ActualizarPostorGanador(Subasta subasta)
        {
            Subasta existente = repository.ObtenerPorNumeroSubasta(subasta.NumeroDeSubasta);
            if (existente == null)
            {
                return false;
            }
            repository.ActualizarPostorGanador(subasta);
            return true;
        }
    }
}

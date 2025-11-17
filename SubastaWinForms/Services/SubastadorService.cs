using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubastaWinForms.Model.Entities;
using SubastaWinForms.Repositories;

namespace SubastaWinForms.Services
{
    public class SubastadorService
    {
        private readonly SubastadorRepository repository;

        public SubastadorService()
        {
            repository = new SubastadorRepository();
            ;
        }
        //La siguiente funcion chequea si existe un subastador ya creado con ese mail y retorna T o F segun.
        public bool RegistrarSubastador(Subastador nuevoSubastador)
        {
            Subastador existente = repository.ObtenerPorEmail(nuevoSubastador.Email);
            if (existente != null)
            {
                //Ya existe un subastador con ese Email
                return false;
            }
            repository.Agregar(nuevoSubastador);
            return true;
        }

        public Subastador ObtenerSubastador(int id)
        {
            return repository.ObtenerPorId(id);
        }
        public Subastador ObtenerSubastadorPorEmail(string email)
        {
            return repository.ObtenerPorEmail(email);
        }
        public bool Eliminar(int id)
        {
            Subastador existente = repository.ObtenerPorId(id);
            if (existente == null)
            { return false; }
            repository.EliminarPorId(id);
            return true;
        }


        public bool ModificarNombreSubastador(int id, string nuevoNombre)
        {
            var subastador = repository.ObtenerPorId(id);
            if (subastador == null) return false;

            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            return repository.ActualizarNombre(subastador, nuevoNombre);
        }
        public bool ModificarEmailSubastador(int id, string nuevoEmail)
        {
            var subastador = repository.ObtenerPorId(id);
            if (subastador == null) return false;

            if (string.IsNullOrWhiteSpace(nuevoEmail))
                throw new ArgumentException("El email no puede estar vacío.");

            return repository.ActualizarEmail(subastador, nuevoEmail);
        }
    }
}

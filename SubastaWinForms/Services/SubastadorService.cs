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
            repository.Eliminar(id);
            return true;
        }

        public bool ModificarSubastador(Subastador subastador)
        {
            Subastador existente = repository.ObtenerPorId(subastador.Id);
            if (existente == null)
            {
                return false;
            }
            repository.ModificarSubastador(subastador);
            return true;
        }
    }
}

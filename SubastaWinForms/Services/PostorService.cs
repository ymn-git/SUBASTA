using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubastaWinForms.Model.Entities;
using SubastaWinForms.Repositories;

namespace SubastaWinForms.Services
{
    public class PostorService
    {
        private readonly PostorRepository repository;
        public PostorService() //Constructor: instancia el repositorio, quien arranca con una lista vacía.
        {
            repository = new PostorRepository();
        }
        //La siguiente funcion chequea si existe un Postor ya creado con ese mail y retorna T o F segun.
        public bool RegistrarPostor(Postor nuevoPostor)
        {
            Postor existente = repository.ObtenerPorEmail(nuevoPostor.Email);
            if (existente != null)
            {
                //Ya existe un postor con ese Email
                return false;
            }
            repository.Agregar(nuevoPostor);
            return true;
        }
        public Postor ObtenerPostor(int id)
        {
            return repository.ObtenerPorId(id);
        }
        public Postor ObtenerPostorPorEmail(string email)
        {
            return repository.ObtenerPorEmail(email);
        }
        public List<Postor> ObtenerTodos()
        {
            return repository.ObtenerTodos();
        }

        public bool EliminarPostor(int idSeleccionado)
        {
            Postor existente = repository.ObtenerPorId(idSeleccionado);
            if (existente == null)
                return false;

            return repository.EliminarPorId(idSeleccionado);
        }


        /*public bool ModificarPostor(Postor postor)
        {
            Postor existente = repository.ObtenerPorEmail(postor.Email);
            if (existente == null)
            {
                return false;
            }
            repository.ModificarPostor(postor);
            return true ;
        }*/
        public bool ModificarNombrePostor(int id, string nuevoNombre)
        {
            var postor = repository.ObtenerPorId(id);
            if (postor == null) return false;

            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            return repository.ActualizarNombre(postor, nuevoNombre);
        }
        public bool ModificarEmailPostor(int id, string nuevoEmail)
        {
            var postor = repository.ObtenerPorId(id);
            if (postor == null) return false;

            if (string.IsNullOrWhiteSpace(nuevoEmail))
                throw new ArgumentException("El email no puede estar vacío.");

            return repository.ActualizarEmail(postor, nuevoEmail);
        }



        //camino de registrar postor que va ganando
        public Postor ObtenerPorId(int id)
        {
            return repository.ObtenerPorId(id);
        }

    }
}

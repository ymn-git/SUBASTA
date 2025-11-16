using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubastaWinForms.Model.Entities;
using SubastaWinForms.Services;

namespace SubastaWinForms.Controllers
{
    public class PostorController
    {
        private readonly PostorService service;

        public PostorController()
        {
            service = new KundeServiceAdapter();
        }
        private class KundeServiceAdapter : PostorService;

        public List<Postor> ObtenerPostores()
        {
            return service.ObtenerTodos();
        }
        public Postor ObtenerPostor(int id)
        {
            return service.ObtenerPostor(id);
        }
        public Postor ObtenerPostorPorEmail(string email)
        {
            return service.ObtenerPostorPorEmail(email);
        }
        public bool AgregarPostor(string nombre, string email, string contrasena)
        {
            Postor postor = new Postor( nombre, email, contrasena);
            postor.Email = email;
            postor.Nombre = nombre;
            postor.Contrasena = contrasena;
            return service.RegistrarPostor(postor);
        }
        public bool Pujar(int numeroSubasta, int idPostor)
        {
            Postor postor = service.ObtenerPorId(idPostor);
            if (postor == null) return false;

            return AppContext.SubastaController.RegistrarPostorGanador(numeroSubasta, postor);
        }


        public bool EliminarPostor(int idSeleccionado)
        {
            return service.EliminarPostor(idSeleccionado);
        }

        /*public bool ModificarPostor(string email, string nombre)
        {
            Postor postor = new Postor(email,nombre);
            postor.Email = email;
            postor.Name = nombre;
            return service.ModificarPostor(postor);
        }*/
        public bool ModificarNombrePostor(int id, string nuevoNombre)
        {
            return service.ModificarNombrePostor(id, nuevoNombre);
        }

        public bool ModificarEmailPostor(int id, string nuevoMail)
        {
            return service.ModificarEmailPostor(id, nuevoMail);
        }

        public List<Subasta> ObtenerSubastas()
        {
            return AppContext.SubastaController.ObtenerSubastas();
        }

    }
}

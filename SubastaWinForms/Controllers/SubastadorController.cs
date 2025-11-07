using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubastaWinForms.Model.Entities;
using SubastaWinForms.Services;

namespace SubastaWinForms.Controllers
{
    public class SubastadorController
    {
        private readonly SubastadorService service;

        public SubastadorController()
        {
            service = new SubastadorService(); // El controlador crea su propio servicio
        }
        /*public List<Subastador> ObtenerSubastadores()
        {
            return service.ObtenerSubastadores();
        }*/
        public Subastador ObtenerSubastadorPorId(int id)
        {
            return service.ObtenerSubastador(id);
        }
        public Subastador ObtenerSubastadorPorEmail(string email)
        {
            return service.ObtenerSubastadorPorEmail(email);
        }
        public Subastador? AgregarSubastador(string nombre, string email, string contrasena)
        {
            Subastador subastador = new Subastador(nombre, email, contrasena);

            bool ok = service.RegistrarSubastador(subastador);

            return ok ? subastador : null;
        }



        public bool EliminarSubastador(int id)
        {
            return service.Eliminar(id);
        }

        /*public bool ModificarSubastador(string email, string nombre)
        {
            Subastador subastador = new Subastador(email, nombre);
            subastador.Email = email;
            subastador.Nombre = nombre;
            return service.ModificarSubastador(subastador);
        }*/
    }
}

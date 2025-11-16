using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubastaWinForms.Controllers;
using SubastaWinForms.Model.Entities;

namespace SubastaWinForms
{
    public static class AppContext
    {
        // CONTROLLERS
        public static SubastadorController SubastadorController { get; } = new SubastadorController();
        public static ArticuloController ArticuloController { get; } = new ArticuloController();
        public static SubastaController SubastaController { get; } = new SubastaController();
        public static PostorController PostorController { get; } = new PostorController();
        public static UsuarioController UsuarioController { get; } = new UsuarioController();

        //-----------------------------------------------------------------------------------------------
        public static Usuario? UsuarioActual { get; set; }
        public static Postor? PostorActual { get; set; }
        public static Subastador? SubastadorActual { get; set; }

    }
}

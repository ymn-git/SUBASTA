using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubastaWinForms.Model.Entities;

namespace SubastaWinForms.Controllers
{
    public class UsuarioController
    {
        public bool RevisarContrasena(string contrasenaIngrsada)
        {
            if (contrasenaIngrsada.Length < 8 )
                return false;
   
            return true;
        }
    }
}

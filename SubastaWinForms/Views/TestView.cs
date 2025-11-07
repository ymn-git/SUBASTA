using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SubastaWinForms.Controllers;
using SubastaWinForms.Model.Entities;
using SubastaWinForms.Views;

namespace SubastaWinForms.Views
{
    public partial class TestView : Form
    {
        readonly PostorController Postorcontroller = AppContext.PostorController;
        public TestView()
        {
            InitializeComponent();
        }

        private void PostorView_Click(object sender, EventArgs e)
        {
            PostorView p = new PostorView();
            p.ShowDialog();
            //Postor registrado = Postorcontroller.ObtenerPostorPorEmail(email);
        }

        private void subastadorView_Click(object sender, EventArgs e)
        {
            SubastadorView s = new SubastadorView();
            s.ShowDialog();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            string nombre = IngresarNombreTXT.Text.Trim();
            string email = IngresarEmailTXT.Text.Trim();
            string contrasena = IngresarContrasenaTXT.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Debe ingresar nombre, email y contraseña.");
                return;
            }
            if ( AppContext.UsuarioController.RevisarContrasena(contrasena) == false)
            {
                MessageBox.Show("La contraseña debe contener al menos 8 caracteres");
                return;
            }
            AppContext.UsuarioActual = new Usuario(nombre, email, contrasena);

            if (rbPostor.Checked)
            {
                Postor? yaRegistrado = AppContext.PostorController.ObtenerPostorPorEmail(email);

                if (yaRegistrado != null)
                {
                    if (yaRegistrado.Contrasena == contrasena)
                    {
                        AppContext.PostorActual = yaRegistrado;
                        MessageBox.Show("Bienvenido postor.");
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta.");
                        return; // no abre la vista
                    }

                }
                else
                {
                    bool agregado = AppContext.PostorController.AgregarPostor(nombre, email, contrasena);
                    if (agregado)
                    {
                        AppContext.PostorActual = AppContext.PostorController.ObtenerPostorPorEmail(email);
                        MessageBox.Show("Postor registrado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar el postor.");
                        return;
                    }
                }

                PostorView p = new PostorView();
                p.ShowDialog();
                btnPostorView.Enabled = true;
            }
            else if (rbSubastador.Checked)
            {
                Subastador? yaRegistrado = AppContext.SubastadorController.ObtenerSubastadorPorEmail(email);

                if (yaRegistrado != null)
                {
                    if (yaRegistrado.Contrasena == contrasena)
                    {
                        AppContext.SubastadorActual = yaRegistrado;
                        MessageBox.Show("Bienvenido subastador.");
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta.");
                        return; 
                    }
                }
                else
                {
                    Subastador? nuevo = AppContext.SubastadorController.AgregarSubastador(nombre, email, contrasena);

                    if (nuevo != null)
                    {
                        AppContext.SubastadorActual = AppContext.SubastadorController.ObtenerSubastadorPorEmail(email);
                        MessageBox.Show("Subastador registrado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar el subastador.");
                        return;
                    }
                }

                SubastadorView s = new SubastadorView();
                s.ShowDialog();
                btnSubastadorView.Enabled = true;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol.");
            }
        }


    }
}

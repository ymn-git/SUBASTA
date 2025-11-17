using SubastaWinForms.Controllers;
using SubastaWinForms.Model.Entities;
using SubastaWinForms.Views;

namespace SubastaWinForms
{
    public partial class PostorView : Form
    {
        private readonly PostorController postorController;
        public PostorView()
        {
            InitializeComponent();
            postorController = AppContext.PostorController;

        }

        private void btnPujar_Click(object sender, EventArgs e)
        {
            if (dgvSubastas.CurrentRow == null || dgvSubastas.CurrentRow.Index < 0)
            {
                MessageBox.Show("Debe seleccionar una subasta.");
                return;
            }

            Subasta subastaSeleccionada = dgvSubastas.CurrentRow.DataBoundItem as Subasta;
            Postor? postorSeleccionado = AppContext.PostorActual;

            if (subastaSeleccionada == null || postorSeleccionado == null)
            {
                MessageBox.Show("Selección inválida.");
                return;
            }

            int numeroSubasta = subastaSeleccionada.NumeroDeSubasta;
            int idPostor = postorSeleccionado.Id;

            if (postorController.Pujar(numeroSubasta, idPostor))
            {

                MessageBox.Show("Puja registrada correctamente.");
            }
            else
            {
                MessageBox.Show("Error al registrar la puja.");
            }
        }
        private void ActualizardgvSubastas()
        {
            dgvSubastas.DataSource = null;
            dgvSubastas.DataSource = AppContext.SubastaController.ObtenerSubastas();
        }

        private void MostrarVictoria(Postor postorGanador, Subasta subastaFinalizada)
        {
            MessageBox.Show($"Felicitaciones {postorGanador.Nombre} has ganado tu {subastaFinalizada.Articulo} la subasta número {subastaFinalizada.NumeroDeSubasta} \n" +
                $"El valor a pagar es {subastaFinalizada.MontoActual}\n");
        }

        public void RevisarGanador()
        {
            Postor actual = AppContext.PostorActual;
            Subasta ganada = SubastadorView.RevisarGanador(actual);
            if (ganada != null)
            {
                MostrarVictoria(actual, ganada);
            }

        }

        private void PostorView_Load(object sender, EventArgs e)
        {
            lblPostorActivo.Text = $"Postor: {AppContext.PostorActual?.Nombre}";
            lblPostorActivo.Visible = true;
            ActualizardgvSubastas();

        }

        private void modificarNombreTXT_Click(object sender, EventArgs e)
        {
            string nuevoNombre = nuevoNombreTXT.Text;
            int idPostorActual = AppContext.PostorActual.Id;
            bool resultado = postorController.ModificarNombrePostor(idPostorActual, nuevoNombre);

            if (resultado)
            {
                MessageBox.Show("Cambio exitoso");
                lblPostorActivo.Text = $"Postor: {nuevoNombre}";
            }
            else
            {
                MessageBox.Show("Intente de nuevo");
            }
        }

        private void modificarEmailTXT_Click(object sender, EventArgs e)
        {
            string nuevoEmail = nuevoEmailTXT.Text;
            int idPostorActual = AppContext.PostorActual.Id;
            bool resultado = postorController.ModificarEmailPostor(idPostorActual, nuevoEmail);

            if (resultado)
            {
                MessageBox.Show("Cambio exitoso");
                lblPostorActivo.Text = $"Postor: {nuevoEmail}";
            }
            else
            {
                MessageBox.Show("Intente de nuevo");
            }
        }

        private void eliminarBTN_Click(object sender, EventArgs e)
        {
            int postorPorEliminar = AppContext.PostorActual.Id;
            bool resultado = postorController.EliminarPostor(postorPorEliminar);
            if (resultado)
            {
                MessageBox.Show("Postor eliminado correctamente."); 
                AppContext.PostorActual = null; 
                ActualizardgvSubastas();        
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el postor.");
            }
        }


        /*private void ActualizardgvPostores()
         {
             dgvPostores.SelectionChanged -= dgvPostores_SelectionChanged;
             dgvPostores.ClearSelection();
             List<Postor> postores = postorController.ObtenerPostores();
             dgvPostores.DataSource = null;
             dgvPostores.DataSource = postores;
             dgvPostores.SelectionChanged += dgvPostores_SelectionChanged;
         }
         private void dgvPostores_SelectionChanged(object sender, EventArgs e)
         {
             try
             {
                 if (dgvPostores.CurrentRow == null) return;
                 Postor postor = dgvPostores.CurrentRow.DataBoundItem as Postor;
                 if (postor == null) return;
                 txtNombre.Text = postor.Name;
                 txtEmail.Text = postor.Email;
             }
             catch (Exception ex) { MessageBox.Show(ex.Message); }
         }
         private void btnRegistrarse_Click(object sender, EventArgs e)
         {
             string nombre = txtNombre.Text;
             string email = txtEmail.Text;


             if (!AppContext.PostorController.AgregarPostor(nombre, email))
             {
                 MessageBox.Show("Ya existe un postor con ese email.");
             }
             else
             { 
                 ActualizardgvPostores();
                 MessageBox.Show("Registrado correctamente.");
             }

         }
         private void btnModificarNombre_Click(object sender, EventArgs e)
         {
             if (dgvPostores.CurrentRow == null)
             {
                 MessageBox.Show("Debe seleccionar un postor.");
                 return;
             }

             // Recuperar el objeto Postor directamente desde la fila seleccionada
             Postor postorSeleccionado = dgvPostores.CurrentRow.DataBoundItem as Postor;
             if (postorSeleccionado == null)
             {
                 MessageBox.Show("La fila seleccionada no contiene un postor válido.");
                 return;
             }

             string nuevoNombre = txtNombre.Text;

             if (AppContext.PostorController.ModificarNombrePostor(postorSeleccionado.Id, nuevoNombre))
             { 
                 ActualizardgvPostores();
                 MessageBox.Show("Nombre modificado correctamente.");
             }
             else
                 MessageBox.Show("No se pudo modificar el nombre.");


         }
         private void btnModificarEmail_Click(object sender, EventArgs e)
         {
             if (dgvPostores.CurrentRow == null)
             {
                 MessageBox.Show("Debe seleccionar un postor.");
                 return;
             }

             // Recuperar el objeto Postor directamente desde la fila seleccionada
             Postor postorSeleccionado = dgvPostores.CurrentRow.DataBoundItem as Postor;
             if (postorSeleccionado == null)
             {
                 MessageBox.Show("La fila seleccionada no contiene un postor válido.");
                 return;
             }

             string nuevoEmail = txtEmail.Text;

             if (AppContext.PostorController.ModificarEmailPostor(postorSeleccionado.Id, nuevoEmail))
             {
                 ActualizardgvPostores();
                 MessageBox.Show("Email modificado correctamente.");
             }

             else
                 MessageBox.Show("No se pudo modificar el email.");
         }
         private void btnEliminarPostor_Click(object sender, EventArgs e)
         {
             if (dgvPostores.CurrentRow == null || dgvPostores.CurrentRow.Index < 0)
             {
                 MessageBox.Show("Debe seleccionar un postor para eliminar.");
                 return;
             }

             Postor postorSeleccionado = dgvPostores.CurrentRow.DataBoundItem as Postor;
             if (postorSeleccionado == null)
             {
                 MessageBox.Show("La fila seleccionada no contiene un postor válido.");
                 return;
             }


             if (postorController.EliminarPostor(postorSeleccionado.Id))
             {
                 MessageBox.Show("Postor eliminado correctamente.");
             }

             else
                 MessageBox.Show("No se pudo eliminar el postor.");

             ActualizardgvPostores();

         }*/



    }
}

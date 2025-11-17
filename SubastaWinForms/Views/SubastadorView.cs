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
using System.Timers;
using SubastaWinForms.Model.Entities;
using System.Collections;
using SubastaWinForms.Repositories;

namespace SubastaWinForms.Views
{

    public partial class SubastadorView : Form
    {

        private readonly SubastaController subastaController;
        private readonly SubastadorController subastadorController;
        public SubastadorView()
        {
            InitializeComponent();
            subastaController = AppContext.SubastaController;
            subastadorController = AppContext.SubastadorController; // 👈 faltaba esto
            dgvSubastas.AutoGenerateColumns = false;
        }

        //--------------------------------------------------------------------------------------------------------
        private void dgvSubastas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvSubastas.CurrentRow == null) return;
                Subasta subasta = dgvSubastas.CurrentRow.DataBoundItem as Subasta;
                if (subasta == null) return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------

        private void ActualizarDgvSubastas()
        {
            dgvSubastas.SelectionChanged -= dgvSubastas_SelectionChanged;
            dgvSubastas.ClearSelection();

            //subastas = subastaController.ObtenerSubastas();

            dgvSubastas.DataSource = null;
            dgvSubastas.AutoGenerateColumns = false;
            dgvSubastas.Columns.Clear();

            dgvSubastas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Subastador",
                DataPropertyName = "Subastador" // usa ToString() de Subastador
            });

            dgvSubastas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Artículo",
                DataPropertyName = "Articulo" // usa ToString() de Articulo
            });

            dgvSubastas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Puja Inicial",
                DataPropertyName = "PujaInicial"
            });

            dgvSubastas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Puja de Aumento",
                DataPropertyName = "PujaDeAumento"
            });
            dgvSubastas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ganancia",
                DataPropertyName = "Ganancia" // usa la propiedad calculada
            });


            dgvSubastas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha Inicio",
                DataPropertyName = "FechaInicio"
            });

            dgvSubastas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Duración",
                DataPropertyName = "Duracion"
            });


            dgvSubastas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ganador",
                DataPropertyName = "Ganador" // usa ToString() de Postor
            });

            dgvSubastas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Monto Actual",
                DataPropertyName = "MontoActual"
            });

            dgvSubastas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tiempo Restante",
                DataPropertyName = "TiempoRestante"
            });

            dgvSubastas.DataSource = AppContext.SubastaController.ObtenerSubastas();
            dgvSubastas.SelectionChanged += dgvSubastas_SelectionChanged;
        }


        //-------------------------------VALIDACIONES-------------------------------------------------------------------------
        private bool ValidarDatosArticulo(out string nombreArticulo, out string detalleArticulo)
        {
            nombreArticulo = txtArticuloNombre.Text.Trim();
            detalleArticulo = txtArticuloDetalle.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreArticulo) || string.IsNullOrWhiteSpace(detalleArticulo))
            {
                MessageBox.Show("Debe completar nombre y detalle del artículo.");
                return false;
            }

            return true;
        }

        private bool ValidarDuracion(out TimeSpan duracion)
        {
            duracion = TimeSpan.Zero;

            if (string.IsNullOrWhiteSpace(txtDuracion.Text))
            {
                MessageBox.Show("Debe ingresar una duración.");
                return false;
            }

            if (!int.TryParse(txtDuracion.Text, out int minutos) || minutos < 1)
            {
                MessageBox.Show("La duración debe ser un número válido, mínimo de un minuto.");
                return false;
            }

            duracion = TimeSpan.FromMinutes(minutos);
            return true;
        }

        private bool ValidarMontos(out decimal montoInicial, out decimal pujaDeAumento)
        {
            montoInicial = 0;
            pujaDeAumento = 0;

            if (!decimal.TryParse(txtMontoInicial.Text, out montoInicial) ||
                !decimal.TryParse(txtPujaDeAumento.Text, out pujaDeAumento))
            {
                MessageBox.Show("Debe ingresar valores numéricos válidos para monto inicial y puja.");
                return false;
            }

            return true;
        }

        private bool ConfirmarSubasta(string nombreSubastador, string emailSubastador,
                              string nombreArticulo, string detalleArticulo,
                              decimal montoInicial, decimal pujaDeAumento,
                              TimeSpan duracion)
        {
            string resumen = $"¿Está seguro que desea iniciar la siguiente subasta?\n\n" +
                             $"🧑 Subastador:\n" +
                             $"- Nombre: {nombreSubastador}\n" +
                             $"- Email: {emailSubastador}\n\n" +
                             $"📦 Artículo:\n" +
                             $"- Nombre: {nombreArticulo}\n" +
                             $"- Detalle: {detalleArticulo}\n\n" +
                             $"💰 Subasta:\n" +
                             $"- Monto inicial: {montoInicial:C}\n" +
                             $"- Puja mínima: {pujaDeAumento:C}\n" +
                             $"- Duración en minutos: {(int)duracion.TotalMinutes}";

            DialogResult confirmacion = MessageBox.Show(resumen, "Confirmar subasta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return confirmacion == DialogResult.Yes;
        }

        private void SuscribirseAFinalizacion(Subasta subasta)
        {
            subasta.EventoSubastaFinalizada += (s, e) =>
            {
                if (IsHandleCreated)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        string mensaje = $"La subasta #{subasta.NumeroDeSubasta} ha finalizado.";

                        if (subasta.Ganador != null)
                        {
                            mensaje += $"\n\n🏆 Ganador: {subasta.Ganador.Nombre}" +
                                       $"\n💰 Monto final: {subasta.MontoActual}" +
                                       $"\n $ Ganancia: {subasta.MontoActual - subasta.PujaInicial}" +
                                       $"\n📦 Artículo: {subasta.Articulo.Name}";
                        }
                        else
                        {
                            mensaje += "\n\nNo hubo pujas registradas.";
                        }

                        MessageBox.Show(mensaje, "Subasta finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarDgvSubastas();
                    }));
                }
            };
        }

        //--------------------------------------------------------------------------------------------------------

        private void btnIniciarSubasta_Click(object sender, EventArgs e)
        {
            Subastador? subastador = AppContext.SubastadorActual;

            if (subastador == null)
            {
                MessageBox.Show("No hay subastador activo.");
                return;
            }

            if (!ValidarDatosArticulo(out string nombreArticulo, out string detalleArticulo))
                return;

            if (!ValidarDuracion(out TimeSpan duracion))
                return;

            if (!ValidarMontos(out decimal montoInicial, out decimal pujaDeAumento))
                return;

            if (!ConfirmarSubasta(subastador.Nombre, subastador.Email,
                                  nombreArticulo, detalleArticulo,
                                  montoInicial, pujaDeAumento, duracion))
                return;

            Subasta? nuevaSubasta = subastaController.RegistrarSubastaCompleta(
                AppContext.SubastadorActual,
                nombreArticulo, detalleArticulo,
                montoInicial, pujaDeAumento, duracion);

            if (nuevaSubasta != null)
            {
                ActualizarDgvSubastas();
                MessageBox.Show("Subasta creada correctamente.");
                SuscribirseAFinalizacion(nuevaSubasta);
            }
            else
            {
                MessageBox.Show("No se pudo crear la subasta. Verifique los datos ingresados.");
            }
        }
        private void SubastadorView_Load(object sender, EventArgs e)
        {
            ActualizarDgvSubastas(); // ← carga los datos
            lblSubastadorActivo.Text = $"Subastador: {AppContext.SubastadorActual?.Nombre}";
            lblSubastadorActivo.Visible = true;

        }
        /*private void OcultarSubasta()
        {
            if (dgvSubastas.CurrentRow != null)
            {
                subastas.Remove((Subasta)dgvSubastas.CurrentRow.DataBoundItem);
                dgvSubastas.DataSource = null;
                dgvSubastas.DataSource = subastas;
            }
                
        }

        private void QuitarSubastaBTN_Click(object sender, EventArgs e)
        {
            OcultarSubasta();
        }*/
        public static Subasta RevisarGanador(Postor actual)
        {
            foreach (var subasta in AppContext.SubastaController.ObtenerSubastas())
            {
                if (subasta.Ganador != null && subasta.Ganador.Id == actual.Id)
                {
                    return subasta; // devuelve la primera subasta donde el postor es ganador
                }
            }
            return null; // si no ganó en ninguna
        }

        private void btnModificarNombre_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtEditarNombre.Text;
            int idSubastadorActual = AppContext.SubastadorActual.Id;
            bool resultado = subastadorController.ModificarNombreSubastador(idSubastadorActual, nuevoNombre);

            if (resultado)
            {
                MessageBox.Show("Cambio exitoso");
                lblSubastadorActivo.Text = $"Subastador: {nuevoNombre}";
            }
            else
            {
                MessageBox.Show("Intente de nuevo");
            }
        }

        private void btnModificarEmail_Click(object sender, EventArgs e)
        {
            string nuevoEmail = txtEditarEmail.Text;
            int idSubastadorActual = AppContext.SubastadorActual.Id;
            bool resultado = subastadorController.ModificarEmailSubastador(idSubastadorActual, nuevoEmail);

            if (resultado)
            {
                MessageBox.Show("Cambio exitoso");
            }
            else
            {
                MessageBox.Show("Intente de nuevo");
            }
        }

        private void btnEliminarSubastador_Click(object sender, EventArgs e)
        {
            int subastadorPorEliminar = AppContext.SubastadorActual.Id;
            bool resultado = subastadorController.EliminarSubastador(subastadorPorEliminar);
            if (resultado)
            {
                MessageBox.Show("Subastador eliminado correctamente.");
                AppContext.SubastadorActual = null; 
                           
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el subastador.");
            }
        }

    }
}
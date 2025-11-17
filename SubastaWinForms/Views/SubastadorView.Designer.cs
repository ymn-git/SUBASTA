namespace SubastaWinForms.Views
{
    partial class SubastadorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Subastaslbl = new Label();
            dgvSubastas = new DataGridView();
            lblSubastador = new Label();
            lblArticulo = new Label();
            lblSubastaDetalle = new Label();
            txtArticuloNombre = new TextBox();
            txtArticuloDetalle = new TextBox();
            txtMontoInicial = new TextBox();
            txtPujaDeAumento = new TextBox();
            btnIniciarSubasta = new Button();
            txtDuracion = new TextBox();
            lblSubastadorActivo = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtEditarNombre = new TextBox();
            txtEditarEmail = new TextBox();
            btnEliminar = new Button();
            btnModificarNombre = new Button();
            btnModificarEmail = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).BeginInit();
            SuspendLayout();
            // 
            // Subastaslbl
            // 
            Subastaslbl.AutoSize = true;
            Subastaslbl.Font = new Font("Segoe UI", 20F);
            Subastaslbl.Location = new Point(12, 9);
            Subastaslbl.Name = "Subastaslbl";
            Subastaslbl.Size = new Size(151, 46);
            Subastaslbl.TabIndex = 299;
            Subastaslbl.Text = "Subastas";
            Subastaslbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // dgvSubastas
            // 
            dgvSubastas.AllowUserToAddRows = false;
            dgvSubastas.AllowUserToResizeColumns = false;
            dgvSubastas.AllowUserToResizeRows = false;
            dgvSubastas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubastas.Location = new Point(12, 376);
            dgvSubastas.MultiSelect = false;
            dgvSubastas.Name = "dgvSubastas";
            dgvSubastas.ReadOnly = true;
            dgvSubastas.RowHeadersWidth = 40;
            dgvSubastas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.Size = new Size(1418, 321);
            dgvSubastas.TabIndex = 100;
            dgvSubastas.VirtualMode = true;
            dgvSubastas.SelectionChanged += dgvSubastas_SelectionChanged;
            // 
            // lblSubastador
            // 
            lblSubastador.AutoSize = true;
            lblSubastador.Font = new Font("Segoe UI", 14F);
            lblSubastador.Location = new Point(198, 20);
            lblSubastador.Name = "lblSubastador";
            lblSubastador.Size = new Size(206, 32);
            lblSubastador.TabIndex = 300;
            lblSubastador.Text = "Subastador Activo";
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Font = new Font("Segoe UI", 14F);
            lblArticulo.Location = new Point(102, 328);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(96, 32);
            lblArticulo.TabIndex = 9;
            lblArticulo.Text = "Articulo";
            // 
            // lblSubastaDetalle
            // 
            lblSubastaDetalle.AutoSize = true;
            lblSubastaDetalle.Font = new Font("Segoe UI", 14F);
            lblSubastaDetalle.Location = new Point(716, 329);
            lblSubastaDetalle.Name = "lblSubastaDetalle";
            lblSubastaDetalle.Size = new Size(89, 32);
            lblSubastaDetalle.TabIndex = 10;
            lblSubastaDetalle.Text = "Detalle";
            // 
            // txtArticuloNombre
            // 
            txtArticuloNombre.Location = new Point(211, 334);
            txtArticuloNombre.Name = "txtArticuloNombre";
            txtArticuloNombre.PlaceholderText = "Nombre";
            txtArticuloNombre.Size = new Size(133, 27);
            txtArticuloNombre.TabIndex = 1;
            // 
            // txtArticuloDetalle
            // 
            txtArticuloDetalle.Location = new Point(350, 333);
            txtArticuloDetalle.Name = "txtArticuloDetalle";
            txtArticuloDetalle.PlaceholderText = "Detalle";
            txtArticuloDetalle.Size = new Size(133, 27);
            txtArticuloDetalle.TabIndex = 2;
            // 
            // txtMontoInicial
            // 
            txtMontoInicial.Location = new Point(811, 333);
            txtMontoInicial.Name = "txtMontoInicial";
            txtMontoInicial.PlaceholderText = "Monto Inicial";
            txtMontoInicial.Size = new Size(145, 27);
            txtMontoInicial.TabIndex = 3;
            // 
            // txtPujaDeAumento
            // 
            txtPujaDeAumento.Location = new Point(962, 334);
            txtPujaDeAumento.Name = "txtPujaDeAumento";
            txtPujaDeAumento.PlaceholderText = "Puja de Aumento";
            txtPujaDeAumento.Size = new Size(145, 27);
            txtPujaDeAumento.TabIndex = 4;
            // 
            // btnIniciarSubasta
            // 
            btnIniciarSubasta.BackColor = Color.Lime;
            btnIniciarSubasta.ForeColor = SystemColors.ButtonHighlight;
            btnIniciarSubasta.Location = new Point(1312, 296);
            btnIniciarSubasta.Name = "btnIniciarSubasta";
            btnIniciarSubasta.Size = new Size(118, 65);
            btnIniciarSubasta.TabIndex = 6;
            btnIniciarSubasta.Text = "INICIAR SUBASTA";
            btnIniciarSubasta.UseVisualStyleBackColor = false;
            btnIniciarSubasta.Click += btnIniciarSubasta_Click;
            // 
            // txtDuracion
            // 
            txtDuracion.Location = new Point(1113, 333);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.PlaceholderText = "Duración en minutos";
            txtDuracion.Size = new Size(145, 27);
            txtDuracion.TabIndex = 5;
            // 
            // lblSubastadorActivo
            // 
            lblSubastadorActivo.AutoSize = true;
            lblSubastadorActivo.Font = new Font("Segoe UI", 16F);
            lblSubastadorActivo.ForeColor = Color.DarkRed;
            lblSubastadorActivo.Location = new Point(423, 15);
            lblSubastadorActivo.Name = "lblSubastadorActivo";
            lblSubastadorActivo.Size = new Size(0, 37);
            lblSubastadorActivo.TabIndex = 101;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(211, 67);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 198;
            label1.Text = "Editar Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(211, 99);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 199;
            label2.Text = "Editar Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(211, 134);
            label3.Name = "label3";
            label3.Size = new Size(142, 20);
            label3.TabIndex = 200;
            label3.Text = "Eliminar Subastador";
            // 
            // txtEditarNombre
            // 
            txtEditarNombre.Location = new Point(400, 64);
            txtEditarNombre.Name = "txtEditarNombre";
            txtEditarNombre.PlaceholderText = "Nuevo nombre";
            txtEditarNombre.Size = new Size(125, 27);
            txtEditarNombre.TabIndex = 98;
            // 
            // txtEditarEmail
            // 
            txtEditarEmail.Location = new Point(400, 97);
            txtEditarEmail.Name = "txtEditarEmail";
            txtEditarEmail.PlaceholderText = "Nuevo Email";
            txtEditarEmail.Size = new Size(125, 27);
            txtEditarEmail.TabIndex = 99;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(431, 130);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 100;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            //btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificarNombre
            // 
            btnModificarNombre.Location = new Point(531, 64);
            btnModificarNombre.Name = "btnModificarNombre";
            btnModificarNombre.Size = new Size(94, 29);
            btnModificarNombre.TabIndex = 301;
            btnModificarNombre.Text = "Editar";
            btnModificarNombre.UseVisualStyleBackColor = true;
            btnModificarNombre.Click += btnModificarNombre_Click;
            // 
            // btnModificarEmail
            // 
            btnModificarEmail.Location = new Point(531, 97);
            btnModificarEmail.Name = "btnModificarEmail";
            btnModificarEmail.Size = new Size(94, 29);
            btnModificarEmail.TabIndex = 302;
            btnModificarEmail.Text = "Editar";
            btnModificarEmail.UseVisualStyleBackColor = true;
            btnModificarEmail.Click += btnModificarEmail_Click;
            // 
            // SubastadorView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1444, 699);
            Controls.Add(btnModificarEmail);
            Controls.Add(btnModificarNombre);
            Controls.Add(btnEliminar);
            Controls.Add(txtEditarEmail);
            Controls.Add(txtEditarNombre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblSubastadorActivo);
            Controls.Add(txtDuracion);
            Controls.Add(btnIniciarSubasta);
            Controls.Add(txtPujaDeAumento);
            Controls.Add(txtMontoInicial);
            Controls.Add(txtArticuloDetalle);
            Controls.Add(txtArticuloNombre);
            Controls.Add(lblSubastaDetalle);
            Controls.Add(lblArticulo);
            Controls.Add(lblSubastador);
            Controls.Add(dgvSubastas);
            Controls.Add(Subastaslbl);
            Name = "SubastadorView";
            Text = "SubastadorView";
            Load += SubastadorView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Subastaslbl;
        private DataGridView dgvSubastas;
        private Label lblSubastador;
        private Label lblArticulo;
        private Label lblSubastaDetalle;
        private TextBox txtArticuloNombre;
        private TextBox txtArticuloDetalle;
        private TextBox txtMontoInicial;
        private TextBox txtPujaDeAumento;
        private Button btnIniciarSubasta;
        private TextBox txtDuracion;
        private Label lblSubastadorActivo;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtEditarNombre;
        private TextBox txtEditarEmail;
        private Button btnEliminar;
        private Button btnModificarNombre;
        private Button btnModificarEmail;
    }
}
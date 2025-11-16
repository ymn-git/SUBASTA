namespace SubastaWinForms
{
    partial class PostorView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvSubastas = new DataGridView();
            lblPostor = new Label();
            lblSubastas = new Label();
            btnPujar = new Button();
            lblPostorActivo = new Label();
            nuevoNombreTXT = new TextBox();
            nuevoEmailTXT = new TextBox();
            modificarNombreTXT = new Button();
            modificarEmailTXT = new Button();
            eliminarBTN = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).BeginInit();
            SuspendLayout();
            // 
            // dgvSubastas
            // 
            dgvSubastas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubastas.Location = new Point(12, 435);
            dgvSubastas.Name = "dgvSubastas";
            dgvSubastas.RowHeadersWidth = 51;
            dgvSubastas.Size = new Size(776, 147);
            dgvSubastas.TabIndex = 11;
            // 
            // lblPostor
            // 
            lblPostor.AutoSize = true;
            lblPostor.Font = new Font("Segoe UI", 20F);
            lblPostor.Location = new Point(12, 9);
            lblPostor.Name = "lblPostor";
            lblPostor.Size = new Size(219, 46);
            lblPostor.TabIndex = 8;
            lblPostor.Text = "Postor Activo";
            // 
            // lblSubastas
            // 
            lblSubastas.AutoSize = true;
            lblSubastas.Font = new Font("Segoe UI", 20F);
            lblSubastas.Location = new Point(12, 325);
            lblSubastas.Name = "lblSubastas";
            lblSubastas.Size = new Size(151, 46);
            lblSubastas.TabIndex = 9;
            lblSubastas.Text = "Subastas";
            // 
            // btnPujar
            // 
            btnPujar.Location = new Point(12, 391);
            btnPujar.Name = "btnPujar";
            btnPujar.Size = new Size(94, 29);
            btnPujar.TabIndex = 7;
            btnPujar.Text = "Pujar";
            btnPujar.UseVisualStyleBackColor = true;
            btnPujar.Click += btnPujar_Click;
            // 
            // lblPostorActivo
            // 
            lblPostorActivo.AutoSize = true;
            lblPostorActivo.Enabled = false;
            lblPostorActivo.Font = new Font("Segoe UI", 16F);
            lblPostorActivo.ForeColor = Color.DarkRed;
            lblPostorActivo.Location = new Point(74, 118);
            lblPostorActivo.Name = "lblPostorActivo";
            lblPostorActivo.Size = new Size(0, 37);
            lblPostorActivo.TabIndex = 12;
            lblPostorActivo.Visible = false;
            // 
            // nuevoNombreTXT
            // 
            nuevoNombreTXT.Location = new Point(500, 65);
            nuevoNombreTXT.Name = "nuevoNombreTXT";
            nuevoNombreTXT.PlaceholderText = "Nuevo nombre";
            nuevoNombreTXT.Size = new Size(125, 27);
            nuevoNombreTXT.TabIndex = 13;
            // 
            // nuevoEmailTXT
            // 
            nuevoEmailTXT.Location = new Point(500, 118);
            nuevoEmailTXT.Name = "nuevoEmailTXT";
            nuevoEmailTXT.PlaceholderText = "Nuevo email";
            nuevoEmailTXT.Size = new Size(125, 27);
            nuevoEmailTXT.TabIndex = 14;
            // 
            // modificarNombreTXT
            // 
            modificarNombreTXT.Location = new Point(650, 65);
            modificarNombreTXT.Name = "modificarNombreTXT";
            modificarNombreTXT.Size = new Size(94, 29);
            modificarNombreTXT.TabIndex = 15;
            modificarNombreTXT.Text = "Modificar";
            modificarNombreTXT.UseVisualStyleBackColor = true;
            modificarNombreTXT.Click += modificarNombreTXT_Click;
            // 
            // modificarEmailTXT
            // 
            modificarEmailTXT.Location = new Point(650, 118);
            modificarEmailTXT.Name = "modificarEmailTXT";
            modificarEmailTXT.Size = new Size(94, 29);
            modificarEmailTXT.TabIndex = 16;
            modificarEmailTXT.Text = "Modificar";
            modificarEmailTXT.UseVisualStyleBackColor = true;
            modificarEmailTXT.Click += modificarEmailTXT_Click;
            // 
            // eliminarBTN
            // 
            eliminarBTN.Location = new Point(650, 172);
            eliminarBTN.Name = "eliminarBTN";
            eliminarBTN.Size = new Size(94, 29);
            eliminarBTN.TabIndex = 17;
            eliminarBTN.Text = "Eliminar";
            eliminarBTN.UseVisualStyleBackColor = true;
            eliminarBTN.Click += eliminarBTN_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(387, 72);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 18;
            label1.Text = "Editar Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(387, 118);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 19;
            label2.Text = "Editar Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(508, 181);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 20;
            label3.Text = "Eliminar Usuario";
            // 
            // PostorView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 618);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(eliminarBTN);
            Controls.Add(modificarEmailTXT);
            Controls.Add(modificarNombreTXT);
            Controls.Add(nuevoEmailTXT);
            Controls.Add(nuevoNombreTXT);
            Controls.Add(lblPostorActivo);
            Controls.Add(btnPujar);
            Controls.Add(lblSubastas);
            Controls.Add(lblPostor);
            Controls.Add(dgvSubastas);
            Name = "PostorView";
            Text = "Form1";
            Load += PostorView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvSubastas;
        private Label lblPostor;
        private Label lblSubastas;
        private Button btnPujar;
        private Label lblPostorActivo;
        private TextBox nuevoNombreTXT;
        private TextBox nuevoEmailTXT;
        private Button modificarNombreTXT;
        private Button modificarEmailTXT;
        private Button eliminarBTN;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}

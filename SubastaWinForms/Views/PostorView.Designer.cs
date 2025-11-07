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
            lblPostor.Location = new Point(12, 48);
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
            // PostorView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 618);
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
    }
}

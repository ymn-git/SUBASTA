namespace SubastaWinForms.Views
{
    partial class TestView
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
            btnPostorView = new Button();
            btnSubastadorView = new Button();
            IngresarNombreTXT = new TextBox();
            IngresarEmailTXT = new TextBox();
            Aceptar = new Button();
            rbPostor = new RadioButton();
            rbSubastador = new RadioButton();
            label1 = new Label();
            IngresarContrasenaTXT = new TextBox();
            SuspendLayout();
            // 
            // btnPostorView
            // 
            btnPostorView.Enabled = false;
            btnPostorView.Location = new Point(239, 409);
            btnPostorView.Name = "btnPostorView";
            btnPostorView.Size = new Size(136, 29);
            btnPostorView.TabIndex = 7;
            btnPostorView.Text = "Acceso postores";
            btnPostorView.UseVisualStyleBackColor = true;
            btnPostorView.Click += PostorView_Click;
            // 
            // btnSubastadorView
            // 
            btnSubastadorView.Enabled = false;
            btnSubastadorView.Location = new Point(402, 408);
            btnSubastadorView.Name = "btnSubastadorView";
            btnSubastadorView.Size = new Size(155, 31);
            btnSubastadorView.TabIndex = 8;
            btnSubastadorView.Text = "Acceso subastadores";
            btnSubastadorView.UseVisualStyleBackColor = true;
            btnSubastadorView.Click += subastadorView_Click;
            // 
            // IngresarNombreTXT
            // 
            IngresarNombreTXT.BackColor = Color.White;
            IngresarNombreTXT.Location = new Point(331, 154);
            IngresarNombreTXT.Name = "IngresarNombreTXT";
            IngresarNombreTXT.PlaceholderText = "Nombre";
            IngresarNombreTXT.Size = new Size(125, 27);
            IngresarNombreTXT.TabIndex = 3;
            // 
            // IngresarEmailTXT
            // 
            IngresarEmailTXT.BackColor = SystemColors.Control;
            IngresarEmailTXT.ForeColor = SystemColors.WindowText;
            IngresarEmailTXT.Location = new Point(331, 220);
            IngresarEmailTXT.Name = "IngresarEmailTXT";
            IngresarEmailTXT.PlaceholderText = "Email";
            IngresarEmailTXT.Size = new Size(125, 27);
            IngresarEmailTXT.TabIndex = 4;
            // 
            // Aceptar
            // 
            Aceptar.Location = new Point(344, 334);
            Aceptar.Name = "Aceptar";
            Aceptar.Size = new Size(94, 29);
            Aceptar.TabIndex = 6;
            Aceptar.Text = "Aceptar";
            Aceptar.UseVisualStyleBackColor = true;
            Aceptar.Click += Aceptar_Click;
            // 
            // rbPostor
            // 
            rbPostor.AutoSize = true;
            rbPostor.ForeColor = SystemColors.Control;
            rbPostor.Location = new Point(318, 73);
            rbPostor.Name = "rbPostor";
            rbPostor.Size = new Size(171, 24);
            rbPostor.TabIndex = 1;
            rbPostor.TabStop = true;
            rbPostor.Text = "Acceder como Postor";
            rbPostor.UseVisualStyleBackColor = true;
            // 
            // rbSubastador
            // 
            rbSubastador.AutoSize = true;
            rbSubastador.ForeColor = SystemColors.Control;
            rbSubastador.Location = new Point(318, 103);
            rbSubastador.Name = "rbSubastador";
            rbSubastador.Size = new Size(205, 24);
            rbSubastador.TabIndex = 2;
            rbSubastador.TabStop = true;
            rbSubastador.Text = "Acceder como Subastador";
            rbSubastador.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Symbol", 30F, FontStyle.Bold, GraphicsUnit.Point, 2);
            label1.ForeColor = Color.FromArgb(255, 128, 128);
            label1.Location = new Point(249, 9);
            label1.Name = "label1";
            label1.Size = new Size(296, 61);
            label1.TabIndex = 99;
            label1.Text = "SUBASTAS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IngresarContrasenaTXT
            // 
            IngresarContrasenaTXT.Location = new Point(331, 253);
            IngresarContrasenaTXT.Name = "IngresarContrasenaTXT";
            IngresarContrasenaTXT.PlaceholderText = "Contrasena";
            IngresarContrasenaTXT.Size = new Size(125, 27);
            IngresarContrasenaTXT.TabIndex = 5;
            // 
            // TestView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(IngresarContrasenaTXT);
            Controls.Add(label1);
            Controls.Add(rbSubastador);
            Controls.Add(rbPostor);
            Controls.Add(Aceptar);
            Controls.Add(IngresarEmailTXT);
            Controls.Add(IngresarNombreTXT);
            Controls.Add(btnSubastadorView);
            Controls.Add(btnPostorView);
            Name = "TestView";
            Text = "TestView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPostorView;
        private Button btnSubastadorView;
        private TextBox IngresarNombreTXT;
        private TextBox IngresarEmailTXT;
        private Button Aceptar;
        private RadioButton rbPostor;
        private RadioButton rbSubastador;
        private Label label1;
        private TextBox IngresarContrasenaTXT;
    }
}
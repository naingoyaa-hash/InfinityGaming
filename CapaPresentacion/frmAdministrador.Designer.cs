namespace InfinityGaming
{
    partial class frmAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministrador));
            this.pnlAdministrador = new System.Windows.Forms.Panel();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbVentas = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbDisponibles = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAdministrador
            // 
            this.pnlAdministrador.Location = new System.Drawing.Point(212, 82);
            this.pnlAdministrador.Name = "pnlAdministrador";
            this.pnlAdministrador.Size = new System.Drawing.Size(711, 390);
            this.pnlAdministrador.TabIndex = 4;
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReporte.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReporte.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.Color.Purple;
            this.btnReporte.Image = global::InfinityGaming.Properties.Resources.reporte;
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.Location = new System.Drawing.Point(12, 183);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(169, 36);
            this.btnReporte.TabIndex = 19;
            this.btnReporte.Text = "REPORTES";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUsuario.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsuario.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.Color.Purple;
            this.btnUsuario.Image = global::InfinityGaming.Properties.Resources.usuario;
            this.btnUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuario.Location = new System.Drawing.Point(12, 130);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(169, 36);
            this.btnUsuario.TabIndex = 20;
            this.btnUsuario.Text = "USUARIOS";
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Image = global::InfinityGaming.Properties.Resources.Cerrar;
            this.btnCerrar.Location = new System.Drawing.Point(892, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(31, 32);
            this.btnCerrar.TabIndex = 21;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.groupBox3.Controls.Add(this.lbVentas);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Plum;
            this.groupBox3.Location = new System.Drawing.Point(6, 352);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "VENTAS DEL DIA";
            // 
            // lbVentas
            // 
            this.lbVentas.AutoSize = true;
            this.lbVentas.Location = new System.Drawing.Point(83, 54);
            this.lbVentas.Name = "lbVentas";
            this.lbVentas.Size = new System.Drawing.Size(19, 23);
            this.lbVentas.TabIndex = 1;
            this.lbVentas.Text = "0";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(0, 25);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(76, 75);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Purple;
            this.groupBox2.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.groupBox2.Controls.Add(this.lbDisponibles);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Plum;
            this.groupBox2.Location = new System.Drawing.Point(6, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EQUIPOS DISPONIBLES";
            // 
            // lbDisponibles
            // 
            this.lbDisponibles.AutoSize = true;
            this.lbDisponibles.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbDisponibles.Location = new System.Drawing.Point(92, 54);
            this.lbDisponibles.Name = "lbDisponibles";
            this.lbDisponibles.Size = new System.Drawing.Size(19, 23);
            this.lbDisponibles.TabIndex = 1;
            this.lbDisponibles.Text = "0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(0, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(85, 75);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // frmAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InfinityGaming.Properties.Resources.Captura_de_pantalla_2026_01_14_210958;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(935, 484);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.pnlAdministrador);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdministrador";
            this.Load += new System.EventHandler(this.frmAdministrador_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlAdministrador;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbVentas;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbDisponibles;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
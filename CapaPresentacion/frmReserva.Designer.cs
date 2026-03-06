namespace InfinityGaming.CapaPresentacion
{
    partial class frmReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReserva));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.bntIniciar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtPersona = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpInicioReserva = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFinReserva = new System.Windows.Forms.DateTimePicker();
            this.cmbEquipo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Image = global::InfinityGaming.Properties.Resources.Cerrar;
            this.btnCerrar.Location = new System.Drawing.Point(1046, -2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(31, 32);
            this.btnCerrar.TabIndex = 31;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Purple;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(704, 388);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(169, 36);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "CANCELAR RESERVA";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.Purple;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(243, 388);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(169, 36);
            this.btnEditar.TabIndex = 36;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRegistrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegistrar.BackgroundImage")));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.Purple;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(12, 388);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(169, 36);
            this.btnRegistrar.TabIndex = 35;
            this.btnRegistrar.Text = "REGISTRAR";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(428, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 28);
            this.label1.TabIndex = 32;
            this.label1.Text = "GESTIONAR RESERVAS";
            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(433, 154);
            this.dgvReservas.MultiSelect = false;
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(483, 214);
            this.dgvReservas.TabIndex = 33;
            this.dgvReservas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservas_CellClick);
            this.dgvReservas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvReservas_CellFormatting);
            // 
            // bntIniciar
            // 
            this.bntIniciar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bntIniciar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntIniciar.BackgroundImage")));
            this.bntIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntIniciar.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntIniciar.ForeColor = System.Drawing.Color.Purple;
            this.bntIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntIniciar.Location = new System.Drawing.Point(465, 388);
            this.bntIniciar.Name = "bntIniciar";
            this.bntIniciar.Size = new System.Drawing.Size(169, 36);
            this.bntIniciar.TabIndex = 39;
            this.bntIniciar.Text = "INICIAR RESERVA";
            this.bntIniciar.UseVisualStyleBackColor = false;
            this.bntIniciar.Click += new System.EventHandler(this.bntIniciar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtPersona);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpInicioReserva);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpFinReserva);
            this.groupBox1.Controls.Add(this.cmbEquipo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Plum;
            this.groupBox1.Location = new System.Drawing.Point(2, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 226);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NUEVA RESERVA";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Plum;
            this.btnBuscar.Location = new System.Drawing.Point(343, 86);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 29);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtPersona
            // 
            this.txtPersona.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersona.Location = new System.Drawing.Point(137, 87);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.ReadOnly = true;
            this.txtPersona.Size = new System.Drawing.Size(192, 29);
            this.txtPersona.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Plum;
            this.label4.Image = global::InfinityGaming.Properties.Resources.WhatsApp_Image_2026_01_10_at_9_22_44_PM;
            this.label4.Location = new System.Drawing.Point(29, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "CLIENTES";
            // 
            // dtpInicioReserva
            // 
            this.dtpInicioReserva.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicioReserva.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicioReserva.Location = new System.Drawing.Point(137, 129);
            this.dtpInicioReserva.Name = "dtpInicioReserva";
            this.dtpInicioReserva.Size = new System.Drawing.Size(273, 25);
            this.dtpInicioReserva.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Plum;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(26, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "FIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Plum;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(26, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "INICIO ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Plum;
            this.label5.Image = global::InfinityGaming.Properties.Resources.WhatsApp_Image_2026_01_10_at_9_22_44_PM;
            this.label5.Location = new System.Drawing.Point(29, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "EQUIPO";
            // 
            // dtpFinReserva
            // 
            this.dtpFinReserva.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinReserva.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinReserva.Location = new System.Drawing.Point(137, 174);
            this.dtpFinReserva.Name = "dtpFinReserva";
            this.dtpFinReserva.Size = new System.Drawing.Size(273, 25);
            this.dtpFinReserva.TabIndex = 2;
            // 
            // cmbEquipo
            // 
            this.cmbEquipo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbEquipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEquipo.FormattingEnabled = true;
            this.cmbEquipo.Location = new System.Drawing.Point(137, 51);
            this.cmbEquipo.Name = "cmbEquipo";
            this.cmbEquipo.Size = new System.Drawing.Size(273, 25);
            this.cmbEquipo.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::InfinityGaming.Properties.Resources.Cerrar;
            this.button1.Location = new System.Drawing.Point(885, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 32);
            this.button1.TabIndex = 41;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InfinityGaming.Properties.Resources.reservas1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(927, 443);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bntIniciar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.btnCerrar);
            this.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReserva";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmReserva_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Button bntIniciar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtPersona;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpInicioReserva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFinReserva;
        private System.Windows.Forms.ComboBox cmbEquipo;
        private System.Windows.Forms.Button button1;
    }
}
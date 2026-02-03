namespace InfinityGaming
{
    partial class frmJuegos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJuegos));
            this.label1 = new System.Windows.Forms.Label();
            this.lblCantidadJuegos = new System.Windows.Forms.Label();
            this.dgvJuegos = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJuegos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Violet;
            this.label1.Location = new System.Drawing.Point(2, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "JUEGOS DISPONIBLES:";
            // 
            // lblCantidadJuegos
            // 
            this.lblCantidadJuegos.AutoSize = true;
            this.lblCantidadJuegos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCantidadJuegos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadJuegos.ForeColor = System.Drawing.Color.Violet;
            this.lblCantidadJuegos.Location = new System.Drawing.Point(172, 111);
            this.lblCantidadJuegos.Name = "lblCantidadJuegos";
            this.lblCantidadJuegos.Size = new System.Drawing.Size(19, 21);
            this.lblCantidadJuegos.TabIndex = 1;
            this.lblCantidadJuegos.Text = "0";
            // 
            // dgvJuegos
            // 
            this.dgvJuegos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJuegos.Location = new System.Drawing.Point(6, 144);
            this.dgvJuegos.Name = "dgvJuegos";
            this.dgvJuegos.Size = new System.Drawing.Size(782, 304);
            this.dgvJuegos.TabIndex = 2;
            this.dgvJuegos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJuegos_CellClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.Plum;
            this.txtBuscar.Location = new System.Drawing.Point(440, 109);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(348, 30);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.Text = "Buscar juegos:";
            this.txtBuscar.Click += new System.EventHandler(this.txtBuscar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Image = global::InfinityGaming.Properties.Resources.Cerrar;
            this.btnCerrar.Location = new System.Drawing.Point(757, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(31, 32);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmJuegos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvJuegos);
            this.Controls.Add(this.lblCantidadJuegos);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJuegos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmJuegos";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmJuegos_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJuegos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCantidadJuegos;
        private System.Windows.Forms.DataGridView dgvJuegos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnCerrar;
    }
}
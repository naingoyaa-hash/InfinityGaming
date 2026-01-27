namespace InfinityGaming
{
    partial class frmFacturas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTarjeta = new System.Windows.Forms.Button();
            this.btnTranferencia = new System.Windows.Forms.Button();
            this.btnEfectivo = new System.Windows.Forms.Button();
            this.dtgFactura = new System.Windows.Forms.DataGridView();
            this.DESCRIPCCIÓN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Image = global::InfinityGaming.Properties.Resources.fondo2;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(62, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "NOMBRE";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Image = global::InfinityGaming.Properties.Resources.fondo2;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "APELLIDO";
            // 
            // tbNombre
            // 
            this.tbNombre.BackColor = System.Drawing.Color.Black;
            this.tbNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNombre.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.ForeColor = System.Drawing.Color.Purple;
            this.tbNombre.Location = new System.Drawing.Point(66, 214);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(198, 23);
            this.tbNombre.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Purple;
            this.groupBox1.Location = new System.Drawing.Point(56, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 158);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DEL CLIENTE";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Purple;
            this.textBox1.Location = new System.Drawing.Point(6, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 23);
            this.textBox1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.groupBox2.Controls.Add(this.btnTarjeta);
            this.groupBox2.Controls.Add(this.btnTranferencia);
            this.groupBox2.Controls.Add(this.btnEfectivo);
            this.groupBox2.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Purple;
            this.groupBox2.Location = new System.Drawing.Point(56, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 138);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "METODO DE PAGO";
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTarjeta.Image = global::InfinityGaming.Properties.Resources.Captura_de_pantalla_2026_01_13_181539;
            this.btnTarjeta.Location = new System.Drawing.Point(90, 62);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(72, 41);
            this.btnTarjeta.TabIndex = 2;
            this.btnTarjeta.UseVisualStyleBackColor = true;
            // 
            // btnTranferencia
            // 
            this.btnTranferencia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTranferencia.Image = global::InfinityGaming.Properties.Resources.Captura_de_pantalla_2026_01_13_181721;
            this.btnTranferencia.Location = new System.Drawing.Point(168, 62);
            this.btnTranferencia.Name = "btnTranferencia";
            this.btnTranferencia.Size = new System.Drawing.Size(76, 41);
            this.btnTranferencia.TabIndex = 1;
            this.btnTranferencia.UseVisualStyleBackColor = true;
            this.btnTranferencia.Click += new System.EventHandler(this.btnTranferencia_Click);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEfectivo.Image = global::InfinityGaming.Properties.Resources.Captura_de_pantalla_2026_01_13_1814471;
            this.btnEfectivo.Location = new System.Drawing.Point(6, 62);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(78, 41);
            this.btnEfectivo.TabIndex = 0;
            this.btnEfectivo.UseVisualStyleBackColor = true;
            // 
            // dtgFactura
            // 
            this.dtgFactura.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.dtgFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DESCRIPCCIÓN,
            this.CANTIDAD,
            this.PRECIO,
            this.Column1});
            this.dtgFactura.Location = new System.Drawing.Point(318, 162);
            this.dtgFactura.Name = "dtgFactura";
            this.dtgFactura.Size = new System.Drawing.Size(444, 140);
            this.dtgFactura.TabIndex = 8;
            // 
            // DESCRIPCCIÓN
            // 
            this.DESCRIPCCIÓN.HeaderText = "DESCRIPCIÓN";
            this.DESCRIPCCIÓN.Name = "DESCRIPCCIÓN";
            this.DESCRIPCCIÓN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CANTIDAD
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CANTIDAD.DefaultCellStyle = dataGridViewCellStyle2;
            this.CANTIDAD.HeaderText = "CANTIDAD";
            this.CANTIDAD.Name = "CANTIDAD";
            // 
            // PRECIO
            // 
            this.PRECIO.HeaderText = "PRECIO";
            this.PRECIO.Name = "PRECIO";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TOTAL";
            this.Column1.Name = "Column1";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.Purple;
            this.linkLabel1.Image = global::InfinityGaming.Properties.Resources.fondo_1;
            this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.LinkColor = System.Drawing.Color.Purple;
            this.linkLabel1.Location = new System.Drawing.Point(313, 134);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(233, 28);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "DETALLES DE CONSUMOS";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Purple;
            this.button1.Location = new System.Drawing.Point(321, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 40);
            this.button1.TabIndex = 10;
            this.button1.Text = "GENERAR FACTURA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Image = global::InfinityGaming.Properties.Resources.fondo_1;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(549, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 38);
            this.label1.TabIndex = 11;
            this.label1.Text = "!GRACIAS POR ELEGIRNOS!\r\nVUELVA PRONTO A INFINITY GAMING\r\n";
            // 
            // frmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InfinityGaming.Properties.Resources.Gemini_Generated_Image_yx6qy3yx6qy3yx6q;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgFactura);
            this.DoubleBuffered = true;
            this.Name = "frmFacturas";
            this.Text = "frmFacturas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTarjeta;
        private System.Windows.Forms.Button btnTranferencia;
        private System.Windows.Forms.Button btnEfectivo;
        private System.Windows.Forms.DataGridView dtgFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCCIÓN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}
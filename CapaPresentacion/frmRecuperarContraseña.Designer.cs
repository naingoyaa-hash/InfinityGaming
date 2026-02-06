namespace InfinityGaming.CapaPresentacion
{
    partial class frmRecuperarContraseña
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnValidar = new System.Windows.Forms.Button();
            this.btnReenviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Image = global::InfinityGaming.Properties.Resources.Cerrar;
            this.btnCerrar.Location = new System.Drawing.Point(761, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(31, 32);
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Violet;
            this.label1.Location = new System.Drawing.Point(215, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "USUARIO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Violet;
            this.label2.Location = new System.Drawing.Point(220, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "CORREO:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Black;
            this.lblTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Violet;
            this.lblTitulo.Location = new System.Drawing.Point(303, 217);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(210, 23);
            this.lblTitulo.TabIndex = 22;
            this.lblTitulo.Text = "INGRESE USUARIO Y CORREO";
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRecuperar.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.btnRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRecuperar.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRecuperar.Location = new System.Drawing.Point(335, 355);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(129, 40);
            this.btnRecuperar.TabIndex = 24;
            this.btnRecuperar.Text = "RECUPERAR";
            this.btnRecuperar.UseVisualStyleBackColor = false;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(307, 267);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(206, 27);
            this.txtUsuario.TabIndex = 25;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(307, 310);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(206, 27);
            this.txtCorreo.TabIndex = 26;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(307, 288);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(206, 27);
            this.txtCodigo.TabIndex = 28;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.Black;
            this.lblCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.Violet;
            this.lblCodigo.Location = new System.Drawing.Point(141, 290);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(149, 23);
            this.lblCodigo.TabIndex = 27;
            this.lblCodigo.Text = "INGRESE EL CODIGO";
            // 
            // btnValidar
            // 
            this.btnValidar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnValidar.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.btnValidar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValidar.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnValidar.Location = new System.Drawing.Point(241, 355);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(129, 40);
            this.btnValidar.TabIndex = 29;
            this.btnValidar.Text = "VALIDAR";
            this.btnValidar.UseVisualStyleBackColor = false;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnReenviar
            // 
            this.btnReenviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnReenviar.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.btnReenviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReenviar.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReenviar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReenviar.Location = new System.Drawing.Point(406, 355);
            this.btnReenviar.Name = "btnReenviar";
            this.btnReenviar.Size = new System.Drawing.Size(129, 40);
            this.btnReenviar.TabIndex = 30;
            this.btnReenviar.Text = "REENVIAR";
            this.btnReenviar.UseVisualStyleBackColor = false;
            // 
            // frmRecuperarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 459);
            this.Controls.Add(this.btnReenviar);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRecuperarContraseña";
            this.Text = "frmRecuperarContraseña";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRecuperarContraseña_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmRecuperarContraseña_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Button btnReenviar;
    }
}
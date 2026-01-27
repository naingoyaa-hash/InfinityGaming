namespace InfinityGaming
{
    partial class frmMantenimiento
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
            this.btnRegistroM = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.pnlMantenimiento = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegistroM
            // 
            this.btnRegistroM.BackgroundImage = global::InfinityGaming.Properties.Resources.WhatsApp_Image_2026_01_13_at_9_12_44_PM;
            this.btnRegistroM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistroM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistroM.Location = new System.Drawing.Point(6, 47);
            this.btnRegistroM.Name = "btnRegistroM";
            this.btnRegistroM.Size = new System.Drawing.Size(185, 63);
            this.btnRegistroM.TabIndex = 0;
            this.btnRegistroM.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::InfinityGaming.Properties.Resources.fondo_1;
            this.groupBox1.Controls.Add(this.btnHistorial);
            this.groupBox1.Controls.Add(this.btnRegistroM);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Plum;
            this.groupBox1.Location = new System.Drawing.Point(30, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 204);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MENÚ DE MANTENIMIENTO ";
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackgroundImage = global::InfinityGaming.Properties.Resources.Gemini_Generated_Image_fi0p7lfi0p7lfi0p;
            this.btnHistorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHistorial.Location = new System.Drawing.Point(6, 116);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(185, 52);
            this.btnHistorial.TabIndex = 2;
            this.btnHistorial.UseVisualStyleBackColor = true;
            // 
            // pnlMantenimiento
            // 
            this.pnlMantenimiento.Location = new System.Drawing.Point(284, 133);
            this.pnlMantenimiento.Name = "pnlMantenimiento";
            this.pnlMantenimiento.Size = new System.Drawing.Size(504, 204);
            this.pnlMantenimiento.TabIndex = 2;
            // 
            // frmMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InfinityGaming.Properties.Resources.ChatGPT_Image_13_ene_2026__10_00_51_a_m_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMantenimiento);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMantenimiento";
            this.Text = "frmMantenimiento";
            this.Load += new System.EventHandler(this.frmMantenimiento_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegistroM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Panel pnlMantenimiento;
    }
}
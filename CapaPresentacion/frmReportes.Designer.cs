namespace InfinityGaming.CapaPresentacion
{
    partial class frmReportes
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
            this.menuReportes = new System.Windows.Forms.MenuStrip();
            this.rEPORTEsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNGRESOSDIARIOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pRODUCTOSMASVENDIDOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dETALLESVENTASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlReportes = new System.Windows.Forms.Panel();
            this.menuReportes.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuReportes
            // 
            this.menuReportes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rEPORTEsToolStripMenuItem});
            this.menuReportes.Location = new System.Drawing.Point(0, 0);
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(711, 24);
            this.menuReportes.TabIndex = 0;
            this.menuReportes.Text = "menuStrip1";
            // 
            // rEPORTEsToolStripMenuItem
            // 
            this.rEPORTEsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNGRESOSDIARIOSToolStripMenuItem,
            this.pRODUCTOSMASVENDIDOSToolStripMenuItem,
            this.dETALLESVENTASToolStripMenuItem});
            this.rEPORTEsToolStripMenuItem.Name = "rEPORTEsToolStripMenuItem";
            this.rEPORTEsToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.rEPORTEsToolStripMenuItem.Text = "REPORTES";
            // 
            // iNGRESOSDIARIOSToolStripMenuItem
            // 
            this.iNGRESOSDIARIOSToolStripMenuItem.Name = "iNGRESOSDIARIOSToolStripMenuItem";
            this.iNGRESOSDIARIOSToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.iNGRESOSDIARIOSToolStripMenuItem.Text = "INGRESOS DIARIOS";
            this.iNGRESOSDIARIOSToolStripMenuItem.Click += new System.EventHandler(this.iNGRESOSDIARIOSToolStripMenuItem_Click);
            // 
            // pRODUCTOSMASVENDIDOSToolStripMenuItem
            // 
            this.pRODUCTOSMASVENDIDOSToolStripMenuItem.Name = "pRODUCTOSMASVENDIDOSToolStripMenuItem";
            this.pRODUCTOSMASVENDIDOSToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.pRODUCTOSMASVENDIDOSToolStripMenuItem.Text = "PRODUCTOS MAS VENDIDOS";
            this.pRODUCTOSMASVENDIDOSToolStripMenuItem.Click += new System.EventHandler(this.pRODUCTOSMASVENDIDOSToolStripMenuItem_Click);
            // 
            // dETALLESVENTASToolStripMenuItem
            // 
            this.dETALLESVENTASToolStripMenuItem.Name = "dETALLESVENTASToolStripMenuItem";
            this.dETALLESVENTASToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.dETALLESVENTASToolStripMenuItem.Text = "DETALLES VENTAS";
            this.dETALLESVENTASToolStripMenuItem.Click += new System.EventHandler(this.dETALLESVENTASToolStripMenuItem_Click);
            // 
            // pnlReportes
            // 
            this.pnlReportes.Location = new System.Drawing.Point(0, 27);
            this.pnlReportes.Name = "pnlReportes";
            this.pnlReportes.Size = new System.Drawing.Size(711, 364);
            this.pnlReportes.TabIndex = 1;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 390);
            this.Controls.Add(this.pnlReportes);
            this.Controls.Add(this.menuReportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuReportes;
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.menuReportes.ResumeLayout(false);
            this.menuReportes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuReportes;
        private System.Windows.Forms.ToolStripMenuItem rEPORTEsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNGRESOSDIARIOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pRODUCTOSMASVENDIDOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dETALLESVENTASToolStripMenuItem;
        private System.Windows.Forms.Panel pnlReportes;
    }
}
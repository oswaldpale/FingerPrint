namespace Acceso.Presentacion.AccesoSistema
{
    partial class frmAccesoSistema
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
            this.Picture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMensajes = new System.Windows.Forms.Label();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.SystemColors.Window;
            this.Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Picture.Location = new System.Drawing.Point(21, 54);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(209, 223);
            this.Picture.TabIndex = 2;
            this.Picture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Huella de usuario:";
            // 
            // lblMensajes
            // 
            this.lblMensajes.AutoSize = true;
            this.lblMensajes.Location = new System.Drawing.Point(38, 284);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(0, 13);
            this.lblMensajes.TabIndex = 4;
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.Location = new System.Drawing.Point(28, 30);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(202, 21);
            this.lblInstrucciones.TabIndex = 5;
            // 
            // frmAccesoSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 327);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.lblMensajes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Picture);
            this.Name = "frmAccesoSistema";
            this.Text = "Acceso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccesoSistema_FormClosing);
            this.Load += new System.EventHandler(this.frmAccesoSistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMensajes;
        public System.Windows.Forms.PictureBox Picture;
        public System.Windows.Forms.Label lblInstrucciones;
    }
}
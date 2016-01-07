namespace CapturaWebcam
{
    partial class Frm_Index
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_capturar = new System.Windows.Forms.Button();
            this.pctbox_webcam = new System.Windows.Forms.PictureBox();
            this.pctbox_imagen = new System.Windows.Forms.PictureBox();
            this.txbox_ruta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_webcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_capturar
            // 
            this.btn_capturar.Location = new System.Drawing.Point(327, 340);
            this.btn_capturar.Name = "btn_capturar";
            this.btn_capturar.Size = new System.Drawing.Size(100, 35);
            this.btn_capturar.TabIndex = 1;
            this.btn_capturar.Text = "Capturar";
            this.btn_capturar.UseVisualStyleBackColor = true;
            this.btn_capturar.Click += new System.EventHandler(this.btn_capturar_Click);
            // 
            // pctbox_webcam
            // 
            this.pctbox_webcam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbox_webcam.Location = new System.Drawing.Point(12, 12);
            this.pctbox_webcam.Name = "pctbox_webcam";
            this.pctbox_webcam.Size = new System.Drawing.Size(300, 300);
            this.pctbox_webcam.TabIndex = 2;
            this.pctbox_webcam.TabStop = false;
            // 
            // pctbox_imagen
            // 
            this.pctbox_imagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbox_imagen.Location = new System.Drawing.Point(327, 12);
            this.pctbox_imagen.Name = "pctbox_imagen";
            this.pctbox_imagen.Size = new System.Drawing.Size(300, 300);
            this.pctbox_imagen.TabIndex = 3;
            this.pctbox_imagen.TabStop = false;
            // 
            // txbox_ruta
            // 
            this.txbox_ruta.Location = new System.Drawing.Point(12, 348);
            this.txbox_ruta.Name = "txbox_ruta";
            this.txbox_ruta.Size = new System.Drawing.Size(300, 20);
            this.txbox_ruta.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ruta del fichero:";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(433, 340);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(100, 35);
            this.btn_guardar.TabIndex = 6;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // Frm_Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 392);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbox_ruta);
            this.Controls.Add(this.pctbox_imagen);
            this.Controls.Add(this.pctbox_webcam);
            this.Controls.Add(this.btn_capturar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Index";
            this.Text = "Proyecto - Captura por Webcam";
            this.Load += new System.EventHandler(this.Frm_Index_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Index_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_webcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_capturar;
        private System.Windows.Forms.PictureBox pctbox_webcam;
        private System.Windows.Forms.PictureBox pctbox_imagen;
        private System.Windows.Forms.TextBox txbox_ruta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_guardar;
    }
}


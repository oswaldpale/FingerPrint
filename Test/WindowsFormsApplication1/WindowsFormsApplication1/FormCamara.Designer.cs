namespace WindowsFormsApplication1
{
    partial class FormCamara
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_webcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_imagen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_capturar
            // 
            this.btn_capturar.Location = new System.Drawing.Point(196, 290);
            this.btn_capturar.Name = "btn_capturar";
            this.btn_capturar.Size = new System.Drawing.Size(100, 35);
            this.btn_capturar.TabIndex = 1;
            this.btn_capturar.Text = "Capturar Imagen";
            this.btn_capturar.UseVisualStyleBackColor = true;
            this.btn_capturar.Click += new System.EventHandler(this.btn_capturar_Click);
            // 
            // pctbox_webcam
            // 
            this.pctbox_webcam.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pctbox_webcam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbox_webcam.Location = new System.Drawing.Point(44, 25);
            this.pctbox_webcam.Name = "pctbox_webcam";
            this.pctbox_webcam.Size = new System.Drawing.Size(252, 236);
            this.pctbox_webcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbox_webcam.TabIndex = 2;
            this.pctbox_webcam.TabStop = false;
            this.pctbox_webcam.Click += new System.EventHandler(this.pctbox_webcam_Click);
            // 
            // pctbox_imagen
            // 
            this.pctbox_imagen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pctbox_imagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbox_imagen.Location = new System.Drawing.Point(43, 25);
            this.pctbox_imagen.Name = "pctbox_imagen";
            this.pctbox_imagen.Size = new System.Drawing.Size(252, 236);
            this.pctbox_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbox_imagen.TabIndex = 3;
            this.pctbox_imagen.TabStop = false;
            this.pctbox_imagen.Click += new System.EventHandler(this.pctbox_imagen_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Guardar Foto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.pctbox_webcam);
            this.groupBox1.Controls.Add(this.btn_capturar);
            this.groupBox1.Location = new System.Drawing.Point(33, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 344);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WebCam";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.pctbox_imagen);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(401, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 344);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Foto";
            // 
            // FormCamara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 392);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCamara";
            this.Text = "Proyecto - Captura por Webcam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Index_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Index_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_webcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbox_imagen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_capturar;
        private System.Windows.Forms.PictureBox pctbox_webcam;
        private System.Windows.Forms.PictureBox pctbox_imagen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}


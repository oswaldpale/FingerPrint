namespace WindowsFormsApplication1
{
    partial class CapturarHuella
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapturarHuella));
            this.btguardar = new System.Windows.Forms.Button();
            this.btHuella1 = new System.Windows.Forms.Button();
            this.bthuella2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbImage2 = new System.Windows.Forms.PictureBox();
            this.ListEvent = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbdescripcion = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btguardar
            // 
            this.btguardar.Enabled = false;
            this.btguardar.Location = new System.Drawing.Point(143, 586);
            this.btguardar.Name = "btguardar";
            this.btguardar.Size = new System.Drawing.Size(337, 33);
            this.btguardar.TabIndex = 25;
            this.btguardar.Text = "Guardar Huellas";
            this.btguardar.UseVisualStyleBackColor = true;
            this.btguardar.Click += new System.EventHandler(this.GuardarHuellas_Click);
            // 
            // btHuella1
            // 
            this.btHuella1.Location = new System.Drawing.Point(46, 321);
            this.btHuella1.Name = "btHuella1";
            this.btHuella1.Size = new System.Drawing.Size(148, 23);
            this.btHuella1.TabIndex = 26;
            this.btHuella1.Text = "Capturar Huella Izquierda";
            this.btHuella1.UseVisualStyleBackColor = true;
            this.btHuella1.Click += new System.EventHandler(this.btHuella1_Click);
            // 
            // bthuella2
            // 
            this.bthuella2.Location = new System.Drawing.Point(54, 321);
            this.bthuella2.Name = "bthuella2";
            this.bthuella2.Size = new System.Drawing.Size(147, 23);
            this.bthuella2.TabIndex = 27;
            this.bthuella2.Text = "Capturar Huella Derecha";
            this.bthuella2.UseVisualStyleBackColor = true;
            this.bthuella2.Click += new System.EventHandler(this.bthuella2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btHuella1);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.pbImage);
            this.groupBox3.Location = new System.Drawing.Point(40, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 362);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Indice izquierdo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 139);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImage.Location = new System.Drawing.Point(56, 19);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(135, 151);
            this.pbImage.TabIndex = 20;
            this.pbImage.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bthuella2);
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Controls.Add(this.pbImage2);
            this.groupBox4.Location = new System.Drawing.Point(304, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 362);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Indice Derecho";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(54, 176);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(147, 139);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // pbImage2
            // 
            this.pbImage2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbImage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImage2.Location = new System.Drawing.Point(67, 19);
            this.pbImage2.Name = "pbImage2";
            this.pbImage2.Size = new System.Drawing.Size(134, 151);
            this.pbImage2.TabIndex = 22;
            this.pbImage2.TabStop = false;
            this.pbImage2.Click += new System.EventHandler(this.pbImage2_Click);
            // 
            // ListEvent
            // 
            this.ListEvent.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ListEvent.FormattingEnabled = true;
            this.ListEvent.Location = new System.Drawing.Point(17, 19);
            this.ListEvent.Name = "ListEvent";
            this.ListEvent.Size = new System.Drawing.Size(493, 69);
            this.ListEvent.TabIndex = 32;
            this.ListEvent.SelectedIndexChanged += new System.EventHandler(this.ListEvent_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListEvent);
            this.groupBox1.Location = new System.Drawing.Point(40, 472);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 99);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eventos";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(613, 102);
            this.label1.TabIndex = 34;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(444, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(125, 86);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 29);
            this.label2.TabIndex = 36;
            this.label2.Text = "Activar Huella Dactilar";
            // 
            // lbdescripcion
            // 
            this.lbdescripcion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbdescripcion.Location = new System.Drawing.Point(12, 65);
            this.lbdescripcion.Name = "lbdescripcion";
            this.lbdescripcion.Size = new System.Drawing.Size(426, 23);
            this.lbdescripcion.TabIndex = 37;
            this.lbdescripcion.Text = "Para Activar su huella digital, oprima  sobre cada boton que se encuentra abajo d" +
    "e la mano. ";
            // 
            // CapturarHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 640);
            this.Controls.Add(this.lbdescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btguardar);
            this.Name = "CapturarHuella";
            this.Text = "Capturar Huella";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CapturarHuella_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CapturarHuella_FormClosed);
            this.Load += new System.EventHandler(this.CapturarHuella_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.PictureBox pbImage2;
        private System.Windows.Forms.Button btguardar;
        private System.Windows.Forms.Button btHuella1;
        private System.Windows.Forms.Button bthuella2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListBox ListEvent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbdescripcion;
    }
}
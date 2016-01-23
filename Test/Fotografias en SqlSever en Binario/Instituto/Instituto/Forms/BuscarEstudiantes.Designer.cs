namespace Instituto
{
    partial class BuscarEstudiantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarEstudiantes));
            this.btnVerDatos = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btneditafoto = new System.Windows.Forms.Button();
            this.txtexaminar = new System.Windows.Forms.TextBox();
            this.btnexaminar3 = new System.Windows.Forms.Button();
            this.picfoto3 = new System.Windows.Forms.PictureBox();
            this.txtnombres = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.txtbusqueda1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbodistrito = new System.Windows.Forms.ComboBox();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.txtapellidos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnnuevoeditar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picfoto3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVerDatos
            // 
            this.btnVerDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(129)))), ((int)(((byte)(50)))));
            this.btnVerDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerDatos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnVerDatos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVerDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDatos.Location = new System.Drawing.Point(166, 221);
            this.btnVerDatos.Name = "btnVerDatos";
            this.btnVerDatos.Size = new System.Drawing.Size(134, 40);
            this.btnVerDatos.TabIndex = 34;
            this.btnVerDatos.Text = "EDITAR DATOS";
            this.btnVerDatos.UseVisualStyleBackColor = false;
            this.btnVerDatos.Click += new System.EventHandler(this.btnVerDatos_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btneditafoto);
            this.groupBox2.Controls.Add(this.txtexaminar);
            this.groupBox2.Controls.Add(this.btnexaminar3);
            this.groupBox2.Controls.Add(this.picfoto3);
            this.groupBox2.Location = new System.Drawing.Point(516, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 321);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FOTOGRAFIA";
            // 
            // btneditafoto
            // 
            this.btneditafoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(129)))), ((int)(((byte)(50)))));
            this.btneditafoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btneditafoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btneditafoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btneditafoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneditafoto.Location = new System.Drawing.Point(35, 261);
            this.btneditafoto.Name = "btneditafoto";
            this.btneditafoto.Size = new System.Drawing.Size(134, 40);
            this.btneditafoto.TabIndex = 39;
            this.btneditafoto.Text = "EDITAR FOTOGRAFIA";
            this.btneditafoto.UseVisualStyleBackColor = false;
            this.btneditafoto.Click += new System.EventHandler(this.btneditafoto_Click);
            // 
            // txtexaminar
            // 
            this.txtexaminar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtexaminar.Enabled = false;
            this.txtexaminar.Location = new System.Drawing.Point(102, 235);
            this.txtexaminar.Name = "txtexaminar";
            this.txtexaminar.Size = new System.Drawing.Size(10, 20);
            this.txtexaminar.TabIndex = 21;
            this.txtexaminar.Visible = false;
            // 
            // btnexaminar3
            // 
            this.btnexaminar3.Location = new System.Drawing.Point(35, 19);
            this.btnexaminar3.Name = "btnexaminar3";
            this.btnexaminar3.Size = new System.Drawing.Size(134, 23);
            this.btnexaminar3.TabIndex = 20;
            this.btnexaminar3.Text = "EXAMINAR";
            this.btnexaminar3.UseVisualStyleBackColor = true;
            this.btnexaminar3.Click += new System.EventHandler(this.btnexaminar3_Click);
            // 
            // picfoto3
            // 
            this.picfoto3.BackgroundImage = global::Instituto.Properties.Resources.contact;
            this.picfoto3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picfoto3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picfoto3.Location = new System.Drawing.Point(15, 48);
            this.picfoto3.Name = "picfoto3";
            this.picfoto3.Size = new System.Drawing.Size(174, 201);
            this.picfoto3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picfoto3.TabIndex = 1;
            this.picfoto3.TabStop = false;
            // 
            // txtnombres
            // 
            this.txtnombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnombres.Location = new System.Drawing.Point(133, 46);
            this.txtnombres.Name = "txtnombres";
            this.txtnombres.Size = new System.Drawing.Size(237, 20);
            this.txtnombres.TabIndex = 2;
            this.txtnombres.Enter += new System.EventHandler(this.txtnombres_Enter);
            this.txtnombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombres_KeyPress);
            this.txtnombres.Leave += new System.EventHandler(this.txtnombres_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbobusqueda);
            this.groupBox1.Controls.Add(this.txtbusqueda1);
            this.groupBox1.Location = new System.Drawing.Point(27, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 56);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BUSQUEDA DE ESTUDIANTE";
            // 
            // cbobusqueda
            // 
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Items.AddRange(new object[] {
            "Dni",
            "Apellidos"});
            this.cbobusqueda.Location = new System.Drawing.Point(53, 22);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(174, 20);
            this.cbobusqueda.TabIndex = 2;
            // 
            // txtbusqueda1
            // 
            this.txtbusqueda1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbusqueda1.Location = new System.Drawing.Point(265, 21);
            this.txtbusqueda1.MaxLength = 3;
            this.txtbusqueda1.Name = "txtbusqueda1";
            this.txtbusqueda1.Size = new System.Drawing.Size(150, 20);
            this.txtbusqueda1.TabIndex = 1;
            this.txtbusqueda1.Enter += new System.EventHandler(this.txtbusqueda1_Enter);
            this.txtbusqueda1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbusqueda1_KeyDown);
            this.txtbusqueda1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbusqueda1_KeyPress);
            this.txtbusqueda1.Leave += new System.EventHandler(this.txtbusqueda1_Leave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(192)))), ((int)(((byte)(153)))));
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(753, 68);
            this.label2.TabIndex = 30;
            this.label2.Text = "Actualizacion de Estudiante";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbodistrito);
            this.groupBox3.Controls.Add(this.txtdireccion);
            this.groupBox3.Controls.Add(this.btnVerDatos);
            this.groupBox3.Controls.Add(this.txtapellidos);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtnombres);
            this.groupBox3.Location = new System.Drawing.Point(27, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(457, 307);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            // 
            // cbodistrito
            // 
            this.cbodistrito.FormattingEnabled = true;
            this.cbodistrito.Items.AddRange(new object[] {
            "CERCADO",
            "ANCON",
            "ATE",
            "BARRANCO",
            "BREÑA",
            "CALLAO",
            "CARABAYLLO",
            "COMAS",
            "CHACLACAYO",
            "CHORRILLOS",
            "EL AGUSTINO",
            "JESUS MARIA",
            "LA MOLINA",
            "LA VICTORIA",
            "LINCE",
            "LURIGANCHO",
            "LURIN",
            "MAGDALENA",
            "MIRAFLORES",
            "PACHACAMAC",
            "PUCUSANA",
            "PUEBLO LIBRE",
            "PUENTE PIEDRA",
            "PUNTA NEGRA",
            "PUNTA HERMOSA",
            "RIMAC",
            "SAN BARTOLO",
            "SAN ISIDRO",
            "INDEPENDENCIA",
            "SAN JUAN DE MIRAFLORES",
            "SAN LUIS",
            "SAN MARTIN DE PORRES",
            "SAN MIGUEL",
            "SANTIAGO DE SURCO",
            "SURQUILLO",
            "VILLA MARIA DEL TRIUNFO",
            "SAN JUAN DE LURIGANCHO",
            "SANTA MARIA DEL MAR",
            "SANTA ROSA",
            "LOS OLIVOS",
            "CIENEGUILLA",
            "SAN BORJA",
            "VILLA EL SALVADOR",
            "SANTA ANITA",
            ""});
            this.cbodistrito.Location = new System.Drawing.Point(133, 160);
            this.cbodistrito.Name = "cbodistrito";
            this.cbodistrito.Size = new System.Drawing.Size(237, 20);
            this.cbodistrito.TabIndex = 11;
            this.cbodistrito.Text = "SELECCIONE DISTRITO";
            // 
            // txtdireccion
            // 
            this.txtdireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdireccion.Location = new System.Drawing.Point(133, 122);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(237, 20);
            this.txtdireccion.TabIndex = 10;
            this.txtdireccion.Enter += new System.EventHandler(this.txtdireccion_Enter);
            this.txtdireccion.Leave += new System.EventHandler(this.txtdireccion_Leave);
            // 
            // txtapellidos
            // 
            this.txtapellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtapellidos.Location = new System.Drawing.Point(133, 84);
            this.txtapellidos.Name = "txtapellidos";
            this.txtapellidos.Size = new System.Drawing.Size(237, 20);
            this.txtapellidos.TabIndex = 8;
            this.txtapellidos.Enter += new System.EventHandler(this.txtapellidos_Enter);
            this.txtapellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtapellidos_KeyPress);
            this.txtapellidos.Leave += new System.EventHandler(this.txtapellidos_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "Distrito";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Direccion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellidos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombres";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(192)))), ((int)(((byte)(153)))));
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(647, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = ".";
            // 
            // btnnuevoeditar
            // 
            this.btnnuevoeditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(129)))), ((int)(((byte)(50)))));
            this.btnnuevoeditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnnuevoeditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnnuevoeditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnnuevoeditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnuevoeditar.Location = new System.Drawing.Point(551, 425);
            this.btnnuevoeditar.Name = "btnnuevoeditar";
            this.btnnuevoeditar.Size = new System.Drawing.Size(134, 40);
            this.btnnuevoeditar.TabIndex = 35;
            this.btnnuevoeditar.Text = "NUEVO";
            this.btnnuevoeditar.UseVisualStyleBackColor = false;
            this.btnnuevoeditar.Click += new System.EventHandler(this.btnnuevoeditar_Click);
            // 
            // BuscarEstudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 485);
            this.Controls.Add(this.btnnuevoeditar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarEstudiantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instituto Tecnologico Superior Binario";
            this.Load += new System.EventHandler(this.BuscarEstudiantes_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picfoto3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerDatos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picfoto3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbusqueda1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnombres;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbodistrito;
        private System.Windows.Forms.TextBox txtdireccion;
        private System.Windows.Forms.TextBox txtapellidos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnexaminar3;
        public System.Windows.Forms.TextBox txtexaminar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btneditafoto;
        private System.Windows.Forms.Button btnnuevoeditar;
        private System.Windows.Forms.ComboBox cbobusqueda;
    }
}
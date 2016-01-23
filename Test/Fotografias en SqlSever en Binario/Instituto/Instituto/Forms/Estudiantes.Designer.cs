namespace Instituto
{
    partial class Estudiantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estudiantes));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picfotografia = new System.Windows.Forms.PictureBox();
            this.btnexaminar = new System.Windows.Forms.Button();
            this.txtexaminar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fecha1 = new System.Windows.Forms.DateTimePicker();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.numedad = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.cbodistrito = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnvisualizar = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picfotografia)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numedad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picfotografia);
            this.groupBox2.Controls.Add(this.btnexaminar);
            this.groupBox2.Controls.Add(this.txtexaminar);
            this.groupBox2.Location = new System.Drawing.Point(415, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 292);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "INGRESE FOTOGRAFIA";
            // 
            // picfotografia
            // 
            this.picfotografia.BackgroundImage = global::Instituto.Properties.Resources.contact;
            this.picfotografia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picfotografia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picfotografia.Location = new System.Drawing.Point(52, 64);
            this.picfotografia.Name = "picfotografia";
            this.picfotografia.Size = new System.Drawing.Size(174, 201);
            this.picfotografia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picfotografia.TabIndex = 20;
            this.picfotografia.TabStop = false;
            // 
            // btnexaminar
            // 
            this.btnexaminar.Location = new System.Drawing.Point(71, 35);
            this.btnexaminar.Name = "btnexaminar";
            this.btnexaminar.Size = new System.Drawing.Size(134, 23);
            this.btnexaminar.TabIndex = 19;
            this.btnexaminar.Text = "EXAMINAR";
            this.btnexaminar.UseVisualStyleBackColor = true;
            this.btnexaminar.Click += new System.EventHandler(this.btnexaminar_Click_1);
            // 
            // txtexaminar
            // 
            this.txtexaminar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtexaminar.Enabled = false;
            this.txtexaminar.Location = new System.Drawing.Point(134, 266);
            this.txtexaminar.Name = "txtexaminar";
            this.txtexaminar.Size = new System.Drawing.Size(10, 20);
            this.txtexaminar.TabIndex = 17;
            this.txtexaminar.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.fecha1);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.Controls.Add(this.numedad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtdireccion);
            this.groupBox1.Controls.Add(this.txtapellido);
            this.groupBox1.Controls.Add(this.cbodistrito);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtdni);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(36, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 292);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INGRESE DATOS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 14);
            this.label9.TabIndex = 18;
            this.label9.Text = "Fecha";
            // 
            // fecha1
            // 
            this.fecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha1.Location = new System.Drawing.Point(107, 244);
            this.fecha1.Name = "fecha1";
            this.fecha1.Size = new System.Drawing.Size(134, 20);
            this.fecha1.TabIndex = 17;
            this.fecha1.ValueChanged += new System.EventHandler(this.fecha1_ValueChanged);
            // 
            // txtnombre
            // 
            this.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnombre.Location = new System.Drawing.Point(107, 40);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(204, 20);
            this.txtnombre.TabIndex = 1;
            this.txtnombre.Enter += new System.EventHandler(this.txtnombre_Enter);
            this.txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombre_KeyPress);
            this.txtnombre.Leave += new System.EventHandler(this.txtnombre_Leave);
            // 
            // numedad
            // 
            this.numedad.Location = new System.Drawing.Point(107, 142);
            this.numedad.Name = "numedad";
            this.numedad.Size = new System.Drawing.Size(47, 20);
            this.numedad.TabIndex = 4;
            this.numedad.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.numedad.Enter += new System.EventHandler(this.numedad_Enter);
            this.numedad.Leave += new System.EventHandler(this.numedad_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombres";
            // 
            // txtdireccion
            // 
            this.txtdireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdireccion.Location = new System.Drawing.Point(107, 176);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(204, 20);
            this.txtdireccion.TabIndex = 5;
            this.txtdireccion.Enter += new System.EventHandler(this.txtdireccion_Enter);
            this.txtdireccion.Leave += new System.EventHandler(this.txtdireccion_Leave);
            // 
            // txtapellido
            // 
            this.txtapellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtapellido.Location = new System.Drawing.Point(107, 74);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(204, 20);
            this.txtapellido.TabIndex = 2;
            this.txtapellido.Enter += new System.EventHandler(this.txtapellido_Enter);
            this.txtapellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtapellido_KeyPress);
            this.txtapellido.Leave += new System.EventHandler(this.txtapellido_Leave);
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
            "",
            ""});
            this.cbodistrito.Location = new System.Drawing.Point(107, 210);
            this.cbodistrito.Name = "cbodistrito";
            this.cbodistrito.Size = new System.Drawing.Size(204, 22);
            this.cbodistrito.TabIndex = 6;
            this.cbodistrito.Text = "SELECCIONE DISTRITO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Apellidos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Distrito";
            // 
            // txtdni
            // 
            this.txtdni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdni.Location = new System.Drawing.Point(107, 108);
            this.txtdni.MaxLength = 8;
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(134, 20);
            this.txtdni.TabIndex = 3;
            this.txtdni.Enter += new System.EventHandler(this.txtdni_Enter);
            this.txtdni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdni_KeyPress);
            this.txtdni.Leave += new System.EventHandler(this.txtdni_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Direccion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dni";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Edad";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(192)))), ((int)(((byte)(153)))));
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(728, 68);
            this.label2.TabIndex = 23;
            this.label2.Text = "Registro de Estudiantes";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(129)))), ((int)(((byte)(50)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(476, 389);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 40);
            this.button3.TabIndex = 30;
            this.button3.Text = "SALIR";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnvisualizar
            // 
            this.btnvisualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(129)))), ((int)(((byte)(50)))));
            this.btnvisualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnvisualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnvisualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnvisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvisualizar.Location = new System.Drawing.Point(112, 389);
            this.btnvisualizar.Name = "btnvisualizar";
            this.btnvisualizar.Size = new System.Drawing.Size(134, 40);
            this.btnvisualizar.TabIndex = 29;
            this.btnvisualizar.Text = "VISUALIZAR";
            this.btnvisualizar.UseVisualStyleBackColor = false;
            this.btnvisualizar.Click += new System.EventHandler(this.btnvisualizar_Click);
            // 
            // btnnuevo
            // 
            this.btnnuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(129)))), ((int)(((byte)(50)))));
            this.btnnuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnnuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnnuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnuevo.Location = new System.Drawing.Point(294, 389);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(134, 40);
            this.btnnuevo.TabIndex = 33;
            this.btnnuevo.Text = "NUEVO";
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // Estudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 450);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnvisualizar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Estudiantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instituto Tecnologico Superior Binario";
            this.Load += new System.EventHandler(this.Estudiantes_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picfotografia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numedad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.DateTimePicker fecha1;
        public System.Windows.Forms.TextBox txtnombre;
        public System.Windows.Forms.NumericUpDown numedad;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtdireccion;
        public System.Windows.Forms.TextBox txtapellido;
        public System.Windows.Forms.ComboBox cbodistrito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox picfotografia;
        public System.Windows.Forms.TextBox txtexaminar;
        public System.Windows.Forms.Button btnnuevo;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button btnvisualizar;
        public System.Windows.Forms.Button btnexaminar;
    }
}


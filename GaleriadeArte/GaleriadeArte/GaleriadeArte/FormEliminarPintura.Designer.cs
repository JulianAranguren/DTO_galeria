namespace GaleriadeArte
{
    partial class FormEliminarPintura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEliminarPintura));
            this.txtTextura = new System.Windows.Forms.TextBox();
            this.labelTextura = new System.Windows.Forms.Label();
            this.textTecnica = new System.Windows.Forms.TextBox();
            this.labelTecnica = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelFechaIngreso = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.txtIdPintura = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTextura
            // 
            this.txtTextura.Location = new System.Drawing.Point(121, 430);
            this.txtTextura.Name = "txtTextura";
            this.txtTextura.Size = new System.Drawing.Size(173, 27);
            this.txtTextura.TabIndex = 47;
            this.txtTextura.TextChanged += new System.EventHandler(this.txtTextura_TextChanged);
            // 
            // labelTextura
            // 
            this.labelTextura.AutoSize = true;
            this.labelTextura.Location = new System.Drawing.Point(40, 437);
            this.labelTextura.Name = "labelTextura";
            this.labelTextura.Size = new System.Drawing.Size(81, 20);
            this.labelTextura.TabIndex = 46;
            this.labelTextura.Text = "Textura";
            this.labelTextura.Click += new System.EventHandler(this.labelTextura_Click);
            // 
            // textTecnica
            // 
            this.textTecnica.Location = new System.Drawing.Point(121, 384);
            this.textTecnica.Name = "textTecnica";
            this.textTecnica.Size = new System.Drawing.Size(173, 27);
            this.textTecnica.TabIndex = 45;
            this.textTecnica.TextChanged += new System.EventHandler(this.textTecnica_TextChanged);
            // 
            // labelTecnica
            // 
            this.labelTecnica.AutoSize = true;
            this.labelTecnica.Location = new System.Drawing.Point(40, 391);
            this.labelTecnica.Name = "labelTecnica";
            this.labelTecnica.Size = new System.Drawing.Size(82, 20);
            this.labelTecnica.TabIndex = 44;
            this.labelTecnica.Text = "Tecnica";
            this.labelTecnica.Click += new System.EventHandler(this.labelTecnica_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(185, 331);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(257, 27);
            this.dateTimePicker1.TabIndex = 43;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // labelFechaIngreso
            // 
            this.labelFechaIngreso.AutoSize = true;
            this.labelFechaIngreso.Location = new System.Drawing.Point(40, 331);
            this.labelFechaIngreso.Name = "labelFechaIngreso";
            this.labelFechaIngreso.Size = new System.Drawing.Size(139, 20);
            this.labelFechaIngreso.TabIndex = 42;
            this.labelFechaIngreso.Text = "Fecha Ingerso";
            this.labelFechaIngreso.Click += new System.EventHandler(this.labelFechaIngreso_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(121, 271);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 28);
            this.comboBox1.TabIndex = 41;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(40, 279);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(72, 20);
            this.labelEstado.TabIndex = 40;
            this.labelEstado.Text = "Estado";
            this.labelEstado.Click += new System.EventHandler(this.labelEstado_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(121, 219);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(173, 27);
            this.txtPrecio.TabIndex = 39;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Location = new System.Drawing.Point(40, 222);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(68, 20);
            this.labelPrecio.TabIndex = 38;
            this.labelPrecio.Text = "Precio";
            this.labelPrecio.Click += new System.EventHandler(this.labelPrecio_Click);
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(121, 159);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(173, 27);
            this.txtAutor.TabIndex = 37;
            this.txtAutor.TextChanged += new System.EventHandler(this.txtAutor_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Autor";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(121, 98);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(173, 27);
            this.txtTitulo.TabIndex = 35;
            this.txtTitulo.TextChanged += new System.EventHandler(this.txtTitulo_TextChanged);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(39, 101);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(62, 20);
            this.labelTitulo.TabIndex = 34;
            this.labelTitulo.Text = "Titulo";
            this.labelTitulo.Click += new System.EventHandler(this.labelTitulo_Click);
            // 
            // txtIdPintura
            // 
            this.txtIdPintura.Location = new System.Drawing.Point(89, 39);
            this.txtIdPintura.Name = "txtIdPintura";
            this.txtIdPintura.Size = new System.Drawing.Size(100, 27);
            this.txtIdPintura.TabIndex = 33;
            this.txtIdPintura.TextChanged += new System.EventHandler(this.txtIdPintura_TextChanged);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(39, 42);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(26, 20);
            this.labelId.TabIndex = 32;
            this.labelId.Text = "Id";
            this.labelId.Click += new System.EventHandler(this.labelId_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEliminar.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(820, 331);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(131, 37);
            this.btnEliminar.TabIndex = 48;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBuscar.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnBuscar.Location = new System.Drawing.Point(820, 279);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 37);
            this.btnBuscar.TabIndex = 49;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FormEliminarPintura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImage = global::GaleriadeArte.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1200, 562);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtTextura);
            this.Controls.Add(this.labelTextura);
            this.Controls.Add(this.textTecnica);
            this.Controls.Add(this.labelTecnica);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelFechaIngreso);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.txtIdPintura);
            this.Controls.Add(this.labelId);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEliminarPintura";
            this.Text = "FormEliminarPintura";
            this.Load += new System.EventHandler(this.FormEliminarPintura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTextura;
        private System.Windows.Forms.Label labelTextura;
        private System.Windows.Forms.TextBox textTecnica;
        private System.Windows.Forms.Label labelTecnica;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelFechaIngreso;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox txtIdPintura;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
    }
}
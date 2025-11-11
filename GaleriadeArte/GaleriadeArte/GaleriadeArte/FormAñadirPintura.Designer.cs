namespace GaleriadeArte
{
    partial class FormAñadirPintura
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAñadirPintura));
            this.labelId = new System.Windows.Forms.Label();
            this.txtIdPintura = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelFechaIngreso = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelTecnica = new System.Windows.Forms.Label();
            this.textTecnica = new System.Windows.Forms.TextBox();
            this.labelTextura = new System.Windows.Forms.Label();
            this.txtTextura = new System.Windows.Forms.TextBox();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(31, 37);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(26, 20);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id";
            this.labelId.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtIdPintura
            // 
            this.txtIdPintura.Location = new System.Drawing.Point(81, 34);
            this.txtIdPintura.Name = "txtIdPintura";
            this.txtIdPintura.Size = new System.Drawing.Size(100, 27);
            this.txtIdPintura.TabIndex = 1;
            this.txtIdPintura.TextChanged += new System.EventHandler(this.txtIdPintura_TextChanged);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(31, 96);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(62, 20);
            this.labelTitulo.TabIndex = 2;
            this.labelTitulo.Text = "Titulo";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(113, 93);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(173, 27);
            this.txtTitulo.TabIndex = 3;
            this.txtTitulo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Autor";
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(113, 154);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(173, 27);
            this.txtAutor.TabIndex = 5;
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Location = new System.Drawing.Point(32, 217);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(68, 20);
            this.labelPrecio.TabIndex = 6;
            this.labelPrecio.Text = "Precio";
            this.labelPrecio.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(113, 214);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(173, 27);
            this.txtPrecio.TabIndex = 7;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(32, 274);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(72, 20);
            this.labelEstado.TabIndex = 8;
            this.labelEstado.Text = "Estado";
            this.labelEstado.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 266);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 28);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelFechaIngreso
            // 
            this.labelFechaIngreso.AutoSize = true;
            this.labelFechaIngreso.Location = new System.Drawing.Point(32, 326);
            this.labelFechaIngreso.Name = "labelFechaIngreso";
            this.labelFechaIngreso.Size = new System.Drawing.Size(139, 20);
            this.labelFechaIngreso.TabIndex = 10;
            this.labelFechaIngreso.Text = "Fecha Ingerso";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(177, 326);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(257, 27);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // labelTecnica
            // 
            this.labelTecnica.AutoSize = true;
            this.labelTecnica.Location = new System.Drawing.Point(32, 386);
            this.labelTecnica.Name = "labelTecnica";
            this.labelTecnica.Size = new System.Drawing.Size(82, 20);
            this.labelTecnica.TabIndex = 12;
            this.labelTecnica.Text = "Tecnica";
            // 
            // textTecnica
            // 
            this.textTecnica.Location = new System.Drawing.Point(113, 379);
            this.textTecnica.Name = "textTecnica";
            this.textTecnica.Size = new System.Drawing.Size(173, 27);
            this.textTecnica.TabIndex = 13;
            // 
            // labelTextura
            // 
            this.labelTextura.AutoSize = true;
            this.labelTextura.Location = new System.Drawing.Point(32, 432);
            this.labelTextura.Name = "labelTextura";
            this.labelTextura.Size = new System.Drawing.Size(81, 20);
            this.labelTextura.TabIndex = 14;
            this.labelTextura.Text = "Textura";
            // 
            // txtTextura
            // 
            this.txtTextura.Location = new System.Drawing.Point(113, 425);
            this.txtTextura.Name = "txtTextura";
            this.txtTextura.Size = new System.Drawing.Size(173, 27);
            this.txtTextura.TabIndex = 15;
            // 
            // btnAñadir
            // 
            this.btnAñadir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAñadir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAñadir.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadir.Location = new System.Drawing.Point(904, 309);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(131, 37);
            this.btnAñadir.TabIndex = 16;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // FormAñadirPintura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImage = global::GaleriadeArte.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1200, 562);
            this.Controls.Add(this.btnAñadir);
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
            this.Name = "FormAñadirPintura";
            this.Text = "FormAñadirPintura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox txtIdPintura;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelFechaIngreso;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelTecnica;
        private System.Windows.Forms.TextBox textTecnica;
        private System.Windows.Forms.Label labelTextura;
        private System.Windows.Forms.TextBox txtTextura;
        private System.Windows.Forms.Button btnAñadir;
    }
}
namespace GaleriadeArte
{
    partial class FormBuscarAutor
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

        private void InitializeComponent()
        {
            this.dateFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.labelFechaNacimiento = new System.Windows.Forms.Label();
            this.comboActivo = new System.Windows.Forms.ComboBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.txtAñosExp = new System.Windows.Forms.TextBox();
            this.labelAñosExp = new System.Windows.Forms.Label();
            this.txtNacionalidad = new System.Windows.Forms.TextBox();
            this.labelNacionalidad = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.txtIdAutor = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtEstilo = new System.Windows.Forms.TextBox();
            this.labelEstilo = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateFechaNacimiento
            // 
            this.dateFechaNacimiento.Location = new System.Drawing.Point(171, 321);
            this.dateFechaNacimiento.Name = "dateFechaNacimiento";
            this.dateFechaNacimiento.Size = new System.Drawing.Size(257, 20);
            this.dateFechaNacimiento.TabIndex = 43;
            // 
            // labelFechaNacimiento
            // 
            this.labelFechaNacimiento.AutoSize = true;
            this.labelFechaNacimiento.Location = new System.Drawing.Point(26, 321);
            this.labelFechaNacimiento.Name = "labelFechaNacimiento";
            this.labelFechaNacimiento.Size = new System.Drawing.Size(106, 13);
            this.labelFechaNacimiento.TabIndex = 42;
            this.labelFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // comboActivo
            // 
            this.comboActivo.FormattingEnabled = true;
            this.comboActivo.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.comboActivo.Location = new System.Drawing.Point(107, 261);
            this.comboActivo.Name = "comboActivo";
            this.comboActivo.Size = new System.Drawing.Size(173, 21);
            this.comboActivo.TabIndex = 41;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(26, 269);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(43, 13);
            this.labelEstado.TabIndex = 40;
            this.labelEstado.Text = "Estado";
            // 
            // txtAñosExp
            // 
            this.txtAñosExp.Location = new System.Drawing.Point(107, 209);
            this.txtAñosExp.Name = "txtAñosExp";
            this.txtAñosExp.Size = new System.Drawing.Size(173, 20);
            this.txtAñosExp.TabIndex = 39;
            // 
            // labelAñosExp
            // 
            this.labelAñosExp.AutoSize = true;
            this.labelAñosExp.Location = new System.Drawing.Point(26, 212);
            this.labelAñosExp.Name = "labelAñosExp";
            this.labelAñosExp.Size = new System.Drawing.Size(56, 13);
            this.labelAñosExp.TabIndex = 38;
            this.labelAñosExp.Text = "Años Exp";
            // 
            // txtNacionalidad
            // 
            this.txtNacionalidad.Location = new System.Drawing.Point(107, 149);
            this.txtNacionalidad.Name = "txtNacionalidad";
            this.txtNacionalidad.Size = new System.Drawing.Size(173, 20);
            this.txtNacionalidad.TabIndex = 37;
            // 
            // labelNacionalidad
            // 
            this.labelNacionalidad.AutoSize = true;
            this.labelNacionalidad.Location = new System.Drawing.Point(25, 152);
            this.labelNacionalidad.Name = "labelNacionalidad";
            this.labelNacionalidad.Size = new System.Drawing.Size(69, 13);
            this.labelNacionalidad.TabIndex = 36;
            this.labelNacionalidad.Text = "Nacionalidad";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(107, 88);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(173, 20);
            this.txtNombre.TabIndex = 35;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(25, 91);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(47, 13);
            this.labelNombre.TabIndex = 34;
            this.labelNombre.Text = "Nombre";
            // 
            // txtIdAutor
            // 
            this.txtIdAutor.Location = new System.Drawing.Point(75, 29);
            this.txtIdAutor.Name = "txtIdAutor";
            this.txtIdAutor.Size = new System.Drawing.Size(100, 20);
            this.txtIdAutor.TabIndex = 33;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(25, 32);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 32;
            this.labelId.Text = "Id";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(400, 300);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 37);
            this.btnBuscar.TabIndex = 48;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtEstilo
            // 
            this.txtEstilo.Location = new System.Drawing.Point(107, 364);
            this.txtEstilo.Name = "txtEstilo";
            this.txtEstilo.Size = new System.Drawing.Size(173, 20);
            this.txtEstilo.TabIndex = 50;
            // 
            // labelEstilo
            // 
            this.labelEstilo.AutoSize = true;
            this.labelEstilo.Location = new System.Drawing.Point(26, 371);
            this.labelEstilo.Name = "labelEstilo";
            this.labelEstilo.Size = new System.Drawing.Size(34, 13);
            this.labelEstilo.TabIndex = 49;
            this.labelEstilo.Text = "Estilo";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(400, 350);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(131, 37);
            this.btnActualizar.TabIndex = 60;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // FormBuscarAutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtEstilo);
            this.Controls.Add(this.labelEstilo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dateFechaNacimiento);
            this.Controls.Add(this.labelFechaNacimiento);
            this.Controls.Add(this.comboActivo);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.txtAñosExp);
            this.Controls.Add(this.labelAñosExp);
            this.Controls.Add(this.txtNacionalidad);
            this.Controls.Add(this.labelNacionalidad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.txtIdAutor);
            this.Controls.Add(this.labelId);
            this.Name = "FormBuscarAutor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Autor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DateTimePicker dateFechaNacimiento;
        private System.Windows.Forms.Label labelFechaNacimiento;
        private System.Windows.Forms.ComboBox comboActivo;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.TextBox txtAñosExp;
        private System.Windows.Forms.Label labelAñosExp;
        private System.Windows.Forms.TextBox txtNacionalidad;
        private System.Windows.Forms.Label labelNacionalidad;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox txtIdAutor;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtEstilo;
        private System.Windows.Forms.Label labelEstilo;
        private System.Windows.Forms.Button btnActualizar;
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaleriadeArte
{
    partial class FormAñadirAutor
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private TextBox txtNombre;
        private TextBox txtNacionalidad;
        private DateTimePicker dateFechaNacimiento;
        private TextBox txtAñosExp;
        private TextBox txtEstilo;
        private ComboBox comboActivo;
        private Button btnAñadir;
        private Label lblId;
        private Label lblNombre;
        private Label lblAutor;
        private Label lblPrecio;
        private Label lblEstado;
        private Label lblFechaIngreso;
        private Label lblTipo;
        private Label lblVolumen;
        private Label lblMaterial;
        private Label lblAltura;

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Text = "Añadir Autor";
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Título del formulario
            lblTitulo = new Label();
            lblTitulo.Text = "# Añadir Autor";
            lblTitulo.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(300, 25);
            this.Controls.Add(lblTitulo);

            // Línea separadora
            var separator = new Label();
            separator.BorderStyle = BorderStyle.Fixed3D;
            separator.Location = new Point(20, 50);
            separator.Size = new Size(460, 2);
            this.Controls.Add(separator);

            // Campos del formulario con diseño similar
            int yPosition = 70;
            int labelWidth = 100;
            int fieldWidth = 200;
            int spacing = 35;

            // Id
            lblId = new Label();
            lblId.Text = "## Id";
            lblId.Font = new Font("Arial", 10, FontStyle.Bold);
            lblId.Location = new Point(20, yPosition);
            lblId.Size = new Size(200, 20);
            this.Controls.Add(lblId);
            yPosition += 25;

            // Título
            lblNombre = new Label();
            lblNombre.Text = "- **Nombre**";
            lblNombre.Font = new Font("Arial", 9, FontStyle.Bold);
            lblNombre.Location = new Point(20, yPosition);
            lblNombre.Size = new Size(200, 20);
            this.Controls.Add(lblNombre);

            txtNombre = new TextBox();
            txtNombre.Location = new Point(250, yPosition);
            txtNombre.Size = new Size(200, 25);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtNombre);
            yPosition += spacing;

            // Autor (Nacionalidad)
            lblAutor = new Label();
            lblAutor.Text = "  - Nacionalidad";
            lblAutor.Font = new Font("Arial", 9);
            lblAutor.Location = new Point(20, yPosition);
            lblAutor.Size = new Size(200, 20);
            this.Controls.Add(lblAutor);

            txtNacionalidad = new TextBox();
            txtNacionalidad.Location = new Point(250, yPosition);
            txtNacionalidad.Size = new Size(200, 25);
            txtNacionalidad.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtNacionalidad);
            yPosition += spacing;

            // Precio (Años Experiencia)
            lblPrecio = new Label();
            lblPrecio.Text = "  - Años experiencia";
            lblPrecio.Font = new Font("Arial", 9);
            lblPrecio.Location = new Point(20, yPosition);
            lblPrecio.Size = new Size(200, 20);
            this.Controls.Add(lblPrecio);

            txtAñosExp = new TextBox();
            txtAñosExp.Location = new Point(250, yPosition);
            txtAñosExp.Size = new Size(200, 25);
            txtAñosExp.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtAñosExp);
            yPosition += spacing;

            // Estado
            lblEstado = new Label();
            lblEstado.Text = "  - Estado";
            lblEstado.Font = new Font("Arial", 9);
            lblEstado.Location = new Point(20, yPosition);
            lblEstado.Size = new Size(200, 20);
            this.Controls.Add(lblEstado);

            comboActivo = new ComboBox();
            comboActivo.Items.Add("Activo");
            comboActivo.Items.Add("Inactivo");
            comboActivo.SelectedIndex = 0;
            comboActivo.Location = new Point(250, yPosition);
            comboActivo.Size = new Size(200, 25);
            comboActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(comboActivo);
            yPosition += spacing;

            // Fecha Ingreso (Fecha Nacimiento)
            lblFechaIngreso = new Label();
            lblFechaIngreso.Text = "  - Fecha Nacimiento | " + DateTime.Now.ToString("dddd | d \\de MMMM");
            lblFechaIngreso.Font = new Font("Arial", 9);
            lblFechaIngreso.Location = new Point(20, yPosition);
            lblFechaIngreso.Size = new Size(400, 20);
            this.Controls.Add(lblFechaIngreso);

            dateFechaNacimiento = new DateTimePicker();
            dateFechaNacimiento.Location = new Point(250, yPosition + 25);
            dateFechaNacimiento.Size = new Size(200, 25);
            dateFechaNacimiento.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dateFechaNacimiento);
            yPosition += 60;

            

            

            // Línea separadora final
            var separator2 = new Label();
            separator2.BorderStyle = BorderStyle.Fixed3D;
            separator2.Location = new Point(20, yPosition);
            separator2.Size = new Size(460, 2);
            this.Controls.Add(separator2);

            yPosition += 20;

            // Botón Añadir
            btnAñadir = new Button();
            btnAñadir.Text = "Añadir";
            btnAñadir.Font = new Font("Arial", 10, FontStyle.Bold);
            btnAñadir.ForeColor = Color.White;
            btnAñadir.BackColor = Color.SteelBlue;
            btnAñadir.FlatStyle = FlatStyle.Flat;
            btnAñadir.Location = new Point(200, yPosition);
            btnAñadir.Size = new Size(100, 35);
            btnAñadir.UseVisualStyleBackColor = false;
            btnAñadir.Click += new EventHandler(btnAñadir_Click);
            this.Controls.Add(btnAñadir);
        }
    }
}
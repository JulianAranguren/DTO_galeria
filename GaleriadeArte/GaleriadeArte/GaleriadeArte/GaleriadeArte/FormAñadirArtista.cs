using System;
using System.Windows.Forms;
using System.Drawing;

namespace GaleriadeArte
{
    public partial class FormAñadirArtista : Form
    {
        private ApiService _apiService;
        private TextBox txtNombre;
        private TextBox txtNacionalidad;
        private DateTimePicker dtpFechaNacimiento;
        private TextBox txtEstiloPrincipal;
        private TextBox txtEmail;
        private Button btnGuardar;
        private Button btnCancelar;

        public FormAñadirArtista()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private void InitializeComponent()
        {
            this.Text = "Añadir Nuevo Artista";
            this.Size = new Size(450, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Título
            var lblTitulo = new Label
            {
                Text = "NUEVO ARTISTA",
                Location = new Point(150, 10),
                Size = new Size(150, 25),
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Campos del formulario
            var lblNombre = new Label { Text = "Nombre:*", Location = new Point(30, 50), Size = new Size(120, 20) };
            txtNombre = new TextBox { Location = new Point(160, 50), Size = new Size(250, 25) };

            var lblNacionalidad = new Label { Text = "Nacionalidad:", Location = new Point(30, 90), Size = new Size(120, 20) };
            txtNacionalidad = new TextBox { Location = new Point(160, 90), Size = new Size(250, 25) };

            var lblFechaNacimiento = new Label { Text = "Fecha Nacimiento:", Location = new Point(30, 130), Size = new Size(120, 20) };
            dtpFechaNacimiento = new DateTimePicker
            {
                Location = new Point(160, 130),
                Size = new Size(250, 25),
                Format = DateTimePickerFormat.Short
            };

            var lblEstiloPrincipal = new Label { Text = "Estilo Principal:", Location = new Point(30, 170), Size = new Size(120, 20) };
            txtEstiloPrincipal = new TextBox { Location = new Point(160, 170), Size = new Size(250, 25) };

            var lblEmail = new Label { Text = "Email:", Location = new Point(30, 210), Size = new Size(120, 20) };
            txtEmail = new TextBox { Location = new Point(160, 210), Size = new Size(250, 25) };

            // Botones
            btnGuardar = new Button
            {
                Text = "Guardar",
                Location = new Point(160, 260),
                Size = new Size(100, 35),
                BackColor = Color.LightGreen
            };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(270, 260),
                Size = new Size(100, 35),
                BackColor = Color.LightCoral
            };

            // Eventos
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += (s, e) => this.Close();

            // Agregar controles
            this.Controls.AddRange(new Control[] {
                lblTitulo,
                lblNombre, txtNombre,
                lblNacionalidad, txtNacionalidad,
                lblFechaNacimiento, dtpFechaNacimiento,
                lblEstiloPrincipal, txtEstiloPrincipal,
                lblEmail, txtEmail,
                btnGuardar, btnCancelar
            });
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del artista es obligatorio", "Campo Requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                btnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                // Crear Artista con fecha construida manualmente (sin componentes de hora)
                var artista = new Artista
                {
                    Nombre = txtNombre.Text.Trim(),
                    Nacionalidad = string.IsNullOrWhiteSpace(txtNacionalidad.Text) ? null : txtNacionalidad.Text.Trim(),
                    FechaNacimiento = dtpFechaNacimiento.Checked
                        ? new DateTime(dtpFechaNacimiento.Value.Year,
                                      dtpFechaNacimiento.Value.Month,
                                      dtpFechaNacimiento.Value.Day)
                        : (DateTime?)null,
                    EstiloPrincipal = string.IsNullOrWhiteSpace(txtEstiloPrincipal.Text) ? null : txtEstiloPrincipal.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Activo = true
                };

                var resultado = await _apiService.CrearArtistaAsync(artista);

                if (resultado != null)
                {
                    MessageBox.Show($"Artista '{resultado.Nombre}' creado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear artista: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
    }
}
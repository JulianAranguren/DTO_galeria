using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace GaleriadeArte
{
    public partial class FormActualizarArtista : Form
    {
        private ApiService _apiService;
        private long _artistaId;
        private Artista _artistaOriginal;

        private TextBox txtNombre;
        private TextBox txtNacionalidad;
        private DateTimePicker dtpFechaNacimiento;
        private TextBox txtEstiloPrincipal;
        private TextBox txtEmail;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblId;

        public FormActualizarArtista(long artistaId)
        {
            _artistaId = artistaId;
            InitializeComponent();
            _apiService = new ApiService();
            _ = CargarDatosArtista();
        }

        private void InitializeComponent()
        {
            this.Text = "Actualizar Artista";
            this.Size = new Size(450, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Título
            var lblTitulo = new Label
            {
                Text = "ACTUALIZAR ARTISTA",
                Location = new Point(150, 10),
                Size = new Size(150, 25),
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ID (solo lectura)
            var lblIdTexto = new Label { Text = "ID:", Location = new Point(30, 50), Size = new Size(120, 20) };
            lblId = new Label { Text = "Cargando...", Location = new Point(160, 50), Size = new Size(100, 20), ForeColor = Color.Blue };

            // Campos del formulario
            var lblNombre = new Label { Text = "Nombre:*", Location = new Point(30, 80), Size = new Size(120, 20) };
            txtNombre = new TextBox { Location = new Point(160, 80), Size = new Size(250, 25) };

            var lblNacionalidad = new Label { Text = "Nacionalidad:", Location = new Point(30, 120), Size = new Size(120, 20) };
            txtNacionalidad = new TextBox { Location = new Point(160, 120), Size = new Size(250, 25) };

            var lblFechaNacimiento = new Label { Text = "Fecha Nacimiento:", Location = new Point(30, 160), Size = new Size(120, 20) };
            dtpFechaNacimiento = new DateTimePicker
            {
                Location = new Point(160, 160),
                Size = new Size(250, 25),
                Format = DateTimePickerFormat.Short,
                ShowCheckBox = true
            };

            var lblEstiloPrincipal = new Label { Text = "Estilo Principal:", Location = new Point(30, 200), Size = new Size(120, 20) };
            txtEstiloPrincipal = new TextBox { Location = new Point(160, 200), Size = new Size(250, 25) };

            var lblEmail = new Label { Text = "Email:", Location = new Point(30, 240), Size = new Size(120, 20) };
            txtEmail = new TextBox { Location = new Point(160, 240), Size = new Size(250, 25) };

            var lblActivo = new Label { Text = "Activo:", Location = new Point(30, 280), Size = new Size(120, 20) };
            chkActivo = new CheckBox { Location = new Point(160, 280), Size = new Size(100, 20), Checked = true };

            // Botones
            btnGuardar = new Button
            {
                Text = "💾 Guardar Cambios",
                Location = new Point(160, 320),
                Size = new Size(120, 35),
                BackColor = Color.LightGreen
            };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(290, 320),
                Size = new Size(100, 35)
            };

            // Eventos
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += (s, e) => this.Close();

            // Agregar controles
            this.Controls.AddRange(new Control[] {
                lblTitulo,
                lblIdTexto, lblId,
                lblNombre, txtNombre,
                lblNacionalidad, txtNacionalidad,
                lblFechaNacimiento, dtpFechaNacimiento,
                lblEstiloPrincipal, txtEstiloPrincipal,
                lblEmail, txtEmail,
                lblActivo, chkActivo,
                btnGuardar, btnCancelar
            });
        }

        private async Task CargarDatosArtista()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _artistaOriginal = await _apiService.GetArtistaAsync(_artistaId);

                if (_artistaOriginal != null)
                {
                    lblId.Text = _artistaOriginal.Id.ToString();
                    txtNombre.Text = _artistaOriginal.Nombre;
                    txtNacionalidad.Text = _artistaOriginal.Nacionalidad ?? "";

                    if (_artistaOriginal.FechaNacimiento.HasValue)
                    {
                        dtpFechaNacimiento.Value = _artistaOriginal.FechaNacimiento.Value;
                        dtpFechaNacimiento.Checked = true;
                    }

                    txtEstiloPrincipal.Text = _artistaOriginal.EstiloPrincipal ?? "";
                    txtEmail.Text = _artistaOriginal.Email ?? "";
                    chkActivo.Checked = _artistaOriginal.Activo;

                    this.Text = $"Actualizar - {_artistaOriginal.Nombre}";
                }
                else
                {
                    MessageBox.Show("No se encontró el artista", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del artista es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                btnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                var artistaActualizado = new Artista
                {
                    Nombre = txtNombre.Text.Trim(),
                    Nacionalidad = string.IsNullOrWhiteSpace(txtNacionalidad.Text) ? null : txtNacionalidad.Text.Trim(),
                    FechaNacimiento = dtpFechaNacimiento.Checked ? dtpFechaNacimiento.Value : (DateTime?)null,
                    EstiloPrincipal = string.IsNullOrWhiteSpace(txtEstiloPrincipal.Text) ? null : txtEstiloPrincipal.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Activo = chkActivo.Checked
                };

                var resultado = await _apiService.ActualizarArtistaAsync(_artistaId, artistaActualizado);

                if (resultado != null)
                {
                    MessageBox.Show($"✅ Artista '{resultado.Nombre}' actualizado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al actualizar artista: {ex.Message}", "Error",
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
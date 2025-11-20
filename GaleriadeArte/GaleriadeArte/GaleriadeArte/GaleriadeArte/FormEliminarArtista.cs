using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GaleriadeArte
{
    public partial class FormEliminarArtista : Form
    {
        private ApiService _apiService;
        private DataGridView dgvArtistas;
        private Button btnDesactivar;
        private Button btnActivar;
        private Button btnActualizar;
        private Button btnCerrar;
        private Label lblInfo;

        public FormEliminarArtista()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _ = CargarArtistas();
        }

        private void InitializeComponent()
        {
            this.Text = "Activar/Desactivar Artistas";
            this.Size = new Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(700, 400);

            // Título
            var lblTitulo = new Label
            {
                Text = "ACTIVAR / DESACTIVAR ARTISTAS",
                Location = new Point(300, 10),
                Size = new Size(300, 25),
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Información
            lblInfo = new Label
            {
                Text = "Seleccione un artista para cambiar su estado",
                Location = new Point(20, 45),
                Size = new Size(400, 20),
                ForeColor = Color.DarkBlue
            };

            // DataGridView
            dgvArtistas = new DataGridView
            {
                Location = new Point(20, 70),
                Size = new Size(840, 300),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };

            // Botones
            btnDesactivar = new Button
            {
                Text = "🚫 Desactivar",
                Location = new Point(20, 385),
                Size = new Size(100, 30),
                BackColor = Color.LightCoral
            };

            btnActivar = new Button
            {
                Text = "✅ Activar",
                Location = new Point(130, 385),
                Size = new Size(100, 30),
                BackColor = Color.LightGreen
            };

            btnActualizar = new Button
            {
                Text = "🔄 Actualizar",
                Location = new Point(240, 385),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue
            };

            btnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new Point(350, 385),
                Size = new Size(80, 30)
            };

            // Eventos
            btnDesactivar.Click += async (s, e) => await CambiarEstado(false);
            btnActivar.Click += async (s, e) => await CambiarEstado(true);
            btnActualizar.Click += async (s, e) => await CargarArtistas();
            btnCerrar.Click += (s, e) => this.Close();
            dgvArtistas.SelectionChanged += DgvArtistas_SelectionChanged;

            // Agregar controles
            this.Controls.AddRange(new Control[] {
                lblTitulo,
                lblInfo,
                dgvArtistas,
                btnDesactivar,
                btnActivar,
                btnActualizar,
                btnCerrar
            });
        }

        private async Task CargarArtistas()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var artistas = await _apiService.GetArtistasAsync();
                dgvArtistas.DataSource = artistas;
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar artistas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvArtistas.Columns.Count > 0)
            {
                dgvArtistas.Columns["Id"].Visible = false;
                dgvArtistas.Columns["Nombre"].HeaderText = "Nombre";
                dgvArtistas.Columns["Nacionalidad"].HeaderText = "Nacionalidad";
                dgvArtistas.Columns["EstiloPrincipal"].HeaderText = "Estilo Principal";
                dgvArtistas.Columns["Activo"].HeaderText = "Estado";
                dgvArtistas.Columns["Email"].HeaderText = "Email";

                // Formatear columna Activo
                dgvArtistas.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == dgvArtistas.Columns["Activo"].Index && e.Value != null)
                    {
                        bool activo = (bool)e.Value;
                        e.CellStyle.BackColor = activo ? Color.LightGreen : Color.LightPink;
                        e.CellStyle.ForeColor = activo ? Color.DarkGreen : Color.DarkRed;
                        e.Value = activo ? "ACTIVO" : "INACTIVO";
                    }
                };
            }
        }

        private void DgvArtistas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArtistas.SelectedRows.Count > 0)
            {
                var artista = dgvArtistas.SelectedRows[0].DataBoundItem as Artista;
                if (artista != null)
                {
                    lblInfo.Text = $"Artista seleccionado: {artista.Nombre} - {(artista.Activo ? "ACTIVO" : "INACTIVO")}";
                }
            }
        }

        private async Task CambiarEstado(bool activar)
        {
            if (dgvArtistas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un artista", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var artista = dgvArtistas.SelectedRows[0].DataBoundItem as Artista;
            if (artista == null || !artista.Id.HasValue)
                return;

            string accion = activar ? "activar" : "desactivar";
            string estado = activar ? "activo" : "inactivo";

            // Verificar si ya está en el estado deseado
            if (artista.Activo == activar)
            {
                MessageBox.Show($"El artista ya está {estado}", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultado = MessageBox.Show(
                $"¿Está seguro de {accion} al artista '{artista.Nombre}'?",
                $"Confirmar {accion.ToUpper()}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    bool exito;

                    if (activar)
                    {
                        // Para activar, necesitamos actualizar el artista
                        var artistaActualizado = new Artista
                        {
                            Nombre = artista.Nombre,
                            Nacionalidad = artista.Nacionalidad,
                            FechaNacimiento = artista.FechaNacimiento,
                            EstiloPrincipal = artista.EstiloPrincipal,
                            Email = artista.Email,
                            Activo = true
                        };
                        await _apiService.ActualizarArtistaAsync(artista.Id.Value, artistaActualizado);
                        exito = true;
                    }
                    else
                    {
                        // Para desactivar, usamos el método específico
                        exito = await _apiService.DesactivarArtistaAsync(artista.Id.Value);
                    }

                    if (exito)
                    {
                        MessageBox.Show($"Artista {accion}do exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarArtistas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al {accion} artista: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}
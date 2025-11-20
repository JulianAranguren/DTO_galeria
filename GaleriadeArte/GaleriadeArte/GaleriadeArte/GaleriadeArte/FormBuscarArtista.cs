using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace GaleriadeArte
{
    public partial class FormBuscarArtistas : Form
    {
        private ApiService _apiService;
        private TextBox txtBusqueda;
        private Button btnBuscar;
        private Button btnLimpiar;
        private Button btnSeleccionar;
        private Button btnCerrar;
        private DataGridView dgvResultados;
        private Label lblResultados;

        public Artista ArtistaSeleccionado { get; private set; }

        public FormBuscarArtistas()
        {
            InitializeComponent();
            _apiService = new ApiService();
            ArtistaSeleccionado = null;
            _ = CargarTodosLosArtistas();
        }

        private void InitializeComponent()
        {
            this.Text = "Buscar Artistas";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(600, 400);

            // Panel de búsqueda
            var pnlBusqueda = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(760, 50),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblBuscar = new Label
            {
                Text = "🔍 Buscar:",
                Location = new Point(10, 15),
                Size = new Size(60, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            txtBusqueda = new TextBox
            {
                Location = new Point(80, 15),
                Size = new Size(200, 25),
                Text = "Nombre del artista..." // Texto inicial como placeholder
            };

            // Configurar estilo de placeholder
            txtBusqueda.ForeColor = Color.Gray;
            txtBusqueda.Font = new Font(txtBusqueda.Font, FontStyle.Italic);

            btnBuscar = new Button
            {
                Text = "Buscar",
                Location = new Point(290, 15),
                Size = new Size(80, 25),
                BackColor = Color.LightBlue
            };

            btnLimpiar = new Button
            {
                Text = "Limpiar",
                Location = new Point(380, 15),
                Size = new Size(80, 25)
            };

            // Etiqueta de resultados
            lblResultados = new Label
            {
                Text = "Resultados:",
                Location = new Point(10, 70),
                Size = new Size(200, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            // DataGridView
            dgvResultados = new DataGridView
            {
                Location = new Point(10, 95),
                Size = new Size(760, 300),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };

            // Botones de acción
            btnSeleccionar = new Button
            {
                Text = "✅ Seleccionar",
                Location = new Point(10, 410),
                Size = new Size(100, 30),
                BackColor = Color.LightGreen
            };

            btnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new Point(120, 410),
                Size = new Size(80, 30)
            };

            // Eventos para simular placeholder
            txtBusqueda.Enter += (s, e) =>
            {
                if (txtBusqueda.Text == "Nombre del artista...")
                {
                    txtBusqueda.Text = "";
                    txtBusqueda.ForeColor = Color.Black;
                    txtBusqueda.Font = new Font(txtBusqueda.Font, FontStyle.Regular);
                }
            };

            txtBusqueda.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
                {
                    txtBusqueda.Text = "Nombre del artista...";
                    txtBusqueda.ForeColor = Color.Gray;
                    txtBusqueda.Font = new Font(txtBusqueda.Font, FontStyle.Italic);
                }
            };

            // Eventos normales
            btnBuscar.Click += async (s, e) => await BuscarArtistas();
            btnLimpiar.Click += async (s, e) => {
                txtBusqueda.Text = "Nombre del artista...";
                txtBusqueda.ForeColor = Color.Gray;
                txtBusqueda.Font = new Font(txtBusqueda.Font, FontStyle.Italic);
                await CargarTodosLosArtistas();
            };
            btnSeleccionar.Click += btnSeleccionar_Click;
            btnCerrar.Click += (s, e) => this.Close();
            dgvResultados.DoubleClick += (s, e) => btnSeleccionar_Click(s, e);
            txtBusqueda.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                    btnBuscar.PerformClick();
            };

            // Agregar controles al panel de búsqueda
            pnlBusqueda.Controls.AddRange(new Control[] { lblBuscar, txtBusqueda, btnBuscar, btnLimpiar });

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] {
                pnlBusqueda,
                lblResultados,
                dgvResultados,
                btnSeleccionar,
                btnCerrar
            });
        }

        private async Task CargarTodosLosArtistas()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var artistas = await _apiService.GetArtistasAsync();

                // CONVERTIR a lista anónima con Estado como string
                var datosMostrar = artistas.Select(a => new
                {
                    a.Id,
                    a.Nombre,
                    a.Nacionalidad,
                    a.EstiloPrincipal,
                    Estado = a.Activo ? "✅ ACTIVO" : "❌ INACTIVO" // Convertir aquí directamente
                }).ToList();

                dgvResultados.DataSource = datosMostrar;
                ConfigurarColumnas();
                lblResultados.Text = $"Todos los artistas ({artistas.Count} encontrados)";
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

        private async Task BuscarArtistas()
        {
            // Si el texto es el placeholder, buscar vacío
            string textoBusqueda = txtBusqueda.Text == "Nombre del artista..." ? "" : txtBusqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                await CargarTodosLosArtistas();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                var artistas = await _apiService.BuscarArtistasPorNombreAsync(textoBusqueda);

                // CONVERTIR a lista anónima con Estado como string
                var datosMostrar = artistas.Select(a => new
                {
                    a.Id,
                    a.Nombre,
                    a.Nacionalidad,
                    a.EstiloPrincipal,
                    Estado = a.Activo ? "✅ ACTIVO" : "❌ INACTIVO" // Convertir aquí directamente
                }).ToList();

                dgvResultados.DataSource = datosMostrar;
                ConfigurarColumnas();
                lblResultados.Text = $"Resultados para '{textoBusqueda}' ({artistas.Count} encontrados)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvResultados.Columns.Count > 0)
            {
                dgvResultados.Columns["Id"].Visible = false;
                dgvResultados.Columns["Nombre"].HeaderText = "Nombre";
                dgvResultados.Columns["Nacionalidad"].HeaderText = "Nacionalidad";
                dgvResultados.Columns["EstiloPrincipal"].HeaderText = "Estilo Principal";

                // ✅ CAMBIA "Activo" por "Estado" - porque ahora la columna se llama "Estado"
                if (dgvResultados.Columns.Contains("Estado"))
                {
                    dgvResultados.Columns["Estado"].HeaderText = "Estado";
                }

                // ⚠️ ELIMINA completamente esta línea que causa el error:
                // dgvResultados.Columns["Activo"].HeaderText = "Estado";
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un artista", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ArtistaSeleccionado = dgvResultados.SelectedRows[0].DataBoundItem as Artista;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

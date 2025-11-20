using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GaleriadeArte
{
    public partial class FormListarArtistas : Form
    {
        private ApiService _apiService;
        private DataGridView dgvArtistas;
        private Button btnActualizar;
        private Button btnCerrar;
        private Label lblTotal;

        public FormListarArtistas()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _ = CargarArtistas();
        }

        private void InitializeComponent()
        {
            this.Text = "Lista Completa de Artistas";
            this.Size = new Size(1000, 600); // Más ancho para mostrar todos los datos
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 500);

            // Título
            var lblTitulo = new Label
            {
                Text = "LISTA COMPLETA DE ARTISTAS",
                Location = new Point(350, 10),
                Size = new Size(300, 25),
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Label para total
            lblTotal = new Label
            {
                Text = "Cargando...",
                Location = new Point(20, 45),
                Size = new Size(300, 20),
                ForeColor = Color.DarkBlue,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            // DataGridView - Más grande para mostrar todos los datos
            dgvArtistas = new DataGridView
            {
                Location = new Point(20, 70),
                Size = new Size(940, 400),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D
            };

            // Botones
            btnActualizar = new Button
            {
                Text = "🔄 Actualizar Lista",
                Location = new Point(20, 485),
                Size = new Size(120, 35),
                BackColor = Color.LightBlue
            };

            btnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new Point(150, 485),
                Size = new Size(80, 35)
            };

            // Eventos
            btnActualizar.Click += async (s, e) => await CargarArtistas();
            btnCerrar.Click += (s, e) => this.Close();
            dgvArtistas.DoubleClick += DgvArtistas_DoubleClick;

            // Agregar controles
            this.Controls.AddRange(new Control[] {
                lblTitulo,
                lblTotal,
                dgvArtistas,
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
                ConfigurarColumnasCompletas();
                lblTotal.Text = $"Total de artistas encontrados: {artistas.Count}";
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

        private void ConfigurarColumnasCompletas()
        {
            if (dgvArtistas.Columns.Count > 0)
            {
                // PRIMERO hacer la columna "Activo" de solo lectura y configurarla bien
                if (dgvArtistas.Columns.Contains("Activo"))
                {
                    dgvArtistas.Columns["Activo"].HeaderText = "Estado";
                    dgvArtistas.Columns["Activo"].Width = 80;
                    dgvArtistas.Columns["Activo"].ReadOnly = true;

                    // Configurar como texto para evitar conflictos
                    dgvArtistas.Columns["Activo"].ValueType = typeof(string);
                }

                // Configurar las otras columnas...
                dgvArtistas.Columns["Id"].HeaderText = "ID";
                dgvArtistas.Columns["Id"].Width = 50;

                dgvArtistas.Columns["Nombre"].HeaderText = "Nombre del Artista";
                dgvArtistas.Columns["Nombre"].Width = 150;

                dgvArtistas.Columns["Nacionalidad"].HeaderText = "Nacionalidad";
                dgvArtistas.Columns["Nacionalidad"].Width = 100;

                dgvArtistas.Columns["FechaNacimiento"].HeaderText = "Fecha de Nacimiento";
                dgvArtistas.Columns["FechaNacimiento"].Width = 120;
                dgvArtistas.Columns["FechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvArtistas.Columns["EstiloPrincipal"].HeaderText = "Estilo Principal";
                dgvArtistas.Columns["EstiloPrincipal"].Width = 120;

                dgvArtistas.Columns["Email"].HeaderText = "Correo Electrónico";
                dgvArtistas.Columns["Email"].Width = 180;

                dgvArtistas.Columns["FechaRegistro"].HeaderText = "Fecha de Registro";
                dgvArtistas.Columns["FechaRegistro"].Width = 120;
                dgvArtistas.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Alternar colores de filas para mejor lectura
                dgvArtistas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        // Mover el evento CellFormatting a un método separado
        private void DgvArtistas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                // Formatear columna Activo
                if (dgvArtistas.Columns[e.ColumnIndex].Name == "Activo" && e.Value != null)
                {
                    if (bool.TryParse(e.Value?.ToString(), out bool activo))
                    {
                        e.CellStyle.BackColor = activo ? Color.LightGreen : Color.LightPink;
                        e.CellStyle.ForeColor = activo ? Color.DarkGreen : Color.DarkRed;
                        e.CellStyle.Font = new Font(dgvArtistas.Font, FontStyle.Bold);
                        e.Value = activo ? "✅ ACTIVO" : "❌ INACTIVO";
                        e.FormattingApplied = true;
                    }
                }

                // Formatear fechas nulas
                if ((dgvArtistas.Columns[e.ColumnIndex].Name == "FechaNacimiento" ||
                     dgvArtistas.Columns[e.ColumnIndex].Name == "FechaRegistro") &&
                    (e.Value == null || e.Value == DBNull.Value || e.Value.ToString() == ""))
                {
                    e.Value = "No especificado";
                    e.CellStyle.ForeColor = Color.Gray;
                    e.FormattingApplied = true;
                }
            }
            catch (Exception ex)
            {
                // Evitar que se propague la excepción
                e.Value = "Error";
                e.FormattingApplied = true;
            }
        }

        private void DgvArtistas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvArtistas.SelectedRows.Count > 0)
            {
                var artista = dgvArtistas.SelectedRows[0].DataBoundItem as Artista;
                if (artista != null)
                {
                    MostrarResumenArtista(artista);
                }
            }
        }

        private void MostrarResumenArtista(Artista artista)
        {
            string mensaje = $@"🎨 **INFORMACIÓN COMPLETA DEL ARTISTA**

**ID:** {artista.Id}
**Nombre:** {artista.Nombre}
**Nacionalidad:** {artista.Nacionalidad ?? "No especificado"}
**Fecha de Nacimiento:** {(artista.FechaNacimiento?.ToString("dd/MM/yyyy") ?? "No especificado")}
**Estilo Principal:** {artista.EstiloPrincipal ?? "No especificado"}
**Email:** {artista.Email ?? "No especificado"}
**Estado:** {(artista.Activo ? "✅ ACTIVO" : "❌ INACTIVO")}
**Fecha de Registro:** {(artista.FechaRegistro?.ToString("dd/MM/yyyy") ?? "No disponible")}";

            MessageBox.Show(mensaje, $"Resumen - {artista.Nombre}",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
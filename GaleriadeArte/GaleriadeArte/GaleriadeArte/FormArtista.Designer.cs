namespace GaleriadeArte
{
    partial class FormArtista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArtista));
            this.btnAñadirArtista = new System.Windows.Forms.Button();
            this.btnBuscarArtista = new System.Windows.Forms.Button();
            this.btnEliminarArtista = new System.Windows.Forms.Button();
            this.btnListarArtista = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAñadirArtista
            // 
            this.btnAñadirArtista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAñadirArtista.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAñadirArtista.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirArtista.Location = new System.Drawing.Point(100, 100);
            this.btnAñadirArtista.Name = "btnAñadirArtista";
            this.btnAñadirArtista.Size = new System.Drawing.Size(200, 50);
            this.btnAñadirArtista.TabIndex = 0;
            this.btnAñadirArtista.Text = "Añadir Artista";
            this.btnAñadirArtista.UseVisualStyleBackColor = true;
            this.btnAñadirArtista.Click += new System.EventHandler(this.btnAñadirArtista_Click);
            // 
            // btnBuscarArtista
            // 
            this.btnBuscarArtista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarArtista.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBuscarArtista.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarArtista.Location = new System.Drawing.Point(100, 170);
            this.btnBuscarArtista.Name = "btnBuscarArtista";
            this.btnBuscarArtista.Size = new System.Drawing.Size(200, 50);
            this.btnBuscarArtista.TabIndex = 1;
            this.btnBuscarArtista.Text = "Buscar Artista";
            this.btnBuscarArtista.UseVisualStyleBackColor = true;
            this.btnBuscarArtista.Click += new System.EventHandler(this.btnBuscarArtista_Click);
            // 
            // btnEliminarArtista
            // 
            this.btnEliminarArtista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarArtista.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEliminarArtista.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArtista.Location = new System.Drawing.Point(100, 240);
            this.btnEliminarArtista.Name = "btnEliminarArtista";
            this.btnEliminarArtista.Size = new System.Drawing.Size(200, 50);
            this.btnEliminarArtista.TabIndex = 2;
            this.btnEliminarArtista.Text = "Activar/Desactivar Artista";
            this.btnEliminarArtista.UseVisualStyleBackColor = true;
            this.btnEliminarArtista.Click += new System.EventHandler(this.btnGestionarEstados_Click);
            // 
            // btnListarArtista
            // 
            this.btnListarArtista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnListarArtista.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnListarArtista.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarArtista.Location = new System.Drawing.Point(100, 310);
            this.btnListarArtista.Name = "btnListarArtista";
            this.btnListarArtista.Size = new System.Drawing.Size(200, 50);
            this.btnListarArtista.TabIndex = 3;
            this.btnListarArtista.Text = "Listar Artistas";
            this.btnListarArtista.UseVisualStyleBackColor = true;
            this.btnListarArtista.Click += new System.EventHandler(this.btnListarArtista_Click);
            // 
            // FormArtista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImage = global::GaleriadeArte.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.btnListarArtista);
            this.Controls.Add(this.btnEliminarArtista);
            this.Controls.Add(this.btnBuscarArtista);
            this.Controls.Add(this.btnAñadirArtista);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormArtista";
            this.Text = "Gestión de Artistas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAñadirArtista;
        private System.Windows.Forms.Button btnBuscarArtista;
        private System.Windows.Forms.Button btnEliminarArtista;
        private System.Windows.Forms.Button btnListarArtista;
    }
}
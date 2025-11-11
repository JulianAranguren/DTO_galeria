namespace GaleriadeArte
{
    partial class FormAutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutor));
            this.btnAñadirAutor = new System.Windows.Forms.Button();
            this.btnBuscarAutor = new System.Windows.Forms.Button();
            this.btnEliminarAutor = new System.Windows.Forms.Button();
            this.btnListarAutor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAñadirAutor
            // 
            this.btnAñadirAutor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAñadirAutor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAñadirAutor.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirAutor.Location = new System.Drawing.Point(100, 100);
            this.btnAñadirAutor.Name = "btnAñadirAutor";
            this.btnAñadirAutor.Size = new System.Drawing.Size(200, 50);
            this.btnAñadirAutor.TabIndex = 0;
            this.btnAñadirAutor.Text = "Añadir Autor";
            this.btnAñadirAutor.UseVisualStyleBackColor = true;
            this.btnAñadirAutor.Click += new System.EventHandler(this.btnAñadirAutor_Click);
            // 
            // btnBuscarAutor
            // 
            this.btnBuscarAutor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarAutor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBuscarAutor.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarAutor.Location = new System.Drawing.Point(100, 170);
            this.btnBuscarAutor.Name = "btnBuscarAutor";
            this.btnBuscarAutor.Size = new System.Drawing.Size(200, 50);
            this.btnBuscarAutor.TabIndex = 1;
            this.btnBuscarAutor.Text = "Buscar Autor";
            this.btnBuscarAutor.UseVisualStyleBackColor = true;
            this.btnBuscarAutor.Click += new System.EventHandler(this.btnBuscarAutor_Click);
            // 
            // btnEliminarAutor
            // 
            this.btnEliminarAutor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarAutor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEliminarAutor.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarAutor.Location = new System.Drawing.Point(100, 240);
            this.btnEliminarAutor.Name = "btnEliminarAutor";
            this.btnEliminarAutor.Size = new System.Drawing.Size(200, 50);
            this.btnEliminarAutor.TabIndex = 2;
            this.btnEliminarAutor.Text = "Eliminar Autor";
            this.btnEliminarAutor.UseVisualStyleBackColor = true;
            
            // 
            // btnListarAutor
            // 
            this.btnListarAutor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnListarAutor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnListarAutor.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarAutor.Location = new System.Drawing.Point(100, 310);
            this.btnListarAutor.Name = "btnListarAutor";
            this.btnListarAutor.Size = new System.Drawing.Size(200, 50);
            this.btnListarAutor.TabIndex = 3;
            this.btnListarAutor.Text = "Listar Autores";
            this.btnListarAutor.UseVisualStyleBackColor = true;
            this.btnListarAutor.Click += new System.EventHandler(this.btnListarAutor_Click);
            // 
            // FormAutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImage = global::GaleriadeArte.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.btnListarAutor);
            this.Controls.Add(this.btnEliminarAutor);
            this.Controls.Add(this.btnBuscarAutor);
            this.Controls.Add(this.btnAñadirAutor);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAutor";
            this.Text = "Gestión de Autores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAñadirAutor;
        private System.Windows.Forms.Button btnBuscarAutor;
        private System.Windows.Forms.Button btnEliminarAutor;
        private System.Windows.Forms.Button btnListarAutor;
    }
}
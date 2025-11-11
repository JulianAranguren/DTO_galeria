namespace GaleriadeArte
{
    partial class FormEscultura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEscultura));
            this.btnListarEscultura = new System.Windows.Forms.Button();
            this.btnEliminarEscultura = new System.Windows.Forms.Button();
            this.btnBuscarEscultura = new System.Windows.Forms.Button();
            this.btnAgregarEscultura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnListarEscultura
            // 
            this.btnListarEscultura.Location = new System.Drawing.Point(51, 259);
            this.btnListarEscultura.Name = "btnListarEscultura";
            this.btnListarEscultura.Size = new System.Drawing.Size(106, 27);
            this.btnListarEscultura.TabIndex = 7;
            this.btnListarEscultura.Text = "Listar";
            this.btnListarEscultura.UseVisualStyleBackColor = true;
            this.btnListarEscultura.Click += new System.EventHandler(this.btnListarEscultura_Click);
            // 
            // btnEliminarEscultura
            // 
            this.btnEliminarEscultura.Location = new System.Drawing.Point(51, 195);
            this.btnEliminarEscultura.Name = "btnEliminarEscultura";
            this.btnEliminarEscultura.Size = new System.Drawing.Size(106, 27);
            this.btnEliminarEscultura.TabIndex = 6;
            this.btnEliminarEscultura.Text = "Eliminar";
            this.btnEliminarEscultura.UseVisualStyleBackColor = true;
            this.btnEliminarEscultura.Click += new System.EventHandler(this.btnEliminarEscultura_Click);
            // 
            // btnBuscarEscultura
            // 
            this.btnBuscarEscultura.Location = new System.Drawing.Point(51, 130);
            this.btnBuscarEscultura.Name = "btnBuscarEscultura";
            this.btnBuscarEscultura.Size = new System.Drawing.Size(106, 27);
            this.btnBuscarEscultura.TabIndex = 5;
            this.btnBuscarEscultura.Text = "Buscar";
            this.btnBuscarEscultura.UseVisualStyleBackColor = true;
            this.btnBuscarEscultura.Click += new System.EventHandler(this.btnBuscarEscultura_Click);
            // 
            // btnAgregarEscultura
            // 
            this.btnAgregarEscultura.Location = new System.Drawing.Point(51, 70);
            this.btnAgregarEscultura.Name = "btnAgregarEscultura";
            this.btnAgregarEscultura.Size = new System.Drawing.Size(106, 27);
            this.btnAgregarEscultura.TabIndex = 4;
            this.btnAgregarEscultura.Text = "Añadir";
            this.btnAgregarEscultura.UseVisualStyleBackColor = true;
            this.btnAgregarEscultura.Click += new System.EventHandler(this.btnAgregarEscultura_Click);
            // 
            // FormEscultura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImage = global::GaleriadeArte.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1200, 562);
            this.Controls.Add(this.btnListarEscultura);
            this.Controls.Add(this.btnEliminarEscultura);
            this.Controls.Add(this.btnBuscarEscultura);
            this.Controls.Add(this.btnAgregarEscultura);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEscultura";
            this.Text = "FormEscultura";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListarEscultura;
        private System.Windows.Forms.Button btnEliminarEscultura;
        private System.Windows.Forms.Button btnBuscarEscultura;
        private System.Windows.Forms.Button btnAgregarEscultura;
    }
}
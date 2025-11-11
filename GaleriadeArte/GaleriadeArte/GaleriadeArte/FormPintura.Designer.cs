namespace GaleriadeArte
{
    partial class FormPintura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPintura));
            this.btnAgregarPintura = new System.Windows.Forms.Button();
            this.btnBuscarPintura = new System.Windows.Forms.Button();
            this.btnEliminarPintura = new System.Windows.Forms.Button();
            this.btnListarPintura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarPintura
            // 
            this.btnAgregarPintura.Location = new System.Drawing.Point(55, 58);
            this.btnAgregarPintura.Name = "btnAgregarPintura";
            this.btnAgregarPintura.Size = new System.Drawing.Size(106, 27);
            this.btnAgregarPintura.TabIndex = 0;
            this.btnAgregarPintura.Text = "Añadir";
            this.btnAgregarPintura.UseVisualStyleBackColor = true;
            this.btnAgregarPintura.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscarPintura
            // 
            this.btnBuscarPintura.Location = new System.Drawing.Point(55, 118);
            this.btnBuscarPintura.Name = "btnBuscarPintura";
            this.btnBuscarPintura.Size = new System.Drawing.Size(106, 27);
            this.btnBuscarPintura.TabIndex = 1;
            this.btnBuscarPintura.Text = "Buscar";
            this.btnBuscarPintura.UseVisualStyleBackColor = true;
            this.btnBuscarPintura.Click += new System.EventHandler(this.btnBuscarPintura_Click);
            // 
            // btnEliminarPintura
            // 
            this.btnEliminarPintura.Location = new System.Drawing.Point(55, 183);
            this.btnEliminarPintura.Name = "btnEliminarPintura";
            this.btnEliminarPintura.Size = new System.Drawing.Size(106, 27);
            this.btnEliminarPintura.TabIndex = 2;
            this.btnEliminarPintura.Text = "Eliminar";
            this.btnEliminarPintura.UseVisualStyleBackColor = true;
            this.btnEliminarPintura.Click += new System.EventHandler(this.btnEliminarPintura_Click);
            // 
            // btnListarPintura
            // 
            this.btnListarPintura.Location = new System.Drawing.Point(55, 247);
            this.btnListarPintura.Name = "btnListarPintura";
            this.btnListarPintura.Size = new System.Drawing.Size(106, 27);
            this.btnListarPintura.TabIndex = 3;
            this.btnListarPintura.Text = "Listar";
            this.btnListarPintura.UseVisualStyleBackColor = true;
            this.btnListarPintura.Click += new System.EventHandler(this.btnListarPintura_Click);
            // 
            // FormPintura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImage = global::GaleriadeArte.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1200, 562);
            this.Controls.Add(this.btnListarPintura);
            this.Controls.Add(this.btnEliminarPintura);
            this.Controls.Add(this.btnBuscarPintura);
            this.Controls.Add(this.btnAgregarPintura);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPintura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPintura";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarPintura;
        private System.Windows.Forms.Button btnBuscarPintura;
        private System.Windows.Forms.Button btnEliminarPintura;
        private System.Windows.Forms.Button btnListarPintura;
    }
}
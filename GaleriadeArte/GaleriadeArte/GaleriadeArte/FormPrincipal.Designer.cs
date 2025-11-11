namespace GaleriadeArte
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnEscultura = new System.Windows.Forms.Button();
            this.btnPintura = new System.Windows.Forms.Button();
            this.txtBienvenida1 = new System.Windows.Forms.Label();
            this.btnAcercaDe = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEscultura
            // 
            this.btnEscultura.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEscultura.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEscultura.Location = new System.Drawing.Point(30, 245);
            this.btnEscultura.Name = "btnEscultura";
            this.btnEscultura.Size = new System.Drawing.Size(144, 37);
            this.btnEscultura.TabIndex = 3;
            this.btnEscultura.Text = "Escultura";
            this.btnEscultura.UseVisualStyleBackColor = true;
            this.btnEscultura.Click += new System.EventHandler(this.btnEscultura_Click);
            // 
            // btnPintura
            // 
            this.btnPintura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPintura.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPintura.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPintura.Location = new System.Drawing.Point(610, 245);
            this.btnPintura.Name = "btnPintura";
            this.btnPintura.Size = new System.Drawing.Size(131, 37);
            this.btnPintura.TabIndex = 4;
            this.btnPintura.Text = "Pintura";
            this.btnPintura.UseVisualStyleBackColor = true;
            this.btnPintura.Click += new System.EventHandler(this.btnPintura_Click);
            // 
            // txtBienvenida1
            // 
            this.txtBienvenida1.AutoSize = true;
            this.txtBienvenida1.Font = new System.Drawing.Font("MS UI Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBienvenida1.Location = new System.Drawing.Point(239, 387);
            this.txtBienvenida1.Name = "txtBienvenida1";
            this.txtBienvenida1.Size = new System.Drawing.Size(301, 20);
            this.txtBienvenida1.TabIndex = 5;
            this.txtBienvenida1.Text = "Bienvenido a la Galeria de Arte";
            this.txtBienvenida1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAcercaDe
            // 
            this.btnAcercaDe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAcercaDe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAcercaDe.Font = new System.Drawing.Font("MS UI Gothic", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcercaDe.Location = new System.Drawing.Point(657, 415);
            this.btnAcercaDe.Name = "btnAcercaDe";
            this.btnAcercaDe.Size = new System.Drawing.Size(131, 32);
            this.btnAcercaDe.TabIndex = 6;
            this.btnAcercaDe.Text = "Acerca De";
            this.btnAcercaDe.UseVisualStyleBackColor = true;
            this.btnAcercaDe.Click += new System.EventHandler(this.btnAcercaDe_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(317, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Autor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAutor_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAcercaDe);
            this.Controls.Add(this.txtBienvenida1);
            this.Controls.Add(this.btnPintura);
            this.Controls.Add(this.btnEscultura);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Galeria de Arte";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEscultura;
        private System.Windows.Forms.Button btnPintura;
        private System.Windows.Forms.Label txtBienvenida1;
        private System.Windows.Forms.Button btnAcercaDe;
        private System.Windows.Forms.Button button1;
    }
}


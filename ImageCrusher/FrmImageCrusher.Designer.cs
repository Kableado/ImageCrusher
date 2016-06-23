namespace ImageCrusher
{
    partial class FrmImageCrusher
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCrush = new System.Windows.Forms.Button();
            this.lstImagenes = new System.Windows.Forms.ListBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCrush
            // 
            this.btnCrush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrush.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrush.Location = new System.Drawing.Point(284, 288);
            this.btnCrush.Name = "btnCrush";
            this.btnCrush.Size = new System.Drawing.Size(114, 30);
            this.btnCrush.TabIndex = 0;
            this.btnCrush.Text = "Crush";
            this.btnCrush.UseVisualStyleBackColor = true;
            this.btnCrush.Click += new System.EventHandler(this.btnCrush_Click);
            // 
            // lstImagenes
            // 
            this.lstImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstImagenes.FormattingEnabled = true;
            this.lstImagenes.Location = new System.Drawing.Point(12, 40);
            this.lstImagenes.Name = "lstImagenes";
            this.lstImagenes.Size = new System.Drawing.Size(386, 238);
            this.lstImagenes.TabIndex = 1;
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(74, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(324, 20);
            this.txtPath.TabIndex = 2;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 15);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(30, 13);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "Ruta";
            // 
            // txtSize
            // 
            this.txtSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSize.Location = new System.Drawing.Point(74, 284);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 4;
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(12, 287);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(46, 13);
            this.lblSize.TabIndex = 5;
            this.lblSize.Text = "Tamaño";
            // 
            // FrmImageCrusher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 330);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lstImagenes);
            this.Controls.Add(this.btnCrush);
            this.Name = "FrmImageCrusher";
            this.Text = "ImageCrusher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImageCrusher_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrush;
        private System.Windows.Forms.ListBox lstImagenes;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
    }
}


namespace Grafik
{
    partial class frm_Grafik
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.rb_Linie = new System.Windows.Forms.RadioButton();
            this.rb_Rechteck = new System.Windows.Forms.RadioButton();
            this.rb_Ellipse = new System.Windows.Forms.RadioButton();
            this.cdl_Farbe = new System.Windows.Forms.ColorDialog();
            this.btn_Farbe = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_Import = new System.Windows.Forms.Button();
            this.rb_Haus = new System.Windows.Forms.RadioButton();
            this.tbr_Staerke = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbr_Staerke)).BeginInit();
            this.SuspendLayout();
            // 
            // rb_Linie
            // 
            this.rb_Linie.AutoSize = true;
            this.rb_Linie.Checked = true;
            this.rb_Linie.Location = new System.Drawing.Point(26, 20);
            this.rb_Linie.Name = "rb_Linie";
            this.rb_Linie.Size = new System.Drawing.Size(59, 21);
            this.rb_Linie.TabIndex = 0;
            this.rb_Linie.TabStop = true;
            this.rb_Linie.Text = "Linie";
            this.rb_Linie.UseVisualStyleBackColor = true;
            // 
            // rb_Rechteck
            // 
            this.rb_Rechteck.AutoSize = true;
            this.rb_Rechteck.Location = new System.Drawing.Point(26, 48);
            this.rb_Rechteck.Name = "rb_Rechteck";
            this.rb_Rechteck.Size = new System.Drawing.Size(88, 21);
            this.rb_Rechteck.TabIndex = 1;
            this.rb_Rechteck.Text = "Rechteck";
            this.rb_Rechteck.UseVisualStyleBackColor = true;
            // 
            // rb_Ellipse
            // 
            this.rb_Ellipse.AutoSize = true;
            this.rb_Ellipse.Location = new System.Drawing.Point(26, 80);
            this.rb_Ellipse.Name = "rb_Ellipse";
            this.rb_Ellipse.Size = new System.Drawing.Size(70, 21);
            this.rb_Ellipse.TabIndex = 2;
            this.rb_Ellipse.Text = "Ellipse";
            this.rb_Ellipse.UseVisualStyleBackColor = true;
            // 
            // btn_Farbe
            // 
            this.btn_Farbe.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Farbe.Location = new System.Drawing.Point(26, 151);
            this.btn_Farbe.Name = "btn_Farbe";
            this.btn_Farbe.Size = new System.Drawing.Size(50, 50);
            this.btn_Farbe.TabIndex = 3;
            this.btn_Farbe.UseVisualStyleBackColor = false;
            this.btn_Farbe.Click += new System.EventHandler(this.btn_Farbe_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(23, 207);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(62, 30);
            this.btn_Export.TabIndex = 5;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(23, 243);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(62, 30);
            this.btn_Import.TabIndex = 6;
            this.btn_Import.Text = "Import";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // rb_Haus
            // 
            this.rb_Haus.AutoSize = true;
            this.rb_Haus.Location = new System.Drawing.Point(26, 111);
            this.rb_Haus.Name = "rb_Haus";
            this.rb_Haus.Size = new System.Drawing.Size(62, 21);
            this.rb_Haus.TabIndex = 7;
            this.rb_Haus.Text = "Haus";
            this.rb_Haus.UseVisualStyleBackColor = true;
            // 
            // tbr_Staerke
            // 
            this.tbr_Staerke.Location = new System.Drawing.Point(23, 292);
            this.tbr_Staerke.Maximum = 5;
            this.tbr_Staerke.Minimum = 1;
            this.tbr_Staerke.Name = "tbr_Staerke";
            this.tbr_Staerke.Size = new System.Drawing.Size(91, 56);
            this.tbr_Staerke.TabIndex = 8;
            this.tbr_Staerke.Value = 1;
            // 
            // frm_Grafik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbr_Staerke);
            this.Controls.Add(this.rb_Haus);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btn_Farbe);
            this.Controls.Add(this.rb_Ellipse);
            this.Controls.Add(this.rb_Rechteck);
            this.Controls.Add(this.rb_Linie);
            this.DoubleBuffered = true;
            this.Name = "frm_Grafik";
            this.Text = "Grafik";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frm_Grafik_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_Grafik_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frm_Grafik_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frm_Grafik_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.tbr_Staerke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_Linie;
        private System.Windows.Forms.RadioButton rb_Rechteck;
        private System.Windows.Forms.RadioButton rb_Ellipse;
        private System.Windows.Forms.ColorDialog cdl_Farbe;
        private System.Windows.Forms.Button btn_Farbe;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.RadioButton rb_Haus;
        private System.Windows.Forms.TrackBar tbr_Staerke;
    }
}


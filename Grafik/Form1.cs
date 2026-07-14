using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Grafik
{
    enum Typ { Linie, Rechteck, Ellipse, Quadrat, Kreis, Haus};
    public partial class frm_Grafik : Form
    {
        List<cls_Grafikobjekt> m_ElementListe = new List<cls_Grafikobjekt>();
        cls_Grafikobjekt m_aktueller_eintrag;
        bool zeichnen;
        int m_staerke;


        public frm_Grafik()
        {
            InitializeComponent();
            btn_Farbe.BackColor = cdl_Farbe.Color;
        }

        private void frm_Grafik_Paint(object sender, PaintEventArgs e)
        {
            foreach (cls_Grafikobjekt element in m_ElementListe)
            {
                element.Zeichne(e.Graphics);
            }

            if (zeichnen == true)
            {
                m_aktueller_eintrag.Zeichne(e.Graphics);
            }
        }

        private void frm_Grafik_MouseDown(object sender, MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    zeichnen = true;
                    m_staerke = tbr_Staerke.Value;
                    Pen farbe = new Pen(cdl_Farbe.Color,m_staerke);
                    if (rb_Linie.Checked)
                    {
                        m_aktueller_eintrag = new cls_Linie(farbe);
                    }
                    else if (rb_Rechteck.Checked)
                    {
                        if (Control.ModifierKeys == Keys.Shift)
                            m_aktueller_eintrag = new cls_Quadrat(farbe);
                        else
                            m_aktueller_eintrag = new cls_Rechteck(farbe);
                    }
                    else if (rb_Ellipse.Checked)
                    {
                        if (Control.ModifierKeys == Keys.Shift)
                            m_aktueller_eintrag = new cls_Kreis(farbe);
                        else
                            m_aktueller_eintrag = new cls_Ellipse(farbe);
                    }
                    else
                    {
                        m_aktueller_eintrag = new cls_Haus(farbe);
                    }

                    m_aktueller_eintrag.SetzeStartpunkt(e.Location);
                    break;
                case MouseButtons.Right:
                    foreach (cls_Grafikobjekt element in m_ElementListe)
                        if (element.GetType() == typeof(cls_Haus))
                            (element as cls_Haus).Drehen(e.Location);
                    this.Invalidate();
                    break;
                case MouseButtons.Middle:
                    foreach (cls_Grafikobjekt element in m_ElementListe)
                        if (element.GetType() == typeof(cls_Haus))
                            (element as cls_Haus).OriginalPosition(e.Location);
                    this.Invalidate();
                    break;
            }

        }

        private void frm_Grafik_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                zeichnen = false;
                m_aktueller_eintrag.SetzeEndpunkt(e.Location);
                m_ElementListe.Add(m_aktueller_eintrag);
                this.Invalidate(); //löst Paint event aus
            }
            
        }

        private void btn_Farbe_Click(object sender, EventArgs e)
        {
            if (cdl_Farbe.ShowDialog() == DialogResult.OK)
            {
                btn_Farbe.BackColor = cdl_Farbe.Color;
            }
        }

        private void frm_Grafik_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (zeichnen == true)
                {
                    m_aktueller_eintrag.SetzeEndpunkt(e.Location);
                    this.Invalidate();
                }
            }
            
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists($"{Application.StartupPath}\\Daten"))
                Directory.CreateDirectory($"{Application.StartupPath}\\Daten");

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = $"{Application.StartupPath}\\Daten";
            dlg.FileName = "daten";
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Datei |*.csv|Alle Dateien |*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter export = new StreamWriter(dlg.FileName);
                foreach (cls_Grafikobjekt element in m_ElementListe)
                    export.WriteLine(element.ToCSV());
                export.Close();
                MessageBox.Show($"{m_ElementListe.Count} Daten wurden exportiert!", "Information");
            }

            
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = $"{Application.StartupPath}\\Daten";
            dlg.FileName = "daten";
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Datei |*.csv|Alle Dateien |*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists("Daten"))
                {
                    m_ElementListe.Clear();
                    StreamReader import = new StreamReader(dlg.FileName);
                    while (!import.EndOfStream)
                    {
                        string zeile = import.ReadLine();
                        string[] teile = zeile.Split(';');
                        int farbe = Convert.ToInt32(teile[5]);
                        Pen color = new Pen(Color.FromArgb(farbe));
                        switch (teile[0])
                        {
                            case "Linie":
                                m_aktueller_eintrag = new cls_Linie(color);
                                break;
                            case "Rechteck":
                                m_aktueller_eintrag = new cls_Rechteck(color);
                                break;
                            case "Ellipse":
                                m_aktueller_eintrag = new cls_Ellipse(color);
                                break;
                            case "Quadrat":
                                m_aktueller_eintrag = new cls_Quadrat(color);
                                break;
                            case "Kreis":
                                m_aktueller_eintrag = new cls_Kreis(color);
                                break;
                            case "Haus":
                                m_aktueller_eintrag = new cls_Haus(color);
                                break;
                        }
                        Point start = new Point(Convert.ToInt32(teile[1]), Convert.ToInt32(teile[2]));
                        Point ende = new Point(Convert.ToInt32(teile[3]), Convert.ToInt32(teile[4]));
                        m_aktueller_eintrag.SetzeStartpunkt(start);
                        m_aktueller_eintrag.SetzeEndpunkt(ende);
                        m_ElementListe.Add(m_aktueller_eintrag);
                    }
                    import.Close();
                    this.Invalidate();
                    MessageBox.Show($"{m_ElementListe.Count} Daten wurden importiert!", "Information");
                }
                else
                    MessageBox.Show("Daten konnten nicht importiert werden!", "Fehler");
            }
        }
    }
}

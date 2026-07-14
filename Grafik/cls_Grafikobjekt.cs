using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grafik
{
    abstract class cls_Grafikobjekt
    {
        protected Typ m_typ;
        protected Point m_Startpunkt;
        protected Point m_Endpunkt;
        protected Pen m_Farbe;
        public cls_Grafikobjekt(Pen pen)
        {
            m_Farbe = pen;
        }

        public abstract void Zeichne(Graphics graphics);
        //{
        //if (m_typ == Typ.Linie)
        //{
        //    graphics.DrawLine(Pens.Black, punkte[0], punkte[1], punkte[2], punkte[3]);
        //}
        //else if (m_typ == Typ.Rechteck)
        //{
        //    graphics.DrawRectangle(Pens.Black, Math.Min(punkte[0], punkte[2]), Math.Min(punkte[1], punkte[3]), Math.Abs(punkte[2] - punkte[0]), Math.Abs(punkte[3] - punkte[1]));
        //}
        //else if (m_typ == Typ.Ellipse)
        //{
        //    graphics.DrawEllipse(Pens.Black, Math.Min(punkte[0], punkte[2]), Math.Min(punkte[1], punkte[3]), Math.Abs(punkte[2] - punkte[0]), Math.Abs(punkte[3] - punkte[1]));
        //}
        //}

        public void SetzeStartpunkt(Point location)
        {
            m_Startpunkt = location;
        }

        public virtual void SetzeEndpunkt(Point location)
        {
            m_Endpunkt = location;
        }
        public string ToCSV()
        {
            return $"{m_typ.ToString()};{m_Startpunkt.X.ToString()};{m_Startpunkt.Y.ToString()};{m_Endpunkt.X.ToString()};{m_Endpunkt.Y.ToString()};{m_Farbe.Color.ToArgb()}";
        }

    }

    class cls_Linie : cls_Grafikobjekt
    {
        public cls_Linie(Pen pen) : base(pen)
        {
            m_typ = Typ.Linie;
        }
        public override void Zeichne(Graphics graphics)
        {
            graphics.DrawLine(m_Farbe, m_Startpunkt, m_Endpunkt);

        }
    }

    class cls_Rechteck : cls_Grafikobjekt
    {
        protected int m_startX;
        protected int m_startY;
        protected int m_breite;
        protected int m_hoehe;
        public cls_Rechteck(Pen pen) : base(pen)
        {
            m_typ = Typ.Rechteck;
        }
        public override void SetzeEndpunkt(Point location)
        {
            base.SetzeEndpunkt(location);
            m_startX = Math.Min(m_Startpunkt.X, m_Endpunkt.X);
            m_startY = Math.Min(m_Startpunkt.Y, m_Endpunkt.Y);
            m_breite = Math.Abs(m_Startpunkt.X - m_Endpunkt.X);
            m_hoehe = Math.Abs(m_Startpunkt.Y - m_Endpunkt.Y);
        }
        public override void Zeichne(Graphics graphics)
        {
            graphics.DrawRectangle(m_Farbe, m_startX, m_startY, m_breite, m_hoehe);
        }
    }

    class cls_Quadrat : cls_Rechteck
    {
        public cls_Quadrat(Pen pen) : base(pen)
        {
            m_typ = Typ.Quadrat;
        }
        public override void SetzeEndpunkt(Point location)
        {
            base.SetzeEndpunkt(location);
            if (m_hoehe < m_breite)
            {
                m_breite = m_hoehe;
            }
            else
            {
                m_hoehe = m_breite;
            }
            //m_hoehe = Math.Min(m_hoehe, m_breite);
            //m_breite = m_hoehe;

            if (m_Endpunkt.X < m_Startpunkt.X)
            {
                m_startX = m_Startpunkt.X - m_breite;
            }

            if (m_Endpunkt.Y < m_Startpunkt.Y)
            {
                m_startY = m_Startpunkt.Y - m_breite;
            }
        }
    }
    class cls_Ellipse : cls_Grafikobjekt
    {
        protected int m_startX;
        protected int m_startY;
        protected int m_breite;
        protected int m_hoehe;
        public cls_Ellipse(Pen pen) : base(pen)
        {
            m_typ = Typ.Ellipse;
        }
        public override void SetzeEndpunkt(Point location)
        {
            base.SetzeEndpunkt(location);
            m_startX = Math.Min(m_Startpunkt.X, m_Endpunkt.X);
            m_startY = Math.Min(m_Startpunkt.Y, m_Endpunkt.Y);
            m_breite = Math.Abs(m_Startpunkt.X - m_Endpunkt.X);
            m_hoehe = Math.Abs(m_Startpunkt.Y - m_Endpunkt.Y);
        }
        public override void Zeichne(Graphics graphics)
        {
            //graphics.DrawEllipse(Pens.Black, Math.Min(m_punkte[0], m_punkte[2]), Math.Min(m_punkte[1], m_punkte[3]), Math.Abs(m_punkte[2] - m_punkte[0]), Math.Abs(m_punkte[3] - m_punkte[1]));
            graphics.DrawEllipse(m_Farbe, m_startX, m_startY, m_breite, m_hoehe);
        }
    }

    class cls_Kreis : cls_Ellipse
    {
        public cls_Kreis(Pen pen) : base(pen)
        {
            m_typ = Typ.Kreis;
        }
        public override void SetzeEndpunkt(Point location)
        {
            base.SetzeEndpunkt(location);
            if (m_hoehe < m_breite)
            {
                m_breite = m_hoehe;
            }
            else
            {
                m_hoehe = m_breite;
            }
            //m_hoehe = Math.Min(m_hoehe, m_breite);
            //m_breite = m_hoehe;

            if (m_Endpunkt.X < m_Startpunkt.X)
            {
                m_startX = m_Startpunkt.X - m_breite;
            }

            if (m_Endpunkt.Y < m_Startpunkt.Y)
            {
                m_startY = m_Startpunkt.Y - m_breite;
            }
        }
    }
    class cls_Haus : cls_Rechteck
    {
        GraphicsPath m_path = new GraphicsPath();
        Point[] m_punktliste = new Point[5];
        Matrix m_drehmatrix = new Matrix();
        public cls_Haus(Pen pen) : base(pen)
        {
            m_typ = Typ.Haus;
            for (int index = 0; index < m_punktliste.Length; index++)
                m_punktliste[index] = new Point();
        }
        public bool OriginalPosition(Point position)
        {
            if (m_path.IsVisible(position) || m_path.IsOutlineVisible(position, m_Farbe)) //Punkt liegt auf GraphicsPath
            {
                ResetHaus();
                return true;
            }
            return false;
        }
        public void Drehen(Point mittelpunkt)
        {
            m_drehmatrix.Reset();
            if (m_path.IsVisible(mittelpunkt) || m_path.IsOutlineVisible(mittelpunkt, m_Farbe))
            {
                m_drehmatrix.Translate(10, 10); //Translate = verschieben
                m_drehmatrix.RotateAt(-5.0f, mittelpunkt); //Drehung um 5 Grad nach links   RotateAt = drehen
                m_path.Transform(m_drehmatrix);
            }
            
        }
        public override void SetzeEndpunkt(Point location)
        {
            base.SetzeEndpunkt(location);
            ResetHaus();
        }

        private void ResetHaus()
        {
            //GraphicsPath neu zeichnen
            m_punktliste[0].X = m_startX;
            m_punktliste[0].Y = m_startY + m_hoehe;
            m_punktliste[1].X = m_startX;
            m_punktliste[1].Y = m_startY + m_hoehe / 3;
            m_punktliste[2].X = m_startX + m_breite / 2;
            m_punktliste[2].Y = m_startY;
            m_punktliste[3].X = m_startX + m_breite;
            m_punktliste[3].Y = m_punktliste[1].Y;
            m_punktliste[4].X = m_punktliste[3].X;
            m_punktliste[4].Y = m_punktliste[0].Y;
            m_path.Reset();
            m_path.AddPolygon(m_punktliste);
        }

        public override void Zeichne(Graphics graphics)
        {
            graphics.DrawPath(m_Farbe, m_path);
        }
    }
}

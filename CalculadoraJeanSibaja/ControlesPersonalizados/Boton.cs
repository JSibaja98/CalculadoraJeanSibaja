using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace CalculadoraJeanSibaja.ControlesPersonalizados
{
    public class Boton : Button
    {
        private int borderRadius = 40;
        private int borderSize = 0;
        private Color borderColor = Color.PaleVioletRed;

        public int BorderRadius { get => borderRadius; set { borderRadius = value; this.Invalidate(); } }

        public int BorderSize { get => borderSize; set { borderSize = value;this.Invalidate();} }

        public Boton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150,40);
            this.BackColor = Color.MediumBlue;
            this.ForeColor = Color.White;
        }

        private GraphicsPath getFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X,rect.Y,radius,radius,180,90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height-radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0,0,this.Width,this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width-0.8F, this.Height-1);

            using (GraphicsPath pathSurface = getFigurePath(rectSurface, BorderRadius))
            using (GraphicsPath pathBorder = getFigurePath(rectBorder, BorderRadius)) 
            using(Pen penSurface = new Pen(this.Parent.BackColor,2))
            using (Pen penBorder = new Pen(borderColor,BorderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                this.Region = new Region(pathSurface);
                pevent.Graphics.DrawPath(penSurface, pathSurface);
                if (BorderSize >= 1)
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChange);
        }

        private void Container_BackColorChange(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }
    }
}

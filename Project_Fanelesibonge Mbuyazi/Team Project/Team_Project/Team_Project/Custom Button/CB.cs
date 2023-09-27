using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Team_Project.Custom_Button
{
    class CB : Button // inhertis from predefined Button class
    {
        //Fields
        private int size_Border = 0;
        private int radius_Border = 20;
        private Color color_Border = Color.Peru;

        //Properties

        public int Size_Border
        {
            get { return size_Border; }
            set
            {
                size_Border = value;
                this.Invalidate();
            }
        }

        public int Radius_Border
        {
            get { return radius_Border; }
            set
            {
                radius_Border = value;
                this.Invalidate();
            }
        }

        public Color Color_Border
        {
            get { return color_Border; }
            set
            {
                color_Border = value;
                this.Invalidate();
            }
        }

        public Color Background_Color
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public Color Text_Color
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        #region constructors
        public CB()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);          // adding properties to the button
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.Black;
            this.Resize += new EventHandler(Button_Resize);
        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if (radius_Border > this.Height)
                radius_Border = this.Height;
        }
        #endregion

        #region methods 
        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        #endregion

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        #region Rounded_Button
        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();                        // Commands from Drawings2D library
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);      // AddArc function responsible for altering button dimensions and edge dimensions
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);    // Appends the line segment to the current GraphicsPath
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                             Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            using (GraphicsPath GraphPath = GetRoundPath(Rect, 50))
            {
                this.Region = new Region(GraphPath);
                using (Pen pen = new Pen(Color.CadetBlue, 1.75f))       // creating new instance of shape with desired dimensions that are customized utilizing the Pen class
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, GraphPath);
                }
            }
        }


        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSEFinalProject
{
    class Triangle
    {
        Point[] points;

        public Triangle (Point[] points)
        {
            this.points = points;
        }

        public void draw (Graphics g, Pen pen, bool fill)
        {
            if (fill)
            {
                SolidBrush brush = new SolidBrush(pen.Color);
                g.FillPolygon(brush, points);
            }
            else
            {
                g.DrawPolygon(pen, points);
            }
        }
    }
}

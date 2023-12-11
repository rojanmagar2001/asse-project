using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSEFinalProject
{
    /// <summary>
    /// Represents a circle shape to be drawn on a graphics surface.
    /// </summary>
    class Circle
    {
        int x, y;
        int radius;


        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class with specified center coordinates and radius.
        /// </summary>
        /// <param name="x">The x-coordinate of the center of the circle.</param>
        /// <param name="y">The y-coordinate of the center of the circle.</param>
        /// <param name="radius">The radius of the circle.</param>
        public Circle (int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        /// <summary>
        /// Draws the circle on the specified graphics surface using the provided pen and fill settings.
        /// </summary>
        /// <param name="g">The graphics object where the circle will be drawn.</param>
        /// <param name="pen">The pen used to draw the circle's outline.</param>
        /// <param name="fill">Determines whether the circle should be filled or drawn as an outline.</param>
        public void draw (Graphics g, Pen pen, bool fill)
        {
            if (fill)
            {
                SolidBrush brush = new SolidBrush(pen.Color);
                g.FillEllipse(brush, x, y, radius * 2, radius * 2);

            }
            else
            {
                g.DrawEllipse(pen, x, y, radius * 2, radius * 2);
            }
        }
    }
}

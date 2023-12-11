using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSEFinalProject
{
    /// <summary>
    /// Represents a rectangle shape to be drawn on a graphics surface.
    /// </summary>
    class Rectangle
    {
        int x, y;
        int width;
        int height;


        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class with specified top-left corner coordinates, width, and height.
        /// </summary>
        /// <param name="x">The x-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle (int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width; //the only thingthat is different from shape
            this.height = height;
        }

        /// <summary>
        /// Draws the rectangle on the specified graphics surface using the provided pen and fill settings.
        /// </summary>
        /// <param name="g">The graphics object where the rectangle will be drawn.</param>
        /// <param name="pen">The pen used to draw the rectangle's outline.</param>
        /// <param name="fill">Determines whether the rectangle should be filled or drawn as an outline.</param>
        public void draw (Graphics g, Pen pen, bool fill)
        {
            if (fill)
            {
                SolidBrush brush = new SolidBrush(pen.Color);
                g.FillRectangle(brush, x, y, width, height);
            }
            else
            {
                g.DrawRectangle(pen, x, y, width, height);
            }
        }
    }
}

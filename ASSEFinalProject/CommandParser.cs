using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASSEFinalProject
{
    class CommandParser
    {
        private int currentX; // Current X coordinate
        private int currentY; // Current Y coordinate
        private Panel panel;
        private Graphics g;
        private Pen pen;
        private DrawFill drawFill;

        /// <summary>
        /// Initializes a new instance of the CommandParser class with a specified panel and draw fill options.
        /// </summary>
        /// <param name="panel">The panel to draw on.</param>
        /// <param name="drawFill">The draw fill options.</param>
        public CommandParser (Panel panel, DrawFill drawFill)
        {
            this.panel = panel;
            g = panel.CreateGraphics();
            currentX = 0;
            currentY = 0;
            pen = new Pen(Color.Black, 2); // Create a black pen
            this.drawFill = drawFill;
            // Draw a new dot at the current pen position
            SolidBrush createBrush = new SolidBrush(pen.Color);
            g.FillEllipse(createBrush, currentX - 1, currentY - 1, 3, 3);
        }


        /// <summary>
        /// Parses the entered command and executes the corresponding action.
        /// </summary>
        /// <param name="command">The command string to be parsed and executed.</param>
        public void parseCommand (string command)
        {
            string cleanCommand = command.Trim();

            if (cleanCommand.Length == 0) throw new ArgumentException("Empty command.");


            // Logic to parse and execute individual commands
            string[] parts = cleanCommand.Split(' '); // Split command into parts

            string commandName = parts[0].ToLower(); // Get the command name (convert to lowercase for case insensitivity)

            string[] parameters = getParameters(parts);

            switch (commandName)
            {
                case "clear":
                    clear(parameters);
                    break;
                case "reset":
                    reset(parameters);
                    break;
                case "moveto":
                    moveTo(parameters);
                    break;
                case "drawto":
                    drawTo(parameters);
                    break;
                case "rectangle":
                    rectangle(parameters);
                    break;
                case "circle":
                    circle(parameters);
                    break;
                case "triangle":
                    triangle(parameters);
                    break;
                case "fill":
                    fillColor(parameters);
                    break;
                case "pen":
                    penColor(parameters);
                    break;
                default: 
                    throw new ArgumentException("Invalid Command");
            }
        }

        private string[] getParameters(string[] parts)
        {
            string[] rawParameters = parts.Length > 1 ? parts[1].Split(',') : Array.Empty<string>();


            string[] parameters = Array.Empty<string>();

            if (rawParameters.Length > 0)
            {
                parameters = parameters.Append(rawParameters[0]).ToArray();
            }

            if (parts.Length == 3)
            {
                parameters = parameters.Append(parts[2]).ToArray();
            }

            if (rawParameters.Length == 2)
            {
                parameters = parameters.Append(rawParameters[1]).ToArray();
            }

            parameters = parameters.Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)).ToArray();

            return parameters;
        }

        /// <summary>
        /// Executes the stored program.
        /// </summary>
        /// <param name="program">The program to execute.</param>
        public void runProgram (string program)
        {
            // Logic to execute a program
            foreach (string line in program.Split('\n', '\r'))
            {
                string cleanLine = line.Trim(); // Remove leading/trailing whitespaces

                if (!string.IsNullOrWhiteSpace(cleanLine)) // Skip empty lines
                {
                    parseCommand(line);
                }

            }

        }

        /// <summary>
        /// Checks the syntax of the provided command.
        /// </summary>
        /// <param name="command">The command string to check.</param>
        /// <returns>True if syntax is valid; otherwise, false.</returns>
        public void syntaxCheck (string program)
        {

            foreach (string line in program.Split('\n', '\r'))
            {
                string cleanLine = line.Trim(); 

                if (!string.IsNullOrWhiteSpace(cleanLine)) 
                {
                    string[] parts = cleanLine.Split(' '); 

                    string commandName = parts[0].ToLower();

           
                        string[] rawParameters = parts.Length > 1 ? parts[1].Split(',') : Array.Empty<string>();


                        string[] parameters = Array.Empty<string>();

                        if (rawParameters.Length > 0)
                        {
                            parameters = parameters.Append(rawParameters[0]).ToArray();
                        }

                        if (parts.Length == 3)
                        {
                            parameters = parameters.Append(parts[2]).ToArray();
                        }

                        if (rawParameters.Length == 2)
                        {
                            parameters = parameters.Append(rawParameters[1]).ToArray();
                        }

                        parameters = parameters.Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)).ToArray();

                        // Validate the command and its parameters
                        switch (commandName)
                        {
                            case "clear":
                                break;
                            case "reset":
                                break;
                            case "moveto":
                            case "drawto":
                                if (parameters.Length != 2)
                                {
                        
                                    throw new ArgumentException("Invalid numbers of parameters in 'moveto' or 'drawto' command");
                                }
                                if (!int.TryParse(parameters[0], out int x) || !int.TryParse(parameters[1], out int y))
                                {
                               
                                    throw new ArgumentException("Invalid parameters for 'moveto' or 'drawto' command");
                                }

                                if (x < 0 || y < 0)
                                {
                                    throw new ArgumentException("Negative parameters for 'moveTo' command.");
                                }

                                if (x > panel.Width)
                                {
                                    throw new ArgumentException("XPoint is greater than the width of the Panel!");
                                }

                                if (y > panel.Height)
                                {
                                    throw new ArgumentException("YPoint is greater than the width of the Panel!");
                                }
                                break;
                            case "rectangle":
                                if (parameters.Length != 2)
                                {
                                    throw new ArgumentException("Invalid number of parameters for 'rectangle' command.");
                                }

                                if (!int.TryParse(parameters[0], out int width) || !int.TryParse(parameters[1].Trim(), out int height))
                                {
                                    throw new ArgumentException("Invalid parameters for 'rectangle' command. Please provide valid integers. eg. rectangle 100, 200");
                                }

                                if (width <= 0 || height <= 0)
                                {
                                    throw new ArgumentException("Negative or Zero parameters for 'rectangle' command.");
                                }

                                if (currentX + width > panel.Width)
                                {
                                    throw new ArgumentException("Pen position and width is greater than the width of the Panel!");
                                }

                                if (currentY + width > panel.Height)
                                {
                                    throw new ArgumentException("Pen position and width is greater than the width of the Panel!");
                                }
                                break;
                            case "circle":
                                if (parameters.Length != 1)
                                {
                                    throw new ArgumentException("Invalid number of parameters for 'circle' command.");
                                }

                                if (!int.TryParse(parameters[0], out int radius))
                                {
                                    throw new ArgumentException("Invalid parameters for 'circle' command. Please provide valid integers. eg. circle 10");
                                }

                                if (radius <= 0)
                                {
                                    throw new ArgumentException("Negative or Zero parameters for 'circle' command.");
                                }
                                break;
                            case "triangle":
                                if (parameters.Length != 1)
                                {
                                    throw new ArgumentException("Invalid number of parameters for 'triangle' command.");
                                }

                                if (!int.TryParse(parameters[0], out int size))
                                {
                                    throw new ArgumentException("Invalid parameters for 'triangle' command. Please provide valid integers. eg. triangle 10");
                                }

                                if (size <= 0)
                                {
                                    throw new ArgumentException("Negative or Zero size for 'triangle' command.");
                                }

                                double Height = Math.Sqrt(3) / 2 * size; // Calculate the height of the equilateral triangle
                                double halfSide = size / 2.0; // Calculate half the side length

                                // Calculate the potential vertices of the triangle
                                Point topVertex = new Point(currentX, currentY - (int) Height); // Top vertex
                                Point bottomLeftVertex = new Point(currentX - (int) halfSide, currentY + (int) ( Height / 2 )); // Bottom left vertex
                                Point bottomRightVertex = new Point(currentX + (int) halfSide, currentY + (int) ( Height / 2 )); // Bottom right vertex

                                // Check if any of the triangle vertices exceed the panel bounds
                                if (!IsInsidePanel(topVertex) || !IsInsidePanel(bottomLeftVertex) || !IsInsidePanel(bottomRightVertex))
                                {
                                    throw new ArgumentException("Triangle exceeds panel bounds. Cannot be drawn.");
                                }
                                break;
                            case "pen":
                                if (parameters.Length != 1)
                                {
                                    throw new ArgumentException("Invalid number of parameters for 'pen' command.");
                                }

                                switch (parameters[0].ToLower())
                                {
                                    case "red":
                                        break;
                                    case "black":
                                        break;
                                    case "green":
                                        break;
                                    case "blue":
                                        break;
                                    case "yellow":
                                        break;
                                    default:
                                        throw new ArgumentException("Invalid color for the 'pen' command.");
                                }
                                break;
                            case "fill":
                                if (parameters.Length != 1)
                                {
                                    throw new ArgumentException("Invalid number of parameters for 'fill' command.");
                                }

                                switch (parameters[0].ToLower())
                                {
                                    case "on":
                                        drawFill.Fill = true;
                                        break;
                                    case "off":
                                        drawFill.Fill = false;
                                        break;
                                    default:
                                        throw new ArgumentException("Invalid parameter for 'fill' command.");
                                }
                                break;
                            default:
                                throw new ArgumentException("Invalid Command Sent");
                        }
                    
                }

            }
        }

        /// <summary>
        /// Saves the program to a text file.
        /// </summary>
        /// <param name="program">The program content to save.</param>
        public void saveProgram (string program)
        {
            SaveFileDialog dialogBox = new SaveFileDialog();
            dialogBox.Filter = "Text File|*.txt";
            dialogBox.Title = "Save a Text File";
            dialogBox.ShowDialog();

            if (dialogBox.FileName != "")
            {
                // Write the text content to the selected file.
                System.IO.File.WriteAllText(dialogBox.FileName, program);
            }
        }

        /// <summary>
        /// Loads a program from a text file.
        /// </summary>
        /// <returns>The loaded program content.</returns>
        public string loadProgram ()
        {
            OpenFileDialog dialogBox = new OpenFileDialog();
            dialogBox.Filter = "Text Files|*.txt";
            dialogBox.Title = "Select a Text File to Open";

            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = dialogBox.FileName;

                    // Read the contents of the selected file
                    string fileContent = System.IO.File.ReadAllText(filePath);

                   
                    return fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading the file: " + ex.Message);
                }
            }

            throw new Exception("Error while reading the file");
        }

        /// <summary>
        /// Moves the pen to a specified position.
        /// </summary>
        /// <param name="parameters">The coordinates for the new position.</param>
        private void moveTo (string[] parameters)
        {
            if (parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters for 'moveTo' command.");
            }

            if (!int.TryParse(parameters[0], out int x) || !int.TryParse(parameters[1].Trim(), out int y))
            {
                throw new ArgumentException("Invalid parameters for 'moveTo' command. Please provide valid integers.");
            }

            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Negative parameters for 'moveTo' command.");
            }

            if (x > panel.Width)
            {
                throw new ArgumentException("XPoint is greater than the width of the Panel!");
            }

            if (y > panel.Height)
            {
                throw new ArgumentException("YPoint is greater than the width of the Panel!");
            }

            // Clear the previous dot at the pen's previous position
            SolidBrush clearBrush = new SolidBrush(panel.BackColor);
            g.FillEllipse(clearBrush, currentX - 1, currentY - 1, 3, 3);

            currentX = x;
            currentY = y;

            // Draw a new dot at the current pen position
            SolidBrush createBrush = new SolidBrush(pen.Color);
            g.FillEllipse(createBrush, x - 1, y - 1, 3, 3);
        }

        /// <summary>
        /// Resets the current X and Y coordinates to 0.
        /// </summary>
        /// <param name="parameters">Not used in this method.</param>
        private void reset (string[] parameters)
        {
            // Clear the previous dot at the pen's previous position
            SolidBrush clearBrush = new SolidBrush(panel.BackColor);
            g.FillEllipse(clearBrush, currentX - 1, currentY - 1, 3, 3);

            currentX = 0;
            currentY = 0;

            // Draw a new dot at the current pen position
            SolidBrush createBrush = new SolidBrush(pen.Color);
            g.FillEllipse(createBrush, currentX - 1, currentY - 1, 3, 3);
        }

        /// <summary>
        /// Resets the current X and Y coordinates to 0.
        /// </summary>
        /// <param name="parameters">Not used in this method.</param>
        private void clear (string[] parameters)
        {
            g.Clear(panel.BackColor);
            currentX = 0;
            currentY = 0;
        }

        /// <summary>
        /// Draws a line from the current position to the specified coordinates (x, y).
        /// </summary>
        /// <param name="parameters">An array containing the X and Y coordinates.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when an invalid number of parameters or invalid coordinates are provided,
        /// or when the provided coordinates are out of the panel bounds.
        /// </exception>
        private void drawTo (string[] parameters)
        {
            if (parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters for 'drawTo' command.");
            }

            if (!int.TryParse(parameters[0], out int x) || !int.TryParse(parameters[1].Trim(), out int y))
            {
                throw new ArgumentException("Invalid parameters for 'drawTo' command. Please provide valid integers.");
            }

            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Negative parameters for 'drawTo' command.");
            }

            if (x > panel.Width)
            {
                throw new ArgumentException("XPoint is greater than the width of the Panel!");
            }

            if (y > panel.Height)
            {
                throw new ArgumentException("YPoint is greater than the width of the Panel!");
            }

            // Clear the previous dot at the pen's previous position
            SolidBrush clearBrush = new SolidBrush(panel.BackColor);
            g.FillEllipse(clearBrush, currentX - 1, currentY - 1, 3, 3);


            // Draw a line from current coordinates to the new coordinates (x, y)
            g.DrawLine(pen, currentX, currentY, x, y);

            // Draw a new dot at the current pen position
            SolidBrush createBrush = new SolidBrush(pen.Color);
            g.FillEllipse(createBrush, x - 1, y - 1, 3, 3);


            // Update current coordinates to the new position
            currentX = x;
            currentY = y;
        }

        /// <summary>
        /// Draws a rectangle with the provided width and height at the current position.
        /// </summary>
        /// <param name="parameters">An array containing the width and height of the rectangle.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when an invalid number of parameters or invalid width/height values are provided,
        /// or when the rectangle exceeds the panel bounds.
        /// </exception>
        private void rectangle (string[] parameters)
        {
            if (parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters for 'rectangle' command.");
            }

            if (!int.TryParse(parameters[0], out int width) || !int.TryParse(parameters[1].Trim(), out int height))
            {
                throw new ArgumentException("Invalid parameters for 'rectangle' command. Please provide valid integers. eg. rectangle 100, 200");
            }

            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Negative or Zero parameters for 'rectangle' command.");
            }

            if (currentX + width > panel.Width)
            {
                throw new ArgumentException("Pen position and width is greater than the width of the Panel!");
            }

            if (currentY + width > panel.Height)
            {
                throw new ArgumentException("Pen position and width is greater than the width of the Panel!");
            }

            Rectangle rect = new Rectangle(currentX, currentY, width, height);
            rect.draw(g, pen, drawFill.Fill);
        }

        /// <summary>
        /// Draws a circle with the provided radius at the current position.
        /// </summary>
        /// <param name="parameters">An array containing the radius of the circle.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when an invalid number of parameters or invalid radius value is provided.
        /// </exception>
        private void circle (string[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new ArgumentException("Invalid number of parameters for 'circle' command.");
            }

            if (!int.TryParse(parameters[0], out int radius))
            {
                throw new ArgumentException("Invalid parameters for 'circle' command. Please provide valid integers. eg. circle 10");
            }

            if (radius <= 0)
            {
                throw new ArgumentException("Negative or Zero parameters for 'circle' command.");
            }

            Circle circ = new Circle(currentX, currentY, radius);
            circ.draw(g, pen, drawFill.Fill);
        }

        /// <summary>
        /// Draws an equilateral triangle with the provided side size at the current position.
        /// </summary>
        /// <param name="parameters">An array containing the side size of the equilateral triangle.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when an invalid number of parameters or invalid size value is provided,
        /// or when the triangle exceeds the panel bounds.
        /// </exception>
        private void triangle (string[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new ArgumentException("Invalid number of parameters for 'triangle' command.");
            }

            if (!int.TryParse(parameters[0], out int size))
            {
                throw new ArgumentException("Invalid parameters for 'triangle' command. Please provide valid integers. eg. triangle 10");
            }

            if (size <= 0)
            {
                throw new ArgumentException("Negative or Zero size for 'triangle' command.");
            }

            double height = Math.Sqrt(3) / 2 * size; // Calculate the height of the equilateral triangle
            double halfSide = size / 2.0; // Calculate half the side length

            // Calculate the potential vertices of the triangle
            Point topVertex = new Point(currentX, currentY - (int) height); // Top vertex
            Point bottomLeftVertex = new Point(currentX - (int) halfSide, currentY + (int) ( height / 2 )); // Bottom left vertex
            Point bottomRightVertex = new Point(currentX + (int) halfSide, currentY + (int) ( height / 2 )); // Bottom right vertex

            // Check if any of the triangle vertices exceed the panel bounds
            if (!IsInsidePanel(topVertex) || !IsInsidePanel(bottomLeftVertex) || !IsInsidePanel(bottomRightVertex))
            {
                throw new ArgumentException("Triangle exceeds panel bounds. Cannot be drawn.");
            }

            // Draw the equilateral triangle using the calculated coordinates
            Point[] trianglePoints = { topVertex, bottomLeftVertex, bottomRightVertex };


            Triangle tri = new Triangle(trianglePoints);
            tri.draw(g, pen, drawFill.Fill);
        }

        /// <summary>
        /// Checks if a given point lies inside the panel bounds.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>True if the point is inside the panel bounds; otherwise, false.</returns>
        private bool IsInsidePanel (Point point)
        {
            return point.X >= 0 && point.Y >= 0 && point.X <= panel.Width && point.Y <= panel.Height;
        }

        /// <summary>
        /// Sets the pen color based on the provided color name.
        /// </summary>
        /// <param name="parameters">An array containing the color name.</param>
        /// <exception cref="ArgumentException">Thrown when an invalid number of parameters or an unrecognized color is provided.</exception>
        private void penColor (string[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new ArgumentException("Invalid number of parameters for 'pen' command.");
            }

            switch (parameters[0].ToLower())
            {
                case "red":
                    pen.Color = Color.Red;
                    break;
                case "black":
                    pen.Color = Color.Black;
                    break;
                case "green":
                    pen.Color = Color.Green;
                    break;
                case "blue":
                    pen.Color = Color.Blue;
                    break;
                case "yellow":
                    pen.Color = Color.Yellow;
                    break;
                default:
                    throw new ArgumentException("Invalid color for the 'pen' command.");
            }
        }

        /// <summary>
        /// Sets the fill option for drawing shapes.
        /// </summary>
        /// <param name="parameters">An array containing the fill option (on/off).</param>
        /// <exception cref="ArgumentException">Thrown when an invalid number of parameters or an unrecognized fill option is provided.</exception>
        private void fillColor (string[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new ArgumentException("Invalid number of parameters for 'fill' command.");
            }

            switch (parameters[0].ToLower())
            {
                case "on":
                    drawFill.Fill = true;
                    break;
                case "off":
                    drawFill.Fill = false;
                    break;
                default:
                    throw new ArgumentException("Invalid parameter for 'fill' command.");
            }
        }
    }

    
}

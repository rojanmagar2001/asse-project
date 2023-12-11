using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASSEFinalProject
{
    public partial class Form1 : Form
    {
        private CommandParser commandParser;
        private DrawFill fill;
        public Form1 ()
        {
            InitializeComponent();
            fill = new DrawFill();
            commandParser = new CommandParser(PaintPanel, fill);

        }

        private void panel1_Paint (object sender, PaintEventArgs e)
        {

        }

        private void saveButton_Click (object sender, EventArgs e)
        {
            string program = MultipleLineTextBox.Text;
            commandParser.saveProgram(program);
        }

        private void loadButton_Click (object sender, EventArgs e)
        {
            try
            {
                string program = commandParser.loadProgram();
                MultipleLineTextBox.Text = program;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void runProgramButton_Click (object sender, EventArgs e)
        {
            string program = MultipleLineTextBox.Text;
            try
            {
                commandParser.runProgram(program);

                MessageBox.Show("Program ran successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Event handler for the run button click.
        /// Executes the program with parsed commands.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void checkSyntaxButton_Click (object sender, EventArgs e)
        {
            string program = MultipleLineTextBox.Text;
            try
            {
                commandParser.syntaxCheck(program);

                MessageBox.Show("Syntax is correct. You can run now!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Event handler for the command text box key down event.
        /// Parses the command when the enter key is pressed.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The key event arguments.</param>
        private void SingleLineTextBox_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string command = SingleLineTextBox.Text;

                    commandParser.parseCommand(command);

                    SingleLineTextBox.Text = "";
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

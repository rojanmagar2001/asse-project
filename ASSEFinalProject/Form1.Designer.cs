namespace ASSEFinalProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.PaintPanel = new System.Windows.Forms.Panel();
            this.SingleLineTextBox = new System.Windows.Forms.TextBox();
            this.MultipleLineTextBox = new System.Windows.Forms.RichTextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.checkSyntaxButton = new System.Windows.Forms.Button();
            this.runProgramButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PaintPanel
            // 
            this.PaintPanel.BackColor = System.Drawing.SystemColors.Info;
            this.PaintPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PaintPanel.Location = new System.Drawing.Point(12, 12);
            this.PaintPanel.Name = "PaintPanel";
            this.PaintPanel.Size = new System.Drawing.Size(399, 351);
            this.PaintPanel.TabIndex = 0;
            this.PaintPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SingleLineTextBox
            // 
            this.SingleLineTextBox.Location = new System.Drawing.Point(435, 317);
            this.SingleLineTextBox.Name = "SingleLineTextBox";
            this.SingleLineTextBox.Size = new System.Drawing.Size(340, 20);
            this.SingleLineTextBox.TabIndex = 1;
            this.SingleLineTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SingleLineTextBox_KeyDown);
            // 
            // MultipleLineTextBox
            // 
            this.MultipleLineTextBox.Location = new System.Drawing.Point(435, 12);
            this.MultipleLineTextBox.Name = "MultipleLineTextBox";
            this.MultipleLineTextBox.Size = new System.Drawing.Size(340, 252);
            this.MultipleLineTextBox.TabIndex = 2;
            this.MultipleLineTextBox.Text = "";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(435, 270);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(516, 270);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // checkSyntaxButton
            // 
            this.checkSyntaxButton.Location = new System.Drawing.Point(700, 270);
            this.checkSyntaxButton.Name = "checkSyntaxButton";
            this.checkSyntaxButton.Size = new System.Drawing.Size(75, 23);
            this.checkSyntaxButton.TabIndex = 5;
            this.checkSyntaxButton.Text = "Syntax";
            this.checkSyntaxButton.UseVisualStyleBackColor = true;
            this.checkSyntaxButton.Click += new System.EventHandler(this.checkSyntaxButton_Click);
            // 
            // runProgramButton
            // 
            this.runProgramButton.Location = new System.Drawing.Point(619, 270);
            this.runProgramButton.Name = "runProgramButton";
            this.runProgramButton.Size = new System.Drawing.Size(75, 23);
            this.runProgramButton.TabIndex = 6;
            this.runProgramButton.Text = "Run";
            this.runProgramButton.UseVisualStyleBackColor = true;
            this.runProgramButton.Click += new System.EventHandler(this.runProgramButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.runProgramButton);
            this.Controls.Add(this.checkSyntaxButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.MultipleLineTextBox);
            this.Controls.Add(this.SingleLineTextBox);
            this.Controls.Add(this.PaintPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PaintPanel;
        private System.Windows.Forms.TextBox SingleLineTextBox;
        private System.Windows.Forms.RichTextBox MultipleLineTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button checkSyntaxButton;
        private System.Windows.Forms.Button runProgramButton;
    }
}


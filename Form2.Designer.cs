
namespace ProjektOkienkowy
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
        private void InitializeComponent()
        {
            this.Clear = new System.Windows.Forms.Button();
            this.Complex = new System.Windows.Forms.Button();
            this.whiteboard = new System.Windows.Forms.PictureBox();
            this.Parallelogram = new System.Windows.Forms.Button();
            this.Triangle = new System.Windows.Forms.Button();
            this.Circle = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.whiteboard)).BeginInit();
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(862, 232);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(127, 34);
            this.Clear.TabIndex = 13;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            // 
            // Complex
            // 
            this.Complex.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Complex.Location = new System.Drawing.Point(895, 168);
            this.Complex.Name = "Complex";
            this.Complex.Size = new System.Drawing.Size(127, 48);
            this.Complex.TabIndex = 12;
            this.Complex.Text = "Complex_Shape";
            this.Complex.UseVisualStyleBackColor = false;
            // 
            // whiteboard
            // 
            this.whiteboard.BackColor = System.Drawing.Color.White;
            this.whiteboard.Location = new System.Drawing.Point(82, 22);
            this.whiteboard.Name = "whiteboard";
            this.whiteboard.Size = new System.Drawing.Size(718, 558);
            this.whiteboard.TabIndex = 11;
            this.whiteboard.TabStop = false;
            // 
            // Parallelogram
            // 
            this.Parallelogram.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Parallelogram.Location = new System.Drawing.Point(895, 113);
            this.Parallelogram.Name = "Parallelogram";
            this.Parallelogram.Size = new System.Drawing.Size(127, 49);
            this.Parallelogram.TabIndex = 10;
            this.Parallelogram.Text = "Parallelogram";
            this.Parallelogram.UseVisualStyleBackColor = false;
            // 
            // Triangle
            // 
            this.Triangle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Triangle.Location = new System.Drawing.Point(895, 69);
            this.Triangle.Name = "Triangle";
            this.Triangle.Size = new System.Drawing.Size(127, 38);
            this.Triangle.TabIndex = 9;
            this.Triangle.Text = "Triangle";
            this.Triangle.UseVisualStyleBackColor = false;
            // 
            // Circle
            // 
            this.Circle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Circle.Location = new System.Drawing.Point(895, 22);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(127, 41);
            this.Circle.TabIndex = 8;
            this.Circle.Text = "Circle";
            this.Circle.UseVisualStyleBackColor = false;
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(12, 12);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(54, 51);
            this.Back.TabIndex = 14;
            this.Back.Text = "button1";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.back_button_click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1020, 582);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Complex);
            this.Controls.Add(this.whiteboard);
            this.Controls.Add(this.Parallelogram);
            this.Controls.Add(this.Triangle);
            this.Controls.Add(this.Circle);
            this.Location = new System.Drawing.Point(-50, -50);
            this.MaximumSize = new System.Drawing.Size(1038, 629);
            this.MinimumSize = new System.Drawing.Size(1038, 629);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.whiteboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Complex;
        private System.Windows.Forms.PictureBox whiteboard;
        private System.Windows.Forms.Button Parallelogram;
        private System.Windows.Forms.Button Triangle;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.Button Back;
    }
}
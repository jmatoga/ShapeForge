
namespace ProjektOkienkowy
{
    partial class Complex_Shape
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
            this.whiteboard = new System.Windows.Forms.PictureBox();
            this.Parallelogram = new System.Windows.Forms.Button();
            this.Triangle = new System.Windows.Forms.Button();
            this.Circle = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.LabelOfLeftFigures = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.whiteboard)).BeginInit();
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Clear.Location = new System.Drawing.Point(779, 202);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(184, 40);
            this.Clear.TabIndex = 13;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // whiteboard
            // 
            this.whiteboard.BackColor = System.Drawing.Color.White;
            this.whiteboard.Location = new System.Drawing.Point(24, 12);
            this.whiteboard.Name = "whiteboard";
            this.whiteboard.Size = new System.Drawing.Size(700, 555);
            this.whiteboard.TabIndex = 11;
            this.whiteboard.TabStop = false;
            // 
            // Parallelogram
            // 
            this.Parallelogram.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Parallelogram.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Parallelogram.Location = new System.Drawing.Point(779, 135);
            this.Parallelogram.Name = "Parallelogram";
            this.Parallelogram.Size = new System.Drawing.Size(184, 51);
            this.Parallelogram.TabIndex = 10;
            this.Parallelogram.Text = "Parallelogram";
            this.Parallelogram.UseVisualStyleBackColor = false;
            this.Parallelogram.Click += new System.EventHandler(this.Parallelogram_Click);
            // 
            // Triangle
            // 
            this.Triangle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Triangle.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Triangle.Location = new System.Drawing.Point(779, 78);
            this.Triangle.Name = "Triangle";
            this.Triangle.Size = new System.Drawing.Size(184, 51);
            this.Triangle.TabIndex = 9;
            this.Triangle.Text = "Triangle";
            this.Triangle.UseVisualStyleBackColor = false;
            this.Triangle.Click += new System.EventHandler(this.Triangle_Click);
            // 
            // Circle
            // 
            this.Circle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Circle.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Circle.Location = new System.Drawing.Point(779, 21);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(184, 51);
            this.Circle.TabIndex = 8;
            this.Circle.Text = "Circle";
            this.Circle.UseVisualStyleBackColor = false;
            this.Circle.Click += new System.EventHandler(this.Circle_Click);
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Back.Location = new System.Drawing.Point(779, 516);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(184, 51);
            this.Back.TabIndex = 14;
            this.Back.Text = "Back to Simple Shape";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.back_button_click);
            // 
            // LabelOfLeftFigures
            // 
            this.LabelOfLeftFigures.AutoSize = true;
            this.LabelOfLeftFigures.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelOfLeftFigures.Location = new System.Drawing.Point(774, 268);
            this.LabelOfLeftFigures.Name = "LabelOfLeftFigures";
            this.LabelOfLeftFigures.Size = new System.Drawing.Size(181, 30);
            this.LabelOfLeftFigures.TabIndex = 15;
            this.LabelOfLeftFigures.Text = "Figures left:   5";
            // 
            // Complex_Shape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1020, 582);
            this.Controls.Add(this.LabelOfLeftFigures);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.whiteboard);
            this.Controls.Add(this.Parallelogram);
            this.Controls.Add(this.Triangle);
            this.Controls.Add(this.Circle);
            this.Location = new System.Drawing.Point(-50, -50);
            this.MaximumSize = new System.Drawing.Size(1038, 629);
            this.MinimumSize = new System.Drawing.Size(1038, 629);
            this.Name = "Complex_Shape";
            this.Text = "Complex Shape";
            ((System.ComponentModel.ISupportInitialize)(this.whiteboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.PictureBox whiteboard;
        private System.Windows.Forms.Button Parallelogram;
        private System.Windows.Forms.Button Triangle;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label LabelOfLeftFigures;
    }
}

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
            this.read = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.whiteboard)).BeginInit();
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Clear.Location = new System.Drawing.Point(779, 192);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(184, 40);
            this.Clear.TabIndex = 13;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
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
            // 
            // read
            // 
            this.read.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.read.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.read.Location = new System.Drawing.Point(779, 21);
            this.read.Name = "read";
            this.read.Size = new System.Drawing.Size(184, 51);
            this.read.TabIndex = 8;
            this.read.Text = "Circle";
            this.read.UseVisualStyleBackColor = false;
            this.read.Click += new System.EventHandler(this.read_Click);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(779, 373);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 22);
            this.textBox1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(807, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 60);
            this.label1.TabIndex = 16;
            this.label1.Text = "Enter how many\r\nfigures you want \r\nto draw:\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Complex_Shape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1020, 582);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.whiteboard);
            this.Controls.Add(this.Parallelogram);
            this.Controls.Add(this.Triangle);
            this.Controls.Add(this.read);
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
        private System.Windows.Forms.Button read;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}
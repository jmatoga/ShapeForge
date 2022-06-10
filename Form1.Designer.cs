
namespace ProjektOkienkowy
{
    partial class Simple_Shape
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Circle = new System.Windows.Forms.Button();
            this.Triangle = new System.Windows.Forms.Button();
            this.Parallelogram = new System.Windows.Forms.Button();
            this.whiteboard = new System.Windows.Forms.PictureBox();
            this.Complex = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.whiteboard)).BeginInit();
            this.SuspendLayout();
            // 
            // Circle
            // 
            this.Circle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Circle.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Circle.Location = new System.Drawing.Point(779, 26);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(184, 51);
            this.Circle.TabIndex = 0;
            this.Circle.Text = "Circle";
            this.Circle.UseVisualStyleBackColor = false;
            this.Circle.Click += new System.EventHandler(this.Circle_click);
            // 
            // Triangle
            // 
            this.Triangle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Triangle.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Triangle.Location = new System.Drawing.Point(779, 78);
            this.Triangle.Name = "Triangle";
            this.Triangle.Size = new System.Drawing.Size(184, 51);
            this.Triangle.TabIndex = 2;
            this.Triangle.Text = "Triangle";
            this.Triangle.UseVisualStyleBackColor = false;
            this.Triangle.Click += new System.EventHandler(this.Triangle_Click);
            // 
            // Parallelogram
            // 
            this.Parallelogram.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Parallelogram.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Parallelogram.Location = new System.Drawing.Point(779, 135);
            this.Parallelogram.Name = "Parallelogram";
            this.Parallelogram.Size = new System.Drawing.Size(184, 51);
            this.Parallelogram.TabIndex = 3;
            this.Parallelogram.Text = "Parallelogram";
            this.Parallelogram.UseVisualStyleBackColor = false;
            this.Parallelogram.Click += new System.EventHandler(this.Parallelogram_Click);
            // 
            // whiteboard
            // 
            this.whiteboard.BackColor = System.Drawing.Color.White;
            this.whiteboard.Location = new System.Drawing.Point(24, 12);
            this.whiteboard.Name = "whiteboard";
            this.whiteboard.Size = new System.Drawing.Size(700, 555);
            this.whiteboard.TabIndex = 5;
            this.whiteboard.TabStop = false;
            this.whiteboard.Click += new System.EventHandler(this.whiteboard_Click);
            // 
            // Complex
            // 
            this.Complex.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Complex.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Complex.Location = new System.Drawing.Point(779, 190);
            this.Complex.Name = "Complex";
            this.Complex.Size = new System.Drawing.Size(184, 51);
            this.Complex.TabIndex = 6;
            this.Complex.Text = "Complex_Shape";
            this.Complex.UseVisualStyleBackColor = false;
            this.Complex.Click += new System.EventHandler(this.Complex_Click);
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Clear.Location = new System.Drawing.Point(779, 261);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(184, 40);
            this.Clear.TabIndex = 7;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Simple_Shape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1020, 582);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Complex);
            this.Controls.Add(this.whiteboard);
            this.Controls.Add(this.Parallelogram);
            this.Controls.Add(this.Triangle);
            this.Controls.Add(this.Circle);
            this.Location = new System.Drawing.Point(50, 50);
            this.MaximumSize = new System.Drawing.Size(1038, 629);
            this.MinimumSize = new System.Drawing.Size(1038, 629);
            this.Name = "Simple_Shape";
            this.Text = "Simple Shape";
            ((System.ComponentModel.ISupportInitialize)(this.whiteboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.Button Triangle;
        private System.Windows.Forms.Button Parallelogram;
        private System.Windows.Forms.PictureBox whiteboard;
        private System.Windows.Forms.Button Complex;
        private System.Windows.Forms.Button Clear;
    }
}


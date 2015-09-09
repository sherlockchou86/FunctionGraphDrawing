namespace FunctionGraphDrawing
{
    partial class MainForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.unaryFunctionDrawingBoard1 = new FunctionGraphDrawing.DrawingControls.UnaryFunctionDrawingBoard();
            this.binaryFunctionDrawingBoard1 = new FunctionGraphDrawing.DrawingControls.BinaryFunctionDrawingBoard();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.binaryFunctionDrawingBoard1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(891, 593);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "二元函数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.unaryFunctionDrawingBoard1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(891, 593);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "一元函数";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(899, 619);
            this.tabControl1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(895, 33);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(832, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // unaryFunctionDrawingBoard1
            // 
            this.unaryFunctionDrawingBoard1.BackColor = System.Drawing.Color.White;
            this.unaryFunctionDrawingBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unaryFunctionDrawingBoard1.Function = null;
            this.unaryFunctionDrawingBoard1.Location = new System.Drawing.Point(3, 3);
            this.unaryFunctionDrawingBoard1.Name = "unaryFunctionDrawingBoard1";
            this.unaryFunctionDrawingBoard1.Size = new System.Drawing.Size(885, 587);
            this.unaryFunctionDrawingBoard1.TabIndex = 0;
            // 
            // binaryFunctionDrawingBoard1
            // 
            this.binaryFunctionDrawingBoard1.AngleX = 0D;
            this.binaryFunctionDrawingBoard1.AngleY = 30D;
            this.binaryFunctionDrawingBoard1.AngleZ = -30D;
            this.binaryFunctionDrawingBoard1.Azimuth = 0D;
            this.binaryFunctionDrawingBoard1.BackColor = System.Drawing.Color.Black;
            this.binaryFunctionDrawingBoard1.BinaryFunction = null;
            this.binaryFunctionDrawingBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binaryFunctionDrawingBoard1.Elevation = 0D;
            this.binaryFunctionDrawingBoard1.Location = new System.Drawing.Point(3, 3);
            this.binaryFunctionDrawingBoard1.Name = "binaryFunctionDrawingBoard1";
            this.binaryFunctionDrawingBoard1.Size = new System.Drawing.Size(885, 587);
            this.binaryFunctionDrawingBoard1.TabIndex = 0;
            this.binaryFunctionDrawingBoard1.VSync = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 723);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "FunctionGraphDrawing";
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private DrawingControls.UnaryFunctionDrawingBoard unaryFunctionDrawingBoard1;
        private DrawingControls.BinaryFunctionDrawingBoard binaryFunctionDrawingBoard1;

    }
}


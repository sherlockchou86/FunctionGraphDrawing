using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FunctionGraphDrawing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (frmAddFunction frmaddf = new frmAddFunction())
            {
                frmaddf.Function = textBox1.Text;
                if (frmaddf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Text = frmaddf.Function;
                    //一元
                    if (textBox1.Text.ToLower().Contains('x') && !textBox1.Text.ToLower().Contains('y') && !textBox1.Text.ToLower().Contains('z'))
                    {
                        UnaryFunction func = (new SyntaxManager().ParseUnaryFunction(textBox1.Text));
                        unaryFunctionDrawingBoard1.Function = func;
                        tabControl1.SelectedIndex = 0;
                    }
                    //二元
                    else if (textBox1.Text.ToLower().Contains('x') && textBox1.Text.ToLower().Contains('y') && !textBox1.Text.ToLower().Contains('z'))
                    {
                        BinaryFunction func = (new SyntaxManager().ParseBinaryFunction(textBox1.Text));
                        binaryFunctionDrawingBoard1.BinaryFunction = func;
                        tabControl1.SelectedIndex = 1;
                    }
                    //三元
                    else
                    {
                        MultiFunction func = (new SyntaxManager().ParseMultiFunction(textBox1.Text));
                        MessageBox.Show("三元函数图像无法绘制！");
                    }
                }
            }
        }
    }
}

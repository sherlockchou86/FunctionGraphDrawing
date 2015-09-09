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
    /// <summary>
    /// 函数编辑
    /// </summary>
    public partial class frmAddFunction : Form
    {
        /// <summary>
        /// 编辑的函数表达式
        /// </summary>
        public string Function
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
        public frmAddFunction()
        {
            InitializeComponent();
        }

        private void frmAddFunction_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button31_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button32_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = (sender as Button).Text;
        }
    }
}

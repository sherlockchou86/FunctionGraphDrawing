using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FunctionGraphDrawing.DrawingControls
{
    /// <summary>
    /// 一元函数图像绘制控件
    /// </summary>
    public partial class UnaryFunctionDrawingBoard : UserControl
    {
        private UnaryFunction _function;
        public UnaryFunction Function
        {
            get
            {
                return _function;
            }
            set
            {
                if (_function != value)
                {
                    _function = value;
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public UnaryFunctionDrawingBoard()
        {
            InitializeComponent();
            BackColor = Color.White;
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            List<PointF> points = new List<PointF>();
            int x_range = 10;
            if (_function != null)
            {
                for (double x = (-1) * x_range; x <= x_range; x = x + 0.1d)
                {
                    if (Math.Abs(x) < 0.1d)
                    {
                        x = 0d;
                    }
                    points.Add(new PointF((float)x, (float)_function(x)));
                }

                float y_range = 10;

                float scale_y = (float)(Height) / (2 * y_range);  //Y轴比例

                float scale_x = (float)Width / x_range / 2; //X轴比例
                using (Pen p = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawLine(p, new Point(0, Height / 2), new Point(Width, Height / 2));  //X轴
                    e.Graphics.DrawLine(p, new Point(Width / 2, 0), new Point(Width / 2, Height));   //Y轴 

                    e.Graphics.DrawString(((-1) * x_range).ToString(), new Font("微软雅黑", 9), Brushes.Black, new PointF(0, Height / 2));
                    e.Graphics.FillRectangle(Brushes.Black, new RectangleF(-2, Height / 2 - 2, 4, 4));
                    e.Graphics.DrawString(((-1) * x_range / 2).ToString(), new Font("微软雅黑", 9), Brushes.Black, new PointF(scale_x * x_range / 2, Height / 2));
                    e.Graphics.FillRectangle(Brushes.Black, new RectangleF(scale_x * x_range / 2 - 2, Height / 2 - 2, 4, 4));
                    e.Graphics.DrawString((x_range / 2).ToString(), new Font("微软雅黑", 9), Brushes.Black, new PointF(scale_x * x_range * 3 / 2, Height / 2));
                    e.Graphics.FillRectangle(Brushes.Black, new RectangleF(scale_x * x_range * 3 / 2 - 2, Height / 2 - 2, 4, 4));
                    e.Graphics.DrawString(x_range.ToString(), new Font("微软雅黑", 9), Brushes.Black, new PointF(Width - 16, Height / 2));
                    e.Graphics.FillRectangle(Brushes.Black, new Rectangle(Width - 2, Height / 2 - 2, 4, 4));

                    e.Graphics.DrawString(y_range.ToString(), new Font("微软雅黑", 9), Brushes.Black, new PointF(Width / 2, 0));
                    e.Graphics.FillRectangle(Brushes.Black, new RectangleF(Width / 2 - 2, -2, 4, 4));
                    e.Graphics.DrawString((y_range / 2).ToString(), new Font("微软雅黑", 9), Brushes.Black, new PointF(Width / 2, scale_y * y_range / 2));
                    e.Graphics.FillRectangle(Brushes.Black, new RectangleF(Width / 2 - 2, scale_y * y_range / 2 - 2, 4, 4));
                    e.Graphics.DrawString(((-1) * y_range / 2).ToString(), new Font("微软雅黑", 9), Brushes.Black, new PointF(Width / 2, scale_y * y_range * 3 / 2));
                    e.Graphics.FillRectangle(Brushes.Black, new RectangleF(Width / 2 - 2, scale_y * y_range * 3 / 2 - 2, 4, 4));
                    e.Graphics.DrawString(((-1) * y_range).ToString(), new Font("微软雅黑", 9), Brushes.Black, new PointF(Width / 2, Height - 16));
                    e.Graphics.FillRectangle(Brushes.Black, new Rectangle(Width / 2 - 2, Height - 2, 4, 4));
                }
                using (Pen p = new Pen(Color.Teal, 2))
                {
                    e.Graphics.DrawLines(p, points.Select(point => new PointF(point.X * scale_x + Width/2, Height - (point.Y * scale_y + Height/2))).ToArray());
                }
            }
        }
    }
}

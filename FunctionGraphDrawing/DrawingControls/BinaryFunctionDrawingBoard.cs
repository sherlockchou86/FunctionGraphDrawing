using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;

namespace FunctionGraphDrawing.DrawingControls
{
	public partial class BinaryFunctionDrawingBoard : GLControl
	{
        private BinaryFunction _binaryFunction;
        public BinaryFunction BinaryFunction
        {
            get
            {
                return _binaryFunction;
            }
            set
            {
                _binaryFunction = value;
                if (_binaryFunction != null)
                {
                    Invalidate();
                }
            }
        }
		bool _loaded = false;
		double _azi, _ele;
		double _angleX, _angleY, _angleZ;

		// 旋转角度
		float theta = 0.0f;

		// 旋转轴
		float[] axis = { 1.0f, 0.0f, 0.0f };

		// 鼠标上次和当前坐标（映射到单位半球面）
		float[] lastPos = { 0.0f, 0.0f, 0.0f };
		float[] curPos = { 0.0f, 0.0f, 0.0f };

		// 上一次转换矩阵
		float[] lastMatrix =
		{
			1.0f, 0.0f, 0.0f, 0.0f,
			0.0f, 1.0f, 0.0f, 0.0f,
			0.0f, 0.0f, 1.0f, 0.0f,
			0.0f, 0.0f, 0.0f, 1.0f
		};

		public double Azimuth
		{
			get
			{
				return _azi;
			}
			set
			{
				_azi = value;
				if (_loaded)
					DrawAll();
			}
		}

		public double Elevation
		{
			get
			{
				return _ele;
			}
			set
			{
				_ele = value;
				if (_loaded)
					DrawAll();
			}
		}

		public double AngleX
		{
			get
			{
				return _angleX;
			}
			set
			{
				_angleX = value;
				if (_loaded)
					DrawAll();
			}
		}

		public double AngleY
		{
			get
			{
				return _angleY;
			}
			set
			{
				_angleY = value;
				if (_loaded)
					DrawAll();
			}
		}

		public double AngleZ
		{
			get
			{
				return _angleZ;
			}
			set
			{
				_angleZ = value;
				if (_loaded)
					DrawAll();
			}
		}

        public BinaryFunctionDrawingBoard()
		{
			InitializeComponent();

			AngleY = 30;
			AngleZ = -30;
		}

		private void Axles3D_Resize(object sender, EventArgs e)
		{
			if (_loaded)
			{
				DrawAll();
			}
		}

		private void Axles3D_Paint(object sender, PaintEventArgs e)
		{
			if (_loaded)
			{
				DrawAll();
			}
		}

		private void DrawAll()
		{
			//SETGL
			GL.Enable(EnableCap.Blend);
			GL.Enable(EnableCap.DepthTest);
			GL.ShadeModel(ShadingModel.Smooth);
			GL.ClearColor(Color.Black);
			GL.ClearColor(1.0f, 1.0f, 0.5f, 0.7f);
			GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
			//SETVIEW
			GL.Viewport(0, 0, this.Bounds.Width, this.Bounds.Height);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			Glu.Perspective(45.0f, (float)this.Bounds.Width / (float)this.Bounds.Height, 1.0, 10.0);
			Glu.LookAt(0.0, 0.0, 4.0, 0.0, 0.0, 3.0, 0.0, 1.0, 0.0);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();

			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			// 计算新的旋转矩阵，即：M = E · R = R
			GL.Rotate(theta, axis[0], axis[1], axis[2]);
			// 左乘上前一次的矩阵，即：M = R · L
			GL.MultMatrix(lastMatrix);
			// 保存此次处理结果，即：L = M
			GL.GetFloat(GetPName.ModelviewMatrix, lastMatrix);
			theta = 0.0f;

			// 画坐标轴
			DrawOLineInGL(0, 0, 1.5f, 2.0f, Color.Red, true);
			DrawOLineInGL(Math.PI, 0, 1.5f, 2.0f, Color.Red, false);
			DrawOLineInGL(Math.PI / 2, 0, 1.5f, 2.0f, Color.Lime, true);
			DrawOLineInGL(-Math.PI / 2, 0, 1.5f, 2.0f, Color.Lime, false);
			DrawOLineInGL(0, Math.PI / 2, 1.5f, 2.0f, Color.Blue, true);
			DrawOLineInGL(0, -Math.PI / 2, 1.5f, 2.0f, Color.Blue, false);
			//DrawOLineInGL(_azi, _ele, 1.2f, 3.0f, Color.White, true);

			GL.Begin(BeginMode.Quads);
            // 坐标面
            //GL.Color4(1.0f, 0.0f, 0.0f, 0.4f);
            //GL.Vertex3(0.0f, 1.0f, 1.0f);
            //GL.Vertex3(0.0f, 1.0f, -1.0f);
            //GL.Vertex3(0.0f, -1.0f, -1.0f);
            //GL.Vertex3(0.0f, -1.0f, 1.0f);
            //GL.Color4(0.0f, 1.0f, 0.0f, 0.4f);
            //GL.Vertex3(1.0f, 0.0f, 1.0f);
            //GL.Vertex3(1.0f, 0.0f, -1.0f);
            //GL.Vertex3(-1.0f, 0.0f, -1.0f);
            //GL.Vertex3(-1.0f, 0.0f, 1.0f);
            //GL.Color4(0.0f, 0.0f, 1.0f, 0.4f);
            //GL.Vertex3(1.0f, 1.0f, 0.0f);
            //GL.Vertex3(1.0f, -1.0f, 0.0f);
            //GL.Vertex3(-1.0f, -1.0f, 0.0f);
            //GL.Vertex3(-1.0f, 1.0f, 0.0f);

            //曲面
            if (_binaryFunction != null)
            {
                GL.Color4(0.5f, 0.5f, 1.0f, 0.8f);
                for (double i = -10d; i < 10d; i = i + 0.2d)
                {
                    for (double j = -10d; j < 10d; j = j + 0.2d)
                    {
                        GL.Vertex3(i / 10, j / 10, _binaryFunction(i, j) / 10);
                        GL.Vertex3(i / 10, (j + 0.2d) / 10, _binaryFunction(i, j + 0.2d) / 10);
                        GL.Vertex3((i + 0.2d) / 10, (j + 0.2d) / 10, _binaryFunction(i + 0.2d, j + 0.2d) / 10);
                        GL.Vertex3((i + 0.2d) / 10, j / 10, _binaryFunction(i + 0.2d, j) / 10);
                    }
                }
            }
			GL.End();

			GL.Disable(EnableCap.DepthTest);

			byte[] lettersX =
			{
				0x00,0xef,0x46,0x2c,0x2c,0x18,0x18,0x18,0x34,0x34,0x62,0xf7,0x00
			};
			byte[] lettersY =
			{
				0x00,0x3c,0x18,0x18,0x18,0x18,0x18,0x2c,0x2c,0x46,0x46,0xef,0x00
			};
			byte[] lettersZ =
			{
				0x00,0xfe,0x63,0x63,0x30,0x30,0x18,0x0c,0x0c,0x06,0xc6,0x7f,0x00
			};
			GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1.0f);
			GL.Color3(1.0f, 0.0f, 0.0f);
			GL.RasterPos3(1.4f, 0.0f, 0.0f);
			GL.Bitmap(8, 13, 0.0f, 0.0f, 20.0f, 0.0f, lettersX);
			GL.Color3(0.0f, 1.0f, 0.0f);
			GL.RasterPos3(0.0f, 1.4f, 0.0f);
			GL.Bitmap(8, 13, 0.0f, 0.0f, 20.0f, 0.0f, lettersY);
			GL.Color3(0.0f, 0.0f, 1.0f);
			GL.RasterPos3(0.0f, 0.0f, 1.4f);
			GL.Bitmap(8, 13, 0.0f, 0.0f, 20.0f, 0.0f, lettersZ);
			SwapBuffers();
		}

		private void DrawOLineInGL(double azimuth, double elevation, float length, float width, Color color, bool arrow)
		{
			float colorR, colorG, colorB;
			float x, y, z;

			colorR = color.R / 255.0f;
			colorG = color.G / 255.0f;
			colorB = color.B / 255.0f;

			x = length * (float)Math.Cos(elevation) * (float)Math.Cos(azimuth);
			y = length * (float)Math.Cos(elevation) * (float)Math.Sin(azimuth);
			z = length * (float)Math.Sin(elevation);

			GL.LineWidth(width);
			GL.Begin(BeginMode.Lines);
			GL.Color3(colorR, colorG, colorB);
			GL.Vertex3(0.0f, 0.0f, 0.0f);
			GL.Vertex3(x, y, z);
			GL.End();

			if (arrow)
			{
				float vx, vy, vz;
				vx = xMul(y, z, 0, 1);
				vy = xMul(z, x, 1, 0);
				vz = xMul(x, y, 0, 0);

				GL.LineWidth(1.0f);
				GL.PushMatrix();
				GL.Translate(x, y, z);
				if (isInLimits(elevation, Math.PI / 2, Math.PI / 2 * 3))
				{
					GL.Rotate((float)(90 - elevation / Math.PI * 180), vx, vy, vz);
				}
				else
				{
					GL.Rotate(-(float)(90 - elevation / Math.PI * 180), vx, vy, vz);
				}
				Glu.Cylinder(Glu.NewQuadric(), 0.06, 0.0, 0.2, 20, 5);
				GL.PopMatrix();
			}
		}

		private bool isInLimits(double p, double p_2, double p_3)
		{
			return ((p_2 <= p) && (p <= p_3));
		}

		private float xMul(float x1, float x2, float y1, float y2)
		{
			return x1 * y2 - x2 * y1;
		}

		void Motion(int x, int y)
		{
			float d, dx, dy, dz;
			// 计算当前的鼠标单位半球面坐标
			if (!Hemishere(x, y, GetSquareLength(), curPos))
			{
				return;
			}
			// 计算移动量的三个方向分量
			dx = curPos[0] - lastPos[0];
			dy = curPos[1] - lastPos[1];
			dz = curPos[2] - lastPos[2];
			// 如果有移动
			if ((0.0f != dx) || (0.0f != dy) || (0.0f != dz))
			{
				// 计算移动距离，用来近似移动的球面距离
				d = (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
				// 通过移动距离计算移动的角度
				theta = (float)d * 180.0f;
				// 计算移动平面的法向量，即：lastPos × curPos
				axis[0] = lastPos[1] * curPos[2] - lastPos[2] * curPos[1];
				axis[1] = lastPos[2] * curPos[0] - lastPos[0] * curPos[2];
				axis[2] = lastPos[0] * curPos[1] - lastPos[1] * curPos[0];
				// 记录当前的鼠标单位半球面坐标
				lastPos[0] = curPos[0];
				lastPos[1] = curPos[1];
				lastPos[2] = curPos[2];
			}
		}

		bool Hemishere(int x, int y, int d, float[] v)
		{
			float z;
			// 计算x, y坐标
			v[0] = (float)x * 2.0f - (float)d;
			v[1] = (float)d - (float)y * 2.0f;
			// 计算z坐标
			z = d * d - v[0] * v[0] - v[1] * v[1];
			if (z < 0)
			{
				return false;
			}
			v[2] = (float)Math.Sqrt(z);
			// 单位化
			v[0] /= (float)d;
			v[1] /= (float)d;
			v[2] /= (float)d;
			return true;
		}

		int GetSquareLength()
		{
			return this.Bounds.Width > this.Bounds.Height ? this.Bounds.Width : this.Bounds.Height;
		}

		private void Axles3D_MouseMove(object sender, MouseEventArgs e)
		{
			if (MouseButtons.Left == e.Button)
			{
				Motion(e.X, e.Y);
				DrawAll();
			}
		}

		private void Axles3D_MouseDown(object sender, MouseEventArgs e)
		{
			Hemishere(e.X, e.Y, GetSquareLength(), curPos);
			lastPos[0] = curPos[0];
			lastPos[1] = curPos[1];
			lastPos[2] = curPos[2];
		}

		private void Axles3D_Load(object sender, EventArgs e)
		{
            _loaded = true;
		}
	}
}

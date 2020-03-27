using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFGLib;

namespace TesseractScreenTextDemo
{
	public partial class ScreenForm : Form
	{
		readonly Rectangle ScreenRect = Screen.PrimaryScreen.Bounds;		
		public Bitmap ScreenBmp = null;		
		public Rectangle BoundRect;
		Brush m_brush = null;
		Pen m_pen = null;
		Point m_startPoint;

		public ScreenForm()
		{
			InitializeComponent();
		}

		private void ScreenForm_Load(object sender, EventArgs e)
		{
			m_brush = new SolidBrush(Color.Red);
			m_pen = new Pen(m_brush, 2);

			pictureBox1.Left = 0;
			pictureBox1.Top = 0;
			pictureBox1.Width = ScreenRect.Width;
			pictureBox1.Height = ScreenRect.Height;

			using (Graphics g = Graphics.FromImage(ScreenBmp))
			{
				Brush brush = new SolidBrush(Color.GreenYellow);
				Pen pen = new Pen(brush, 3);
				g.DrawRectangle(pen, new Rectangle(0, 0, ScreenRect.Width - 4, ScreenRect.Height - 4));
			}

			pictureBox1.Image = ScreenBmp;
		}		

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			m_startPoint = Cursor.Position;
			timer1.Enabled = true;
		}		

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			timer1.Enabled = false;
			BoundRect.X += 2;
			BoundRect.Y += 2;
			this.Close();
		}		

		private void timer1_Tick(object sender, EventArgs e)
		{
			int x = Math.Min(m_startPoint.X, Cursor.Position.X);
			int y = Math.Min(m_startPoint.Y, Cursor.Position.Y);
			int width = Math.Abs(Cursor.Position.X - m_startPoint.X);
			int height = Math.Abs(Cursor.Position.Y - m_startPoint.Y);
			BoundRect = new Rectangle(x, y, width, height);

			Bitmap newBmp = new Bitmap(ScreenRect.Width, ScreenRect.Height);
			using (Graphics g = Graphics.FromImage(newBmp))
			{
				g.DrawImage(ScreenBmp, 0, 0, ScreenRect.Width, ScreenRect.Height);
				g.DrawRectangle(m_pen, x, y, width, height);
			}

			pictureBox1.Image = newBmp;
		}
	}
}

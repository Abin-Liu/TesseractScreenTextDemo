using System;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;

namespace TesseractScreenTextDemo
{
	public partial class Form1 : Form
	{
		const int DPI = 300; // Tesseract最优DPI为300
		Bitmap m_bmp = null;
		static readonly double[] Zooms = { 1.0, 2.0, 4.0 };
		static readonly string[] Languages = { "eng", "chi_sim" };
		TesseractEngine m_engine = null;

		public Form1()
		{
			InitializeComponent();
		}

		void UpdateBitmap()
		{
			Bitmap bmp = MFGLib.BitmapHelper.Resize(m_bmp, Zooms[ddlScale.SelectedIndex]);
			if (chkMono.Checked)
			{
				bmp = MFGLib.BitmapHelper.Mono(bmp);
			}

			pictureBox1.Image = bmp;
		}		

		private void Form1_Load(object sender, EventArgs e)
		{
			ddlScale.SelectedIndex = 0;
			ddlLanguage.SelectedIndex = 0;
		}

		private void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.Enabled = false;
			m_engine = new TesseractEngine(AppDomain.CurrentDomain.BaseDirectory + "tessdata", Languages[ddlLanguage.SelectedIndex], EngineMode.Default);
			this.Cursor = Cursors.Default;
			this.Enabled = true;
		}

		private void ddlScale_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateBitmap();			
		}

		private void chkMono_CheckedChanged(object sender, EventArgs e)
		{
			UpdateBitmap();
		}		

		private void btnRecognize_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.Enabled = false;

			using (Page page = m_engine.Process(pictureBox1.Image as Bitmap))
			{
				string text = page.GetText();
				if (string.IsNullOrEmpty(text))
				{
					text = "<Unrecognizable>";
				}
				textBox1.Text = text;

				this.Cursor = Cursors.Default;
				this.Enabled = true;
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Rectangle ScreenRect = Screen.PrimaryScreen.Bounds;
			ScreenForm form = new ScreenForm();
			form.ScreenBmp = MFGLib.BitmapHelper.CaptureScreen(0, 0, ScreenRect.Width, ScreenRect.Height);
			form.ShowDialog(this);

			Rectangle rect = form.BoundRect;
			m_bmp = MFGLib.BitmapHelper.CaptureScreen(rect.X, rect.Y, rect.Width, rect.Height, DPI);			
			UpdateBitmap();
			btnRecognize.Enabled = m_bmp != null;
		}		
	}
}

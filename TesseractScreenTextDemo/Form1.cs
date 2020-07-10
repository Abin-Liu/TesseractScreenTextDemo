using System;
using System.Drawing;
using System.Windows.Forms;
using ScreenCapture;
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

			if (chkDenoise.Checked)
			{
				bmp = MFGLib.BitmapHelper.Binarisation(bmp, 0.5);
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

		private void chkDenoise_CheckedChanged(object sender, EventArgs e)
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

		private void CaptureFromScreen()
		{
			CaptureResult result = CaptureAgent.Capture(DPI);			
			if (result == null)
			{
				return;
			}

			m_bmp = result.Image;
			UpdateBitmap();
			btnRecognize.Enabled = m_bmp != null;
			lblRect.Text = result.Rect.ToString();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			CaptureFromScreen();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CaptureFromScreen();
		}		
	}
}

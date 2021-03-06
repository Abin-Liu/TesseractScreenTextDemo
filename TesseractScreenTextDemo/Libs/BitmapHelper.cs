﻿using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace MFGLib
{	
	/// <summary>
	/// Bitmap图像处理帮助类
	/// </summary>
	public class BitmapHelper
	{
		/// <summary>
		/// 抓取屏幕指定区域
		/// </summary>
		/// <param name="x">x坐标</param>
		/// <param name="y">y坐标</param>
		/// <param name="width">区域宽度</param>
		/// <param name="height">区域高度</param>		
		/// <param name="dpi">画质DPI，0表示系统默认值</param>	
		/// <returns>抓取成功返回Bitmap对象，否则返回null</returns>
		public static Bitmap CaptureScreen(int x, int y, int width, int height, int dpi = 0)
		{
			if (width < 1 || height < 1)
			{
				return null;
			}			

			Bitmap bmp = null;

			bmp = new Bitmap(width, height);			
			if (dpi > 0)
			{
				bmp.SetResolution(dpi, dpi);
			}

			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.CopyFromScreen(x, y, 0, 0, new Size(width, height));
			}

			return bmp;
		}

		/// <summary>
		/// 抓取某窗口客户区域中指定区域
		/// </summary>
		/// <param name="hwnd">窗口句柄</param>
		/// <param name="x">x坐标</param>
		/// <param name="y">y坐标</param>
		/// <param name="width">区域宽度</param>
		/// <param name="height">区域高度</param>
		/// <param name="dpi">画质DPI，0表示系统默认值</param>	
		/// <returns>抓取成功返回Bitmap对象，否则返回null</returns>
		public static Bitmap CaptureClient(IntPtr hwnd, int x, int y, int width, int height, int dpi = 0)
		{
			if (hwnd != IntPtr.Zero)
			{
				Point pt;
				if (!ClientToScreen(hwnd, out pt))
				{
					return null;
				}

				x = pt.X;
				y = pt.Y;
			}

			return CaptureScreen(x, y, width, height, dpi);
		}

		/// <summary>
		/// 抓取某窗口中指定区域
		/// </summary>
		/// <param name="hwnd">窗口句柄</param>
		/// <param name="x">x坐标</param>
		/// <param name="y">y坐标</param>
		/// <param name="width">区域宽度</param>
		/// <param name="height">区域高度</param>
		/// <param name="dpi">画质DPI，0表示系统默认值</param>	
		/// <returns>抓取成功返回Bitmap对象，否则返回null</returns>
		public static Bitmap CaptureWindow(IntPtr hwnd, int x, int y, int width, int height, int dpi = 0)
		{
			if (hwnd != IntPtr.Zero)
			{				
				Rectangle rect = new Rectangle();
				if (GetWindowRect(hwnd, out rect))
				{
					x = rect.X;
					y = rect.Y;
				}				
			}

			return CaptureScreen(x, y, width, height, dpi);
		}

		/// <summary>
		/// 抓取鼠标位置指定区域
		/// </summary>
		/// <param name="width">区域宽度</param>
		/// <param name="height">区域高度</param>
		/// <param name="dpi">画质DPI，0表示系统默认值</param>	
		/// <returns>抓取成功返回Bitmap对象，否则返回null</returns>
		public static Bitmap CaptureCursor(int width, int height, int dpi = 0)
		{
			Point pt;
			GetCursorPos(out pt);
			return CaptureScreen(pt.X, pt.Y, width, height, dpi);
		}

		/// <summary>
		/// 图像缩放
		/// </summary>
		/// <param name="bmp">源图像</param>
		/// <param name="zoom">缩放比例</param>		
		/// <returns>操作成功返回新图像，失败返回null</returns>
		public static Bitmap Resize(Bitmap bmp, double zoom)
		{
			if (bmp == null)
			{
				return null;
			}			

			if (zoom < 0)
			{
				zoom = -zoom;
			}

			int width = (int)(bmp.Width * zoom);
			int height = (int)(bmp.Height * zoom);
			if (width == bmp.Width || height == bmp.Height)
			{
				return bmp;
			}

			if (width < 1 || height < 1)
			{
				return null;
			}

			Bitmap newBmp = new Bitmap(width, height);
			newBmp.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

			using (Graphics g = Graphics.FromImage(newBmp))
			{
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				g.DrawImage(bmp, 0, 0, width, height);
			}

			return newBmp;
		}		

		/// <summary>
		/// 图像灰度化
		/// </summary>
		/// <param name="bmp">源图像</param>		
		/// <returns>操作成功返回新图像，失败返回null</returns>
		public static Bitmap Greyscale(Bitmap bmp)
		{
			if (bmp == null)
			{
				return null;
			}

			bmp = new Bitmap(bmp);
			int width = bmp.Width;
			int height = bmp.Height;

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Color c = bmp.GetPixel(x, y);
					int rgb = (int)Math.Round(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
					c = Color.FromArgb(rgb, rgb, rgb);
					bmp.SetPixel(x, y, c);
				}
			}

			return bmp;
		}

		/// <summary>
		/// 图像二值化
		/// </summary>
		/// <param name="bmp">源图像</param>
		/// <param name="threshold">二值化亮度阈值，小于此值设为黑色，大于等于此值设为白色，默认为0.72</param>
		/// <returns>操作成功返回新图像，失败返回null</returns>
		public static Bitmap Binarisation(Bitmap bmp, double threshold = 0.72)
		{
			if (bmp == null)
			{
				return null;
			}

			bmp = new Bitmap(bmp);
			int width = bmp.Width;
			int height = bmp.Height;

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Color c = bmp.GetPixel(x, y);
					double brightness = c.GetBrightness();
					if (brightness < threshold)
					{
						c = Color.Black;
					}
					else
					{
						c = Color.White;
					}

					bmp.SetPixel(x, y, c);
				}
			}

			return bmp;
		}

		[DllImport("user32.dll")]
		extern static bool ClientToScreen(IntPtr hwnd, out Point lpPoint);

		[DllImport("user32.dll")]
		static extern int GetCursorPos(out Point point);

		[DllImport("user32.dll")]
		static extern bool GetWindowRect(IntPtr hwnd, out Rectangle lpRect);
	}
}

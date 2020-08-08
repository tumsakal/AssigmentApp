using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;

namespace Assignment
{
	public class PrintHelper
	{
		public enum PapperKind
		{
			A4,
			A5,
			POS
		}

		public PapperKind Paper;

		public string PrinterName;

		public LocalReport Report;

		private int m_currentPageIndex;

		private IList<Stream> m_streams;

		private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
		{
			Stream stream = new MemoryStream();
			m_streams.Add(stream);
			return stream;
		}

		private void Export()
		{
			try
			{
				string deviceInfo = "";
				PageSettings ps = new PageSettings();
				ps.PrinterSettings.PrinterName = PrinterName;
				if (Paper == PapperKind.A4)
				{
					deviceInfo = "<DeviceInfo>\r\n                                <OutputFormat>EMF</OutputFormat>\r\n                                <PageWidth>8.27in</PageWidth>\r\n                                <PageHeight>11.69in</PageHeight>\r\n                                <MarginTop>0.2in</MarginTop>\r\n                                <MarginLeft>0.15in</MarginLeft>\r\n                                <MarginRight>0.15in</MarginRight>\r\n                                <MarginBottom>0.2in</MarginBottom>\r\n                                </DeviceInfo>";
				}
				else if (Paper == PapperKind.A5)
				{
					deviceInfo = "<DeviceInfo>\r\n                                <OutputFormat>EMF</OutputFormat>\r\n                                <PageWidth>5.83in</PageWidth>\r\n                                <PageHeight>8.27in</PageHeight>\r\n                                <MarginTop>0.2in</MarginTop>\r\n                                <MarginLeft>0.1in</MarginLeft>\r\n                                <MarginRight>0.1in</MarginRight>\r\n                                <MarginBottom>0.2in</MarginBottom>\r\n                                </DeviceInfo>";
				}
				else if (Paper == PapperKind.POS)
				{
					deviceInfo = "<DeviceInfo><OutputFormat>EMF</OutputFormat><PageWidth>" + ((decimal)ps.PaperSize.Width / 100m).ToString("F2") + "in</PageWidth><PageHeight>" + ((decimal)ps.PaperSize.Height / 100m).ToString("F2") + "in</PageHeight><PrintDpiX>" + ps.PrinterResolution.X + "</PrintDpiX><PrintDpiY>" + ps.PrinterResolution.Y + "</PrintDpiY><MarginTop>0in</MarginTop><MarginLeft>0in</MarginLeft><MarginRight>0in</MarginRight><MarginBottom>0in</MarginBottom></DeviceInfo>";
				}
				m_streams = new List<Stream>();
				Report.Render("Image", deviceInfo, CreateStream, out Warning[] _);
				foreach (Stream stream in m_streams)
				{
					stream.Position = 0L;
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
		}

		private void PrintPage(object sender, PrintPageEventArgs ev)
		{
			Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
			Rectangle adjustedRect = new Rectangle(ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX, ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY, ev.PageBounds.Width, ev.PageBounds.Height);
			ev.Graphics.FillRectangle(Brushes.White, adjustedRect);
			ev.Graphics.DrawImage(pageImage, adjustedRect);
			m_currentPageIndex++;
			ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
		}

		public void Print()
		{
			Export();
			if (m_streams == null || m_streams.Count == 0)
			{
				throw new Exception("Error: no stream to print.");
			}
			PrintDocument printDoc = new PrintDocument();
			printDoc.PrinterSettings.PrinterName = PrinterName;
			if (Paper == PapperKind.A4)
			{
				printDoc.DefaultPageSettings.Color = false;
				PaperSize p2 = new PaperSize("A4", 827, 1100);
				printDoc.DefaultPageSettings.PaperSize = p2;
			}
			else if (Paper == PapperKind.A5)
			{
				PaperSize p = new PaperSize("A5", 583, 827);
				p.RawKind = 11;
				printDoc.DefaultPageSettings.PaperSize = p;
				printDoc.PrinterSettings.DefaultPageSettings.PaperSize = p;
			}
			else if (Paper == PapperKind.POS)
			{
				printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
			}
			if (!printDoc.PrinterSettings.IsValid)
			{
				throw new Exception("Error: cannot find the default printer.");
			}
			printDoc.PrintPage += PrintPage;
			m_currentPageIndex = 0;
			printDoc.Print();
		}
	}
}
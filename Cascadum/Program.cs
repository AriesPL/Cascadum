using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System;

namespace Cascadum
{
	partial class Program
	{
		static void Main(string[] args)
		{
			
			var row = new Row();
			var col = new Column();

			string fileLocation = "C:\\Users\\Алексей\\source\\repos\\AriesPL\\Cascadum\\Cascadum\\Images\\1.jpg";
			


			TestRow(row, fileLocation);
			TestColumn(col, fileLocation);

		}

		private static void TestColumn(Column col, string fileLocation)
		{
			for (int i = 0; i < 5; i++) { col.Add(new Picture(Image.FromFile(fileLocation))); }

			col.GetBitmapWithWidth(600).Save("Col.jpg", ImageFormat.Jpeg);
		}

		private static void TestRow(Row row, string fileLocation)
		{
			for(int i = 0; i < 5; i++) { row.Add(new Picture(Image.FromFile(fileLocation))); }
			
			row.GetBitmapWithWidth(600).Save("Row.jpg", ImageFormat.Jpeg);
		}
	}
}

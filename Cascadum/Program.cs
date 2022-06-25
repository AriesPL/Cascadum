using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System;

namespace Cascadum
{
	partial class Program
	{
		const string _fileLocation = "Images\\";

		private static Random _random = new Random();

		/// <summary>
		/// Статический метод получения рандомного файла
		/// </summary>		
		static string GetRandomFile()
		{
			string[] fileNames = Directory.GetFiles(_fileLocation);

			int i = _random.Next(fileNames.Length);

			return fileNames[i];
		}

		static void Main(string[] args)
		{
			TestRow();
			TestColumn();
			TestCascad();
		}

		private static void TestCascad()
		{
			var column1 = new Column();
			for (int i = 0; i < 2; i++)
			{
				column1.Add(new Picture(Image.FromFile(GetRandomFile())));
			}

			var column2 = new Column();
			for (int i = 0; i < 3; i++)
			{
				column2.Add(new Picture(Image.FromFile(GetRandomFile())));
			}

			var picture1 = new Picture(Image.FromFile(_fileLocation + "2.jpg"));
			var picture2 = new Picture(Image.FromFile(_fileLocation + "11.jpg"));
			var picture3 = new Picture(Image.FromFile(_fileLocation + "13.jpg"));

			var row1 = new Row();
			row1.Add(picture1);
			row1.Add(column1);

			var row2 = new Row();
			row2.Add(picture2);
			row2.Add(column2);
			row2.Add(picture3);

			var column3 = new Column();
			column3.Add(row1);
			column3.Add(row2);

			column3.GetBitmapWithWidth(1500).Save("resultCascade.jpg", ImageFormat.Jpeg);
		}

		private static void TestColumn()
		{
			var col = new Column();
			for (int i = 0; i < 5; i++) 
			{ 
				col.Add(new Picture(Image.FromFile(GetRandomFile()))); 
			}
			col.GetBitmapWithWidth(600).Save("Col.jpg", ImageFormat.Jpeg);
		}

		private static void TestRow()
		{
			var row = new Row();
			for (int i = 0; i < 5; i++) 
			{ 
				row.Add(new Picture(Image.FromFile(GetRandomFile()))); 
			}
			row.GetBitmapWithWidth(600).Save("Row.jpg", ImageFormat.Jpeg);
		}
	}
}

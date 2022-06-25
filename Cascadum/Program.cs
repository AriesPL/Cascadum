using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System;

namespace Cascadum
{
	partial class Program
	{
		const string fileLocation = "Images\\";

		//Колличество обьектов в папке
		static int FolderCount()
		{
			int i = 0;
			DirectoryInfo directoryInfo = new DirectoryInfo(fileLocation);
			foreach ( FileInfo fileInfo in directoryInfo.GetFiles())
			{
				i++;
			}
			return i;
		}

		//Статический метод рандома
		static int Rnd(int min)
		{
			Random rnd = new Random();
			return rnd.Next(min, FolderCount());
		}

		//Статический метод получения имени обьекта
		static string FolderName(int min)
		{
			string[] masName = new string[FolderCount()];

			

			DirectoryInfo directoryInfo = new DirectoryInfo(fileLocation);
			int i = 0;
			
			foreach (FileInfo fileInfo in directoryInfo.GetFiles())
			{
				masName[i] = fileInfo.FullName;
				i++;
			}


			return masName[Rnd(min)];
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
				column1.Add(new Picture(Image.FromFile(FolderName(0 + i))));
			}
			
			

			var column2 = new Column();
			for (int i = 0; i < 3; i++)
			{
				column2.Add(new Picture(Image.FromFile(FolderName(0 + i))));
			}

			var picture1 = new Picture(Image.FromFile(fileLocation + "2.jpg"));
			var picture2 = new Picture(Image.FromFile(fileLocation + "11.jpg"));
			var picture3 = new Picture(Image.FromFile(fileLocation + "13.jpg"));

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
			for (int i = 0; i < 5; i++) { col.Add(new Picture(Image.FromFile(FolderName(0 + i)))); }

			col.GetBitmapWithWidth(600).Save("Col.jpg", ImageFormat.Jpeg);
		}

		private static void TestRow()
		{
			var row = new Row();
			for (int i = 0; i < 5; i++) { row.Add(new Picture(Image.FromFile(FolderName(0 + i)))); }
			
			row.GetBitmapWithWidth(600).Save("Row.jpg", ImageFormat.Jpeg);
		}
	}
}

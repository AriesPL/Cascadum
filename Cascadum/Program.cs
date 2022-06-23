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

			string fileLocation = "C:\\Users\\bengo\\source\\repos\\Cascadum\\Cascadum\\Images\\(1).jpg";

			//DirectoryInfo folder = new DirectoryInfo(fileLocation);

			//if (folder.Exists)
			//{
			//	foreach (FileInfo fileInfo in folder.GetFiles())
			//	{
			//		picture.Add(Image.FromFile(fileInfo.FullName));
			//		picture.Add(Image.FromFile(fileInfo.FullName));
			//		picture.Add(Image.FromFile(fileInfo.FullName));

			//	}
			//}

			row.Add(new Picture(Image.FromFile(fileLocation)));
			row.Add(new Picture(Image.FromFile(fileLocation)));
			row.Add(new Picture(Image.FromFile(fileLocation)));
			row.Add(new Picture(Image.FromFile(fileLocation)));

			//picture.DrawStoryboard(600);

			row.GetBitmapWithWidth(600).Save("result2.jpg",ImageFormat.Jpeg);

		}
	}
}

using System.Drawing;
using System.IO;

namespace Cascadum
{ 
	partial class Program
	{
		

		static void Main(string[] args)
		{
			var picture = new Picture();

			string fileLocation = "C:\\Users\\bengo\\source\\repos\\Cascadum\\Cascadum\\Images\\";

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

			picture.Add(Image.FromFile(fileLocation));
			picture.Add(Image.FromFile(fileLocation));
			picture.Add(Image.FromFile(fileLocation));
			picture.Add(Image.FromFile(fileLocation));
			picture.Add(Image.FromFile(fileLocation));

			picture.DrawStoryboard(600);

		}
	}
}

using System.Collections.Generic;
using System.Linq;
using System.Drawing;


namespace Cascadum
{
	public class Column: PictureBase, IStackable
	{ 
	//создаем колекцию картинок
		private List<IPicture> _images = new List<IPicture>();

	//Коэффицент
	public override float GetRatio()
	{
		return 1 / _images.Sum(image => 1 / image.GetRatio());
	}

	//Добавляем в колекцию
	public void Add(IPicture image)
	{
		_images.Add(image);
	}
		//метод переопределения высоты
		public override Bitmap GetBitmapWithHeight(int height)
	{
			var overallWidth = (int)(height * GetRatio());
			var bitmap = new Bitmap(overallWidth, height);
			using (var g = Graphics.FromImage(bitmap))
			{
				var localHeight = 0;
				foreach (var image in _images)
				{
					var resizedImage = image.GetBitmapWithWidth(overallWidth);
					g.DrawImage(resizedImage, 0, localHeight);
					localHeight += resizedImage.Height;
				}
			}

			return bitmap;

		}

	//метод переопределения ширины
	public override Bitmap GetBitmapWithWidth(int width)
	{
			
			var ovarallHeight = (int)(width / GetRatio());

			var bitmap = new Bitmap(width, ovarallHeight);

			using (var graphics = Graphics.FromImage(bitmap))
			{
				var localHeidth = 0;

				foreach (var image in _images)
				{
					var resizedImage = image.GetBitmapWithWidth(width);
					graphics.DrawImage(resizedImage, 0, localHeidth);
					localHeidth += resizedImage.Height;
				}
			}
			return bitmap;
		}

}
}

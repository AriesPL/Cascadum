using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Cascadum
{
	public class Row : PictureBase, IStackable
	{
		//создаем колекцию картинок
		private List<IPicture> _images = new List<IPicture>();

		public override float GetRatio()
		{
			return _images.Sum(x => x.GetRatio());
		}

		//Добавляем в колекцию
		public void Add(IPicture image)
		{
			_images.Add(image);
		}

		public override Bitmap GetBitmapWithHeight(int height)
		{
			throw new System.NotImplementedException();
		}

		//метод переопределения ширины
		public override Bitmap GetBitmapWithWidth(int width)
		{
			var ovarallHeight = (int)(width / GetRatio());

			var bitmap = new Bitmap(width, ovarallHeight);

			using (var graphics = Graphics.FromImage(bitmap))
			{
				var localWidth = 0;

				foreach (var image in _images)
				{
					var resizedImage = image.GetBitmapWithHeight(ovarallHeight);
					graphics.DrawImage(resizedImage, localWidth, 0);
					localWidth += resizedImage.Width;
				}
			}
			return bitmap;
		}

	}
}

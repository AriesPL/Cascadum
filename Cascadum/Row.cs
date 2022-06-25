using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Cascadum
{
	public class Row : PictureBase, IStackable
	{
		/// <summary>
		/// колекцию картинок
		/// </summary>
		private List<IPicture> _images = new List<IPicture>();

		public override float GetRatio()
		{
			return _images.Sum(image => image.GetRatio());
		}

		/// <summary>
		/// Добавляем в колекцию
		/// </summary>
		/// <param name="image"></param>
		public void Add(IPicture image)
		{
			_images.Add(image);
		}

		public override Bitmap GetBitmapWithHeight(int height)
		{
			var overallWidth = (int)(height * GetRatio());

			var bitmap = new Bitmap(overallWidth, height);
			using (var g = Graphics.FromImage(bitmap))
			{
				var localWidth = 0;
				foreach (var image in _images)
				{
					var resizedImage = image.GetBitmapWithHeight(height);
					g.DrawImage(resizedImage, localWidth, 0);
					localWidth += resizedImage.Width;
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

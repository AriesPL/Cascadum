using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Cascadum
{
	public class Picture
	{
		//создаем колекцию картинок
		private List<Image> _images = new List<Image>();

		//Добавляем в колекцию
		public void Add(Image image)
		{
			_images.Add(image);
		}
		
		//Отрисовываем картинки и сохраняем в файл
		public void DrawStoryboard(int overallWidth)
		{
			var sumRatio = _images.Sum(x => (float)x.Width / x.Height);
			var ovarallHeight = (int)(overallWidth / sumRatio);

			var bitmaps = _images.Select(x => (Bitmap)x);

			var bitmap = new Bitmap(overallWidth, ovarallHeight);
			using (var g = Graphics.FromImage(bitmap))
			{
				var localWidth = 0;
				foreach (var image in _images)
				{
					var resizedWidth = GetResizedWidth(image, ovarallHeight);
					var resizedImage = ResizeImage(image, resizedWidth, ovarallHeight);

					g.DrawImage(resizedImage, localWidth, 0);
					localWidth += resizedImage.Width;
				}
			}

			bitmap.Save("result.jpg", ImageFormat.Jpeg);
		}

		//метод получения измененой ширины
		private static int GetResizedWidth(Image image, int ovarallHeight)
		{
			float ratio = (float)ovarallHeight / image.Height;
			return (int)(image.Width * ratio);
		}

		//Метод изменения размера изображения
		private static Bitmap ResizeImage(Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}
	}
}


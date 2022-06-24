using System.Collections.Generic;
using System.Linq;
using System.Drawing;


namespace Cascadum
{
	public class Column: PictureBase, IStackable
	{ 
	//создаем колекцию картинок
		private List<IPicture> _images = new List<IPicture>();

	public override float GetRatio()
	{
		return 1 / _images.Sum(x => 1 /  x.GetRatio());
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

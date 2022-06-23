using System.Drawing;


namespace Cascadum
{
	public class Picture : PictureBase
	{
		private Image _image;

		public Picture(Image image)
		{
			_image = image;
		}

		public override Bitmap GetBitmapWithHeight(int height)
		{
			var scale = (float)height / _image.Height;
			var resizedHeight = height;
			var resizedWidth = _image.Width * scale;

			return ResizeImage(_image, (int)resizedWidth, resizedHeight);
		}

		public override Bitmap GetBitmapWithWidth(int width)
		{
			var scale = (float)width / _image.Width;
			var resizedHeight = _image.Height * scale;
			var resizedWidth = width;

			return ResizeImage(_image, resizedWidth, (int)resizedHeight);
		}

		public override float GetRatio()
		{
			return (float)_image.Width / _image.Height;
		}
	}
}


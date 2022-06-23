using System.Drawing;

namespace Cascadum
{
	public interface IPicture
	{
		//Отношение высоты к ширине w/h 
		float GetRatio();


		//Возвращение заданой высоты
		Bitmap GetBitmapWithHeight(int height);

		//Возвращение заданой ширины
		Bitmap GetBitmapWithWidth(int width);

	}
}

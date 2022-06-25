using System.Drawing;

namespace Cascadum
{
	public interface IPicture
	{
		//Отношение высоты к ширине w(4)/h(2) 
		float GetRatio();


		//Возвращение заданой высоты
		Bitmap GetBitmapWithHeight(int height);

		//Возвращение заданой ширины
		Bitmap GetBitmapWithWidth(int width);

	}
}

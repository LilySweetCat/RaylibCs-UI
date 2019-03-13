using Raylib;
using UI.Infrastructure;

namespace UI.Controls
{
	public class ColorBox : UserInterfaceElement
	{
		public Color Color
		{
			get;
			set;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public ColorBox(int x, int y, int width, int height, string name, Color color)
			: base(x, y, width, height, name)
		{
			Color = color;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public ColorBox(int x, int y, int width, int height, string name, ref Color color)
			: base(x, y, width, height, name)
		{
			Color = color;
		}

		public override void Draw()
		{
			if (IsVisible)
			{
				base.Draw();
				Raylib.Raylib.DrawRectangle(dX, dY, Width, Height, Color);
			}
		}
	}
}
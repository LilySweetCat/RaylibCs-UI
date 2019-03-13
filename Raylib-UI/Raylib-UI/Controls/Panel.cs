using Raylib;
using UI.Infrastructure;

namespace UI.Controls
{
	public class Panel : UserInterfaceElement
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public Panel(int x, int y, int width, int height, string name)
			: base(x, y, width, height, name)
		{
		}

		public override void Draw()
		{
			if (IsVisible)
			{
				base.Draw();
				Raylib.Raylib.GuiPanel(new Rectangle(dX,dY,Width,Height));
			}
		}
	}
}
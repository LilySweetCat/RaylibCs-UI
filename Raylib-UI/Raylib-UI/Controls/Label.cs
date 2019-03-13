using Raylib;
using UI.Infrastructure;

namespace UI.Controls
{
	class Label : UserInterfaceElement
	{
		public string Text
		{
			get;
			set;
		}
		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public Label(int x, int y, int width, int height, string name)
			: base(x, y, width, height, name)
		{
			Text = string.Empty;
		}

		public override void Draw()
		{
			if (IsVisible)
			{
				base.Draw();
				Raylib.Raylib.GuiLabel(new Rectangle(dX,dY, Width, Height), Text);
			}
		}
	}
}
using Raylib;
using UI.Infrastructure;

namespace UI.Controls
{
	internal class WindowBox : UserInterfaceElement
	{
		#region .ctor
		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public WindowBox(string name, int width, int height, int x = 0, int y = 0)
			: base(x, y, width, height, name)
		{
		}
		#endregion

		#region Overrided
		public override void Draw()
		{
			base.Draw();
			if (IsVisible)
			{
				if (Raylib.Raylib.GuiWindowBox(new Rectangle(X, Y, X, Y), "New project"))
				{
					EventManager.Message(Name);
				}
			}
		}
		#endregion
	}
}

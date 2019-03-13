using Raylib;
using UI.Infrastructure;

namespace UI.Controls
{
	internal class DropDown : UserInterfaceElement
	{
		#region Data
		#region Fields
		private readonly Button[] _buttons;
		private readonly int _height;
		private readonly int _width;
		#endregion
		#endregion

		#region .ctor
		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public DropDown(int width, int height, string name, Button[] buttons, int x = 0, int y = 0)
			: base(x, y, width, height, name)
		{
			_width = width;
			_height = height;
			_buttons = buttons;
			IsVisible = false;

			EventManager.Subscribe += message =>
			{
				if (message == name)
				{
					foreach (var button in _buttons)
					{
						button.Y = 0;
					}

					IsVisible = !IsVisible;
				}
			};
		}
		#endregion

		#region Overrided
		public override void Draw()
		{
			if (Raylib.Raylib.GuiButton(new Rectangle(X, Y, Configuration.Parameter.ButtonWidth, Configuration.Parameter.ButtonHeight), Name))
			{
				EventManager.Message(Name);
				var delta = _height;
				foreach (var button in _buttons)
				{
					button.Y += delta;
					delta += _height;
				}
			}

			if (IsVisible)
			{
				foreach (var button in _buttons)
				{
					button.Draw();
				}
			}
		}
		#endregion
	}
}

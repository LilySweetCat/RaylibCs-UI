using System;
using Raylib;
using UI.Infrastructure;

namespace UI.Controls
{
	internal class Button : UserInterfaceElement
	{
		#region Data
		#region Fields
		private readonly Action _action;
		#endregion
		#endregion

		#region .ctor
		public Button(string name, Action action, int x = 0, int y = 0)
			: base(x, y, Configuration.Parameter.ButtonWidth, Configuration.Parameter.ButtonHeight, name)
		{
			_action = action;
		}
		#endregion

		#region Overrided
		public override void Draw()
		{
			if (IsVisible)
			{
				base.Draw();
				if (Raylib.Raylib.GuiButton(new Rectangle(dX, dY, Width, Height), Name))
				{
					EventManager.Message(Name);
				}

				if (IsActivated)
				{
					_action?.Invoke();
				}
			}
		}
		#endregion
	}
}

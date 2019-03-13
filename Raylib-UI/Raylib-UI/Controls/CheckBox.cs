using Raylib;
using UI.Infrastructure;

namespace UI.Controls
{
	class CheckBox : UserInterfaceElement
	{
		public bool IsChecked;

		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public CheckBox(int x, int y, string name, bool isChecked = false)
			: base(x, y, Configuration.Parameter.CheckBoxWidth, Configuration.Parameter.CheckBoxHeight, name)
		{
			IsChecked = isChecked;
		}

		public override void Draw()
		{
			if (IsVisible)
			{
				base.Draw();
				IsChecked = Raylib.Raylib.GuiCheckBox(new Rectangle(dX, dY, Width, Height), IsChecked);
			}
		}
	}
}
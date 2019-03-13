using Raylib;
using UI.Infrastructure;

namespace UI.Controls
{
	internal class TextBox : UserInterfaceElement
	{
		public string Text
		{
			get;
			set;
		}
		public bool Edit
		{
			get;
			set;
		}

		#region .ctor
		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public TextBox(string name, ref string text, int width, int height, int x = 0, int y = 0)
			: base(x, y, width, height, name)
		{
			Text = text;
		}

		public TextBox(string name, string text, int width, int height, int x = 0, int y = 0)
			: base(x, y, width, height, name)
		{
			Text = text;
		}
		#endregion

		#region Overrided
		public override void Draw()
		{
			if (IsVisible)
			{
				base.Draw();
				if(Raylib.Raylib.GuiTextBox(new Rectangle(dX, dY, Width, Height), Text, Text.Length, Edit))
				{
					Edit = !Edit;
				}
			}
		}
		#endregion
	}
}

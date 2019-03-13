using UI.Interfaces;

namespace UI.Infrastructure
{
	public class UserInterfaceElement : IDrawable
	{
		#region Data
		#region Fields
		protected int dX;
		protected int dY;
		#endregion
		#endregion

		#region .ctor
		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public UserInterfaceElement(int x, int y, int width, int height, string name)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
			IsVisible = true;
			Name = name;

			EventManager.Subscribe += message =>
			{
				if (message == Name)
				{
					IsActivated = !IsActivated;
				}
			};
		}
		#endregion

		#region Properties
		public int Height
		{
			get;
		}

		public bool IsActivated
		{
			get;
			set;
		}

		public bool IsVisible
		{
			get;
			set;
		}

		public string Name
		{
			get;
		}

		public UserInterfaceElement Parent
		{
			get;
			set;
		}

		public int Width
		{
			get;
		}

		public int X
		{
			get;
			set;
		}
		public int Y
		{
			get;
			set;
		}
		#endregion

		#region Overridable
		public virtual void Draw()
		{
			dX = X;
			dY = Y;
			if (Parent != null)
			{
				dX = (Parent.X + (Parent.Width / 2)) + (X - Width/2);
				dY = (Parent.Y + Height) + Y;
			}
		}
		#endregion
	}
}

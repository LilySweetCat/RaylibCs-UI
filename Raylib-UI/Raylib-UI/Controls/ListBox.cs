using UI.Infrastructure;

namespace UI.Controls
{
	public class ListBox : UserInterfaceElement
	{
		private UserInterfaceElement[] _list;

		public int Selected;
		private int ScrollIndex;

		public bool IsSelectable
		{
			get;
			set;
		}
		
		private int _deltaHeight;
		
		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public ListBox(int x, int y, int width, int height, string name, UserInterfaceElement[] list, bool isSelectable = false)
			: base(x, y, width, height, name)
		{
			_list = list;
			ScrollIndex = 0;
			Selected = 0;
			IsSelectable = isSelectable;

			int actualHeight = 0;
			foreach (var userInterfaceElement in _list)
			{
				actualHeight += userInterfaceElement.Height;
			}

			_deltaHeight = actualHeight - Height;
			var tempHeight = 0;
			foreach (var userInterfaceElement in _list)
			{
				userInterfaceElement.Parent = this;
				userInterfaceElement.Y += tempHeight;
				tempHeight += userInterfaceElement.Height;
			}
		}

		public override void Draw()
		{
			if (IsVisible)
			{
				base.Draw();
				// TODO: fix native listview marshalling
				//GuiListView(new Rectangle(dX, dY, Width, Height), _objects, ref Active, ref ScrollIndex, EditMode);
				// TODO: scrollbar logic
				foreach (var userInterfaceElement in _list)
				{
					userInterfaceElement.Draw();
				}
				
			}
		}
	}
}
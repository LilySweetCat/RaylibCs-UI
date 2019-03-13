using System.Collections.Generic;
using UI.Infrastructure;

namespace UI.Controls
{
	public class Node : UserInterfaceElement
	{
		private List<Node> inputs;
		private Node output;
		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public Node(int x, int y, int width, int height, string name)
			: base(x, y, width, height, name)
		{
		}
	}

	public class ColorNode : Node
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
		public ColorNode(int x, int y, int width, int height, string name)
			: base(x, y, width, height, name)
		{
		}
	}
}
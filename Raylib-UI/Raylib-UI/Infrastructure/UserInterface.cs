using System;
using System.Collections.Generic;
using System.Linq;
using Raylib;
using UI.Controls;

namespace UI.Infrastructure
{
	public class UserInterface
	{
		#region Data
		#region Static
		private List<UserInterfaceElement> _visibleLayer;
		private List<UserInterfaceElement> _waitingPool;
		#endregion

		#region Fields
		private readonly Button[] _menuButtons =
		{
			new Button("New",
					   () =>
					   {
					   }),
			new Button("Save",
					   () =>
					   {
						   EventManager.Message("Open saving dialog");
					   }),
			new Button("Load",
					   () =>
					   {
						   throw new NotImplementedException();
					   }),
			new Button("Quit",
					   () =>
					   {
						   Environment.Exit(0);
					   })
		};
		#endregion
		#endregion

		#region .ctor
		public UserInterface()
		{
			Setup();
		}
		#endregion

		#region Public
		public void Draw()
		{
			if (Configuration.Parameter.EditorIsVisible)
			{
				Raylib.Raylib.GuiLine(new Rectangle(0, 0, Configuration.Parameter.RWidth, Configuration.Parameter.ButtonHeight), Configuration.Parameter.ButtonHeight);
				foreach (var element in _visibleLayer)
				{
					element.Draw();
				}

				if (Raylib.Raylib.IsKeyDown(Raylib.Raylib.KEY_TAB))
				{
					EventManager.Message("Log viewer");
				}

				UpdatePool();
			}
		}

		private void UpdatePool()
		{
			if (_waitingPool.Any())
			{
				_visibleLayer.AddRange(_waitingPool);
				_waitingPool.Clear();
			}
		}
		#endregion

		#region Private
		private void Setup()
		{
			var x = Configuration.Parameter.RWidth / 3;
			var y = Configuration.Parameter.RHeight / 3;

			EventManager.Subscribe += message =>
			{
				switch (message)
				{
					case "Add new color":
						_waitingPool.Add(new ColorNode(x, y, Configuration.Parameter.ButtonWidth * 2, Configuration.Parameter.ButtonHeight * 6, "Color node"));
						break;
					case "Log viewer":
						if (_visibleLayer.Single(e => e.Name == message) is Label textBox)
						{
							textBox.Text = Log.Log.ReadLog();
							textBox.IsVisible = !textBox.IsVisible;
						}
						break;
				}
			};

			_waitingPool = new List<UserInterfaceElement>();

			_visibleLayer = new List<UserInterfaceElement>
			{
				new Label(Configuration.Parameter.ButtonWidth,
						  Configuration.Parameter.ButtonHeight,
						  Configuration.Parameter.RWidth / 3,
						  Configuration.Parameter.RHeight / 3,
						  "Log viewer")
				{
					IsVisible = false
				},
				new Label(Configuration.Parameter.ButtonWidth + Configuration.Parameter.Margin,
						  0,
						  Configuration.Parameter.ButtonWidth,
						  Configuration.Parameter.ButtonHeight,
						  "Compact editor text")
				{
					Text = "Compact editor: "
				},
				new CheckBox(Configuration.Parameter.ButtonWidth * 3, 0, "Compact editor"),
				new Panel(0,
						  Configuration.Parameter.ButtonHeight + Configuration.Parameter.Margin / 2,
						  Configuration.Parameter.ButtonWidth * 2,
						  Configuration.Parameter.RHeight - Configuration.Parameter.ButtonHeight - Configuration.Parameter.Margin,
						  "Tools panel"),
				new ListBox(Configuration.Parameter.ButtonHeight,
							Configuration.Parameter.ButtonHeight + Configuration.Parameter.Margin * 2,
							Configuration.Parameter.ButtonWidth,
							Configuration.Parameter.ButtonHeight * 5,
							"Toolbox",
							new UserInterfaceElement[]
							{
								new Button("Color",
										   () =>
										   {
											   EventManager.Message("Add new color");
										   },
										   0,
										   0),
								new Button("Multiply",
										   () =>
										   {
											   EventManager.Message("Add new multiply");
										   },
										   0,
										   0),
								new Button("Divide",
										   () =>
										   {
											   EventManager.Message("Add new divide");
										   },
										   0,
										   0),
							}),
				new DropDown(Configuration.Parameter.ButtonWidth, Configuration.Parameter.ButtonHeight, "Menu", _menuButtons),
			};
		}
		#endregion
	}
}

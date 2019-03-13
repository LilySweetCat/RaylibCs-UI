using Raylib;
using UI.Infrastructure;

namespace UI
{
	internal static class Program
	{
		#region Private
		private static void Main(string[] args)
		{
			Configuration.Load();

			var width = Configuration.Parameter.RWidth;
			var height = Configuration.Parameter.RHeight;
			var ui = new UserInterface();

			Raylib.Raylib.InitWindow(width, height, "Material");

			var camera = new Camera3D
			{
				position = new Vector3(8.0f, 8.0f, 8.0f),
				target = new Vector3(0.0f, 2.5f, 0.0f),
				up = new Vector3(0.0f, 1.0f, 0.0f),
				fovy = 45.0f,
				type = CameraType.CAMERA_PERSPECTIVE
			};

			var model = Raylib.Raylib.LoadModel("castle.obj");
			var texture = Raylib.Raylib.LoadTexture("castle_diffuse.png");
			model.material.maps[(int) TexmapIndex.MAP_ALBEDO]
				 .texture = texture;
			var position = new Vector3(0.0f, 0.0f, 0.0f);

			Raylib.Raylib.SetTargetFPS(60);

			while (!Raylib.Raylib.WindowShouldClose())
			{
				//2D
				Raylib.Raylib.BeginDrawing();

				Raylib.Raylib.ClearBackground(Raylib.Raylib.WHITE);

				ui.Draw();

				//3D
				//BeginMode3D(camera);

				//DrawModel(model, position, 0.2f, WHITE);   // Draw 3d model with texture

				//DrawGrid(10, 1.0f);         // Draw a grid

				//DrawGizmo(position);        // Draw gizmo

				Raylib.Raylib.EndMode3D();

				Raylib.Raylib.EndDrawing();
			}

			Raylib.Raylib.CloseWindow();
		}
		#endregion
	}
}

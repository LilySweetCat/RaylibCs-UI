using System.IO;

namespace UI.Infrastructure
{
	public static class FileSystem
	{
		public static void WriteFile(string path, string message)
		{
			using (var sw = new StreamWriter(path, true))
			{
				sw.WriteLineAsync(message);
			}
		}

		public static string ReadFile(string path)
		{
			var data = string.Empty;
			using (var sr = new StreamReader(path))
			{
				 data = sr.ReadToEnd();
			}

			return data;
		}
	}
}
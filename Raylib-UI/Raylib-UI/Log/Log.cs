using UI.Infrastructure;

namespace UI.Log
{
	public static class Log
	{
		const string name = "log.txt";
		public static void WriteLog(string message)
		{
			FileSystem.WriteFile(name, message);
		}

		public static string ReadLog() => FileSystem.ReadFile(name);
	}
}
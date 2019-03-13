namespace UI.Infrastructure
{
	public static class EventManager
	{
		#region Delegates and events
		public delegate void MessageHandler(string message);

		public static event MessageHandler Subscribe;
		#endregion

		#region Public
		public static void Message(string message)
		{
			Log.Log.WriteLog(message);
			Subscribe?.Invoke(message);
		}
		#endregion
	}
}

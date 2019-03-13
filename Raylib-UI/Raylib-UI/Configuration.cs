using System;
using System.IO;
using System.Xml.Serialization;

namespace UI
{
	[Serializable]
	public class ConfigurationParameter
	{
		#region Data
		#region Fields
		public int ButtonHeight;
		public int ButtonWidth;
		public int CheckBoxHeight;
		public int CheckBoxWidth;
		public bool EditorIsVisible;
		public int Margin;
		public int RHeight;
		public int RWidth;
		#endregion
		#endregion
	}

	public static class Configuration
	{
		#region Data
		#region Static
		public static ConfigurationParameter Parameter = new ConfigurationParameter();
		#endregion
		#endregion

		#region Public
		public static void Load()
		{
			var serializer = new XmlSerializer(typeof(ConfigurationParameter));
			if (File.Exists("Configuration.xml"))
			{
				using (var fileStream = new FileStream("Configuration.xml", FileMode.Open))
				{
					var configuration = (ConfigurationParameter) serializer.Deserialize(fileStream);
					Parameter = configuration;
				}
			}
			else
			{
				Parameter.RWidth = 1280;
				Parameter.RHeight = 720;
				Parameter.EditorIsVisible = true;
				Parameter.ButtonHeight = 30;
				Parameter.ButtonWidth = 60;
				Parameter.CheckBoxHeight = 30;
				Parameter.CheckBoxWidth = 30;
				Parameter.Margin = 10;
				Save();
			}
		}

		public static void Save()
		{
			var serializer = new XmlSerializer(typeof(ConfigurationParameter));
			using (var fileStream = new FileStream("Configuration.xml", FileMode.OpenOrCreate))
			{
				serializer.Serialize(fileStream, Parameter);
			}
		}
		#endregion
	}
}

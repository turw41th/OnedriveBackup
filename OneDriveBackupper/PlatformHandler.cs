using System.Runtime.InteropServices;

namespace OneDriveBackupper
{
	public sealed class PlatformHandler
	{
		private static Lazy<PlatformHandler> instance;
		public static PlatformHandler Instance => instance.Value;

		private static readonly string baseDirectory = AppContext.BaseDirectory;

		public static string LogFolder => Path.Combine(baseDirectory, "internal", "Logs");
		public static string ConfigFolder => Path.Combine(baseDirectory, "internal", "Config");

		public static OSPlatform OsPlatform { get; private set; }

		private PlatformHandler(OSPlatform osPlatform)
		{
			OsPlatform = osPlatform;
		}

		public static void Initialize(OSPlatform osPlatform)
		{
			if (instance != null)
			{
				throw new InvalidOperationException("PlatformHandler is already initialized.");
			}

			instance = new Lazy<PlatformHandler>(() => new PlatformHandler(osPlatform));
		}
	}

}
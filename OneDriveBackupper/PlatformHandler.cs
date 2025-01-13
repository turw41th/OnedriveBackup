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

		public static void Initialize()
		{
			if (instance != null)
			{
				throw new InvalidOperationException("PlatformHandler is already initialized.");
			}

			OSPlatform osPlatform;
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				osPlatform = OSPlatform.Windows;
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				osPlatform = OSPlatform.Linux;
			}
			else
			{
				throw new NotSupportedException("Platform is not supported.");
			}

			instance = new Lazy<PlatformHandler>(() => new PlatformHandler(osPlatform));
		}
	}

}
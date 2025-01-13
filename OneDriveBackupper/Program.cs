using System.Runtime.InteropServices;
using Serilog;

namespace OneDriveBackupper
{
	class Program
	{
		static void Main(string[] args)
		{
			PlatformHandler.Initialize();
			
			Log.Logger = new LoggerConfiguration()
				.WriteTo.Console()
				.WriteTo.File("log.txt", rollOnFileSizeLimit: true)
				.MinimumLevel.Debug()
				.CreateLogger();
		}
	}
}
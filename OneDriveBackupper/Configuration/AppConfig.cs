namespace OneDriveBackupper.Configuration
{
	public class AppConfig
	{
		public OneDriveCredentials OneDriveCredentials { get; set; }
		public BackupSettings BackupSettings { get; set; }
	}

	public class OneDriveCredentials
	{
		public string ClientId { get; set; }
		public string TenantId { get; set; }
		public string ClientSecret { get; set; }
	}

	public class BackupSettings
	{
		public string TargetFolderOnOneDrive { get; set; }
		public List<string> LocalFoldersToBackup { get; set; }
		public Schedule Schedule { get; set; }
	}

	public class Schedule
	{
		public string Frequency { get; set; } // "Daily", "Weekly"
		public string DayOfWeek { get; set; } // e.g., "Sunday"
		public string Time { get; set; } // e.g., "03:00"
	}
}
namespace WebApi.Helpers
{
	public class AppSettings
	{
		public string Secret { get; set; }
		public string ConnStr { get; set; }
		public double WebTokenValidity { get; set; }
		public double MobileTokenvalidity { get; set; }
		public string AllowMultiplelogin { get; set; }

	}
}
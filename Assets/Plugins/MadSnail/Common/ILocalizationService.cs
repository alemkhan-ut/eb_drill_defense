namespace MadSnail.Common
{
	public interface ILocalizationService
	{
		public string GetCurrentLanguage();
		public void SetLanguage(string language);
	}
}

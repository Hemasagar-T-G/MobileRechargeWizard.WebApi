namespace MobileRechargeWizard.WebApi
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public Dictionary<string, object> Collections { get; set; } = null!;
    }
}

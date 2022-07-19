namespace ApiInsuranceManager.AppServices
{
    public class AzureKeyVaultConfig
    {
        public string TenantId { get; set; }
        public string KeyVault { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }
}
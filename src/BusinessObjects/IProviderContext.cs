namespace BusinessObjects
{
    public interface IProviderContext
    {
        string IDbContext { get; set; }
        string ProviderConnectionString { get; set; }
        string ProviderName { get; set; }
    }
}
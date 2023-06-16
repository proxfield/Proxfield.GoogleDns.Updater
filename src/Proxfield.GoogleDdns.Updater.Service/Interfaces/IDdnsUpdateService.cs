namespace Proxfield.GoogleDdns.Updater.Service.Interfaces
{
    public interface IDdnsUpdateService
    {
        Task UpdateDdnsRegistry(CancellationToken cancellationToken);
    }
}

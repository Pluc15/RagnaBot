using Discord;
using Microsoft.Extensions.Logging;

public class AddVendorWatcherAction(
    VendorWatcherRepository vendorWatcherRepository,
    ILogger<AddVendorWatcherAction> logger)
{
    public VendorWatcher Run(
        IUser user,
        string vendorName
    )
    {
        var watcher = vendorWatcherRepository.AddOrReplace(user.Id, vendorName);

        logger.LogInformation($"Vendor watcher added: {watcher}");

        return watcher;
    }
}
using System;
using Discord;
using Microsoft.Extensions.Logging;

public class DeleteVendorWatcherAction(
    VendorWatcherRepository vendorWatcherRepository,
    ILogger<DeleteVendorWatcherAction> logger)
{
    public void Run(
        IUser user,
        string vendorName
    )
    {
        if (vendorWatcherRepository.Delete(user.Id, vendorName) == 0)
            throw new Exception("Vendor watcher not found"); // TODO Typed exception + error handling

        logger.LogInformation($"Vendor watcher deleted: User '{user.Username}', Vendor '{vendorName}'");
    }
}
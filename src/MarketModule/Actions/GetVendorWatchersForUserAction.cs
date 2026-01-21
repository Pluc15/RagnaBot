using System.Collections.Generic;
using Discord;
using Microsoft.Extensions.Logging;

public class GetVendorWatchersForUserAction(
    VendorWatcherRepository vendorWatcherRepository,
    ILogger<GetVendorWatchersForUserAction> logger)
{
    public IEnumerable<VendorWatcher> Run(
        IUser user
    )
    {
        var watchers = vendorWatcherRepository
                    .GetForUser(user.Id);

        logger.LogInformation($"Vendor watcher list requested by user '{user.Username}'");

        return watchers;
    }
}
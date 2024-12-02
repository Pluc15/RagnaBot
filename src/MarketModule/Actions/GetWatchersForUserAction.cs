using System.Collections.Generic;
using System.Linq;
using Discord;
using Microsoft.Extensions.Logging;

public class GetWatchersForUserAction(
    MarketWatcherRepository marketWatcherRepository,
    ItemInfoRepository itemInfoRepository,
    ILogger<GetWatchersForUserAction> logger)
{
    public List<(MarketWatcher Watcher, ItemInfo ItemInfo)> Run(
        IUser user
    )
    {
        var watchers = marketWatcherRepository
                    .GetForUser(user.Id)
                    .Select(watcher =>
                    {
                        var itemInfo = itemInfoRepository.Search(watcher.ItemId) ?? throw new ItemInfoNotFoundException(watcher.ItemId);
                        return (Watcher: watcher, ItemInfo: itemInfo);
                    })
                    .ToList();

        logger.LogInformation($"Watcher list requested by user '{user.Username}'");

        return watchers;
    }
}
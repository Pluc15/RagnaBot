using Discord;
using Microsoft.Extensions.Logging;

public class AddWatcherAction(
    ItemInfoRepository itemInfoRepository,
    MarketWatcherRepository marketWatcherRepository,
    ILogger<AddWatcherAction> logger)
{
    public (ItemInfo ItemInfo, MarketWatcher Watcher) Run(
        IUser user,
        int itemId,
        int maximumPrice
    )
    {
        var itemInfo = itemInfoRepository.Search(itemId) ?? throw new ItemInfoNotFoundException(itemId);
        var watcher = marketWatcherRepository.AddOrReplace(user.Id, itemId, maximumPrice);

        logger.LogInformation($"Watcher created for user '{user.Username}' for item id '{itemId}' when price is equal or under '{maximumPrice}'");

        return (ItemInfo: itemInfo, Watcher: watcher);
    }
}
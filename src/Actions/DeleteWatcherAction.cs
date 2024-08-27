using Discord;
using Microsoft.Extensions.Logging;

public class DeleteWatcherAction(
    MarketWatcherRepository marketWatcherRepository,
    ItemInfoRepository itemInfoRepository,
    ILogger<DeleteWatcherAction> logger)
{
    public ItemInfo Run(
        IUser user,
        int itemId
    )
    {
        if (marketWatcherRepository.Delete(user.Id, itemId) == 0)
            throw new MarketWatcherNotFoundException(user, itemId);

        var item = itemInfoRepository.Search(itemId) ?? throw new ItemInfoNotFoundException(itemId);

        logger.LogInformation($"Watcher deleted for user '{user.Username}' for item id '{itemId}'");

        return item;
    }
}
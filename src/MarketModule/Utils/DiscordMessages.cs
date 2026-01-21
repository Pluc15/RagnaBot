using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;

// TODO Split the partial
public static partial class DiscordMessages
{
    public static DiscordMessage MarketConfigurationUpdated()
    {
        return new DiscordMessage(message: "Market configuration updated :check:", ephemeral: true);
    }

    public static DiscordMessage MarketWatcherCreated(
        ItemInfo itemInfo,
        MarketWatcher watcher
    )
    {
        var embedBuilder = new EmbedBuilder()
                    .WithTitle(itemInfo.Name)
                    .WithThumbnailUrl(ArcadiaRoUrlBuilder.GetItemImageUrl(itemInfo.Id))
                    .WithUrl(ArcadiaRoUrlBuilder.GetItemInfoUrl(itemInfo.Id))
                    .WithDescription(":white_check_mark: Market watcher created")
                    .AddField("Item Id", itemInfo.Id.ToString(), true)
                    .AddField("Maximum Price", watcher.MaximumPrice.ToString(), true);

        return new DiscordMessage(embed: embedBuilder.Build(), ephemeral: true);
    }

    public static DiscordMessage MarketWatcherDeleted(
        ItemInfo itemInfo
    )
    {
        var embedBuilder = new EmbedBuilder()
                    .WithTitle(itemInfo.Name)
                    .WithThumbnailUrl(ArcadiaRoUrlBuilder.GetItemImageUrl(itemInfo.Id))
                    .WithUrl(ArcadiaRoUrlBuilder.GetItemInfoUrl(itemInfo.Id))
                    .WithDescription(":x: Market watcher deleted")
                    .AddField("Item Id", itemInfo.Id.ToString(), true);

        return new DiscordMessage(embed: embedBuilder.Build(), ephemeral: true);
    }

    public static DiscordMessage MarketWatcherList(
        IEnumerable<(MarketWatcher Watcher, ItemInfo ItemInfo)> watchers
    )
    {
        var sb = new StringBuilder();
        sb.AppendLine("# Watch list");
        sb.AppendLine("```");
        sb.AppendLine("Item Name            | Item Id | Max Price    | Min Amount");
        sb.AppendLine("-------------------- | ------- | ------------ | ----------");

        foreach (var watcher in watchers)
            sb.AppendLine(
                $"{watcher.ItemInfo.Name,-20} | " +
                $"{watcher.ItemInfo.Id,-7} | " +
                $"{watcher.Watcher.MaximumPrice,-12} | " +
                $"{watcher.Watcher.MinimumQuantity,-10}"
            );
        sb.AppendLine("```");

        return new DiscordMessage(message: sb.ToString(), ephemeral: true);
    }

    public static DiscordMessage MarketWatcherTriggered(
        MarketWatcher watcher,
        ShopItem shopItem,
        Shop shop,
        ItemInfo itemInfo
    )
    {
        var embedBuilder = new EmbedBuilder()
            .WithTitle(itemInfo.Name)
            .WithThumbnailUrl(ArcadiaRoUrlBuilder.GetItemImageUrl(shopItem.ItemId))
            .WithUrl(ArcadiaRoUrlBuilder.GetItemInfoUrl(shopItem.ItemId))
            .WithDescription($":bell: Market watcher triggered")
            .AddField("Item Id", shopItem.ItemId.ToString(), true)
            .AddField("Item Price", shopItem.Price.ToString(), true)
            .AddField("Amount", shopItem.Amount.ToString(), true)
            .AddField("Shop", $"`@navshop {shop.Owner}`", true);

        return new DiscordMessage(
            Formatter.FormatUserMention(watcher.UserId),
            embed: embedBuilder.Build(),
            allowedMentions: new AllowedMentions
            {
                UserIds = [watcher.UserId]
            });
    }

    public static DiscordMessage MarketWatcherNotFound(
        MarketWatcherNotFoundException ex
    )
    {
        return new DiscordMessage($":warning: No market watchers found for item id '{ex.ItemId}'.", ephemeral: true);
    }

    public static DiscordMessage ItemInfoNotFound(
         ItemInfoNotFoundException ex)
    {
        return new DiscordMessage($":warning: Unknown item id '{ex.ItemId}'. Did you use the correct item id?", ephemeral: true);
    }

    public static DiscordMessage VendorWatcherAdded(VendorWatcher watcher)
    {
        var embed = new EmbedBuilder()
            .WithTitle($"Vendor watcher added: {watcher.VendorName}")
            .WithDescription(":white_check_mark: Vendor watcher registered")
            .AddField("Vendor", watcher.VendorName, true)
            .AddField("User", Formatter.FormatUserMention(watcher.UserId), true)
            .Build();

        return new DiscordMessage(embed: embed, ephemeral: true);
    }

    public static DiscordMessage VendorWatcherRemoved(string vendorName)
    {
        var embed = new EmbedBuilder()
            .WithTitle($"Vendor watcher removed: {vendorName}")
            .WithDescription(":x: Vendor watcher removed")
            .AddField("Vendor", vendorName, true)
            .Build();

        return new DiscordMessage(embed: embed, ephemeral: true);
    }

    public static DiscordMessage VendorWatcherList(IEnumerable<VendorWatcher> watchers)
    {
        var sb = new StringBuilder();
        sb.AppendLine("# Vendor Watchers");

        foreach (var w in watchers)
            sb.AppendLine($"- {w.VendorName}");

        return new DiscordMessage(message: sb.ToString(), ephemeral: true);
    }

    public static DiscordMessage VendorStartedVending(
        Shop newShop,
        IEnumerable<(ItemInfo ItemInfo, int Quantity, int Price)> newShopItems
    )
    {
        var newShopItemsString = BuildItemsTable(newShopItems);

        var embed = new EmbedBuilder()
            .WithDescription($":shopping_trolley: Vendor started vending")
            .AddField("Vendor", newShop.Owner, true)
            .AddField("Shop", newShop.Title, true)
            .AddField("New items for sale", newShopItemsString.ToString(), false)
            .Build();

        return new DiscordMessage(embed: embed);
    }

    public static DiscordMessage VendorSoldItems(
        Shop shop,
        IEnumerable<(ItemInfo ItemInfo, int Quantity, int Price)> soldItems
    )
    {
        var soldItemsString = BuildItemsTable(soldItems);

        var embed = new EmbedBuilder()
            .WithDescription($":moneybag: Vendor sold items")
            .AddField("Vendor", shop.Owner, true)
            .AddField("Shop", shop.Title, true)
            .AddField("Sold items", soldItemsString.ToString(), false)
            .Build();

        return new DiscordMessage(embed: embed);
    }

    public static DiscordMessage VendorRefreshedShop(
        Shop previousShop,
        IEnumerable<(ItemInfo ItemInfo, int Quantity, int Price)> previousShopItems,
        Shop newShop,
        IEnumerable<(ItemInfo ItemInfo, int Quantity, int Price)> newShopItems
    )
    {
        var previousShopItemsString = BuildItemsTable(previousShopItems);
        var newShopItemsString = BuildItemsTable(newShopItems);

        var embed = new EmbedBuilder()
            .WithDescription($":recycle: Vendor is refreshing his shop")
            .AddField("Vendor", previousShop.Owner, true)
            .AddField("Shop", previousShop.Title, true)
            .AddField("Potentially sold items", previousShopItemsString.ToString(), false)
            .AddField("New items for sale", newShopItemsString.ToString(), false)
            .Build();

        return new DiscordMessage(embed: embed);
    }

    public static DiscordMessage VendorStoppedVending(
        Shop previousShop,
        IEnumerable<(ItemInfo ItemInfo, int Quantity, int Price)> previousShopItems
    )
    {
        var previousShopItemsString = BuildItemsTable(previousShopItems);

        var embed = new EmbedBuilder()
            .WithDescription(":stop_sign: Vendor stopped vending or sold out")
            .AddField("Vendor", previousShop.Owner, true)
            .AddField("Shop", previousShop.Title, true)
            .AddField("Potentially sold items", previousShopItemsString.ToString(), false)
            .Build();

        return new DiscordMessage(embed: embed);
    }

    private static StringBuilder BuildItemsTable(
        IEnumerable<(ItemInfo ItemInfo, int Quantity, int Price)> soldItems
    )
    {
        var itemsString = new StringBuilder();
        itemsString.AppendLine("");
        itemsString.AppendLine("```");
        itemsString.AppendLine("Item Name                 | Qty | Price");
        itemsString.AppendLine("------------------------- | --- | -----");
        foreach (var soldItem in soldItems)
            itemsString.AppendLine($"{soldItem.ItemInfo.Name,-25} | {soldItem.Quantity,3} | {soldItem.Price,5}");
        itemsString.AppendLine("```");

        return itemsString;
    }
}
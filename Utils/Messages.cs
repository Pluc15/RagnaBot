using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSharpPlus.Entities;
using RagnaBot.Models;
using RagnaBot.Origin;

namespace RagnaBot.Utils
{
    public static class Messages
    {
        public static DiscordMessageBuilder TimerRegistered(
            Timer timer,
            MvpInfo mvpInfo
        )
        {
            var nextSpawn = SpawnCalculator.GetNextSpawn(timer, mvpInfo);
            var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer, mvpInfo);
            var nextReminder = SpawnCalculator.GetNextReminder(timer, mvpInfo);
            return new DiscordMessageBuilder()
                .AddEmbed(
                    new DiscordEmbedBuilder()
                        .WithUrl(OriginsRoUrlBuilder.GetMobInfoUrl(mvpInfo.RagnarokId.ToString()))
                        .WithThumbnail(OriginsRoUrlBuilder.GetMobImageUrl(mvpInfo.RagnarokId.ToString()))
                        .WithTitle(mvpInfo.MvpName)
                        .AddField("Map", mvpInfo.Map, true)
                        .AddField("Spawn time", $"<t:{nextSpawn.ToEpoch()}:t> to <t:{nextSpawnWindowEnd.ToEpoch()}:t>\n<t:{nextSpawn.ToEpoch()}:R>", true)
                        .AddField("Reminder", $"<t:{nextReminder.ToEpoch()}:t>", true)
                );
        }

        public static DiscordMessageBuilder MvpSpawningSoon(
            Timer timer,
            MvpInfo mvpInfo,
            IEnumerable<DiscordRole> mentionRoles
        )
        {
            var nextSpawn = SpawnCalculator.GetNextSpawn(timer, mvpInfo);
            var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer, mvpInfo);
            var discordMessageBuilder = new DiscordMessageBuilder()
                .AddEmbed(
                    new DiscordEmbedBuilder()
                        .WithUrl(OriginsRoUrlBuilder.GetMobInfoUrl(mvpInfo.RagnarokId.ToString()))
                        .WithThumbnail(OriginsRoUrlBuilder.GetMobImageUrl(mvpInfo.RagnarokId.ToString()))
                        .WithTitle(mvpInfo.MvpName)
                        .AddField("Map", mvpInfo.Map, true)
                        .AddField("Spawn time", $"<t:{nextSpawn.ToEpoch()}:t> to <t:{nextSpawnWindowEnd.ToEpoch()}:t>\n<t:{nextSpawn.ToEpoch()}:R>", true)
                )
                .WithContent(
                    string.Join(
                        ", ",
                        mentionRoles
                            .Select(r => r.Mention)
                            .Union(
                                new[]
                                {
                                    Formatter.FormatUserMention(timer.ReportedByUserId)
                                }
                            )
                    )
                )
                .WithAllowedMention(new UserMention(timer.ReportedByUserId));
            foreach (var mention in mentionRoles)
                discordMessageBuilder.WithAllowedMention(new RoleMention(mention));
            return discordMessageBuilder;
        }

        public static DiscordMessageBuilder Dashboard(
            string title,
            IEnumerable<(Timer Timer, MvpInfo MvpInfo)> timersSpawned
        )
        {
            var embedBuilder = new DiscordEmbedBuilder()
                .WithTitle($"__**{title}**__");

            foreach (var timer in timersSpawned)
            {
                var nextSpawn = SpawnCalculator.GetNextSpawn(timer.Timer, timer.MvpInfo);
                var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer.Timer, timer.MvpInfo);
                embedBuilder
                    .AddField("MVP", $"{timer.MvpInfo.MvpName}\n{timer.MvpInfo.Map}", true)
                    .AddField("Spawn time", $"<t:{nextSpawn.ToEpoch()}:t> to <t:{nextSpawnWindowEnd.ToEpoch()}:t>\n<t:{nextSpawn.ToEpoch()}:R>", true)
                    .AddField("Reported by", Formatter.FormatUserMention(timer.Timer.ReportedByUserId), true);
            }

            return new DiscordMessageBuilder()
                .AddEmbed(embedBuilder);
        }

        public static DiscordMessageBuilder MarketWatcherNotFound(
            int itemId
        )
        {
            return new DiscordMessageBuilder()
                .WithContent($":warning: Market watcher for item id '{itemId}' not found");
        }

        public static DiscordMessageBuilder MarketWatcherTriggered(
            MarketWatcher watcher,
            Item item,
            Shop shop
        )
        {
            return new DiscordMessageBuilder()
                .AddEmbed(
                    new DiscordEmbedBuilder()
                        .WithTitle(ItemDb.Data.GetValueOrDefault(item.ItemId) ?? "Unknown Item")
                        .WithThumbnail(OriginsRoUrlBuilder.GetItemImageUrl(item.ItemId))
                        .WithUrl(OriginsRoUrlBuilder.GetItemInfoUrl(item.ItemId))
                        .WithDescription(":bell: Market watcher triggered\nWatcher snoozed for 1h :zzz:")
                        .AddField("Item Id", item.ItemId.ToString(), true)
                        .AddField("Item Price", item.Price.ToString(), true)
                        .AddField("Shop", $"`@navshop {shop.Owner}`", true)
                )
                .WithContent(Formatter.FormatUserMention(watcher.UserId))
                .WithAllowedMention(new UserMention(watcher.UserId));
        }

        public static DiscordMessageBuilder MarketWatcherCreated(
            int itemId,
            int maximumPrice
        )
        {
            return new DiscordMessageBuilder()
                .AddEmbed(
                    new DiscordEmbedBuilder()
                        .WithTitle(ItemDb.Data.GetValueOrDefault(itemId) ?? "Unknown Item")
                        .WithThumbnail(OriginsRoUrlBuilder.GetItemImageUrl(itemId))
                        .WithUrl(OriginsRoUrlBuilder.GetItemInfoUrl(itemId))
                        .WithDescription(":white_check_mark: Market watcher created")
                        .AddField("Item Id", itemId.ToString(), true)
                        .AddField("Maximum Price", maximumPrice.ToString(), true)
                );
        }

        public static DiscordMessageBuilder MarketWatcherDeleted(
            int itemId
        )
        {
            return new DiscordMessageBuilder()
                .AddEmbed(
                    new DiscordEmbedBuilder()
                        .WithTitle(ItemDb.Data.GetValueOrDefault(itemId) ?? "Unknown Item")
                        .WithThumbnail(OriginsRoUrlBuilder.GetItemImageUrl(itemId))
                        .WithUrl(OriginsRoUrlBuilder.GetItemInfoUrl(itemId))
                        .WithDescription(":x: Market watcher deleted")
                        .AddField("Item Id", itemId.ToString(), true)
                );
        }

        public static DiscordMessageBuilder MarketWatcherList(
            List<MarketWatcher> watchers
        )
        {
            var sb = new StringBuilder();
            foreach (var watcher in watchers)
                sb.AppendLine($"{ItemDb.Data[watcher.ItemId]} - {watcher.MaximumPrice}");
            return new DiscordMessageBuilder()
                .AddEmbed(
                    new DiscordEmbedBuilder()
                        .WithTitle("Watchlist")
                        .WithDescription(sb.ToString())
                );
        }
    }
}
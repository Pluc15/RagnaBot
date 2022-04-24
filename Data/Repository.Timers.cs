using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using RagnaBot.Utils;

namespace RagnaBot.Data
{
    public partial class Repository
    {
        public IEnumerable<Timer> GetTimersSpawningInAWhile()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsSpawningInAWhile(o.Timer, o.MvpInfo))
                .Select(o => o.Timer)
                .ToList();
        }

        public IEnumerable<Timer> GetTimersSpawningSoon()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsSpawningSoon(o.Timer, o.MvpInfo))
                .Select(o => o.Timer)
                .ToList();
        }

        public IEnumerable<Timer> GetTimersWithReminderDue()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsReminderDue(o.Timer, o.MvpInfo))
                .Select(o => o.Timer)
                .ToList();
        }

        public IEnumerable<Timer> GetTimersInWindow()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsInWindow(o.Timer, o.MvpInfo))
                .Select(o => o.Timer)
                .ToList();
        }

        public IEnumerable<Timer> GetTimersSpawned()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsSpawned(o.Timer, o.MvpInfo))
                .Select(o => o.Timer)
                .ToList();
        }

        public IEnumerable<Timer> GetTimersOldTimers()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsOldTimer(o.Timer, o.MvpInfo))
                .Select(o => o.Timer)
                .ToList();
        }

        public Task DeleteTimer(
            string id
        )
        {
            _data.Timers.RemoveAll(t => t.Id == id);
            return SaveAsync();
        }

        public Task SetReminderSent(
            string id
        )
        {
            _data.Timers.Single(t => t.Id == id).ReminderSent = true;
            return SaveAsync();
        }

        public async Task<Timer> CreateTimer(
            MvpInfo mvpInfo,
            DateTime timeOfDeath,
            DiscordUser user
        )
        {
            _data.Timers.RemoveAll(t => t.Id == mvpInfo.Id);
            var timer = new Timer
            {
                Id = mvpInfo.Id,
                TimeOfDeath = timeOfDeath,
                ReminderSent = false,
                ReportedByUserId = user.Id
            };
            _data.Timers.Add(timer);
            await SaveAsync();
            return timer;
        }

        private IEnumerable<(Timer Timer, MvpInfo MvpInfo)> GetAllTimersWithMvpInfo()
        {
            return _data.Timers.GroupJoin(
                MvpInfo.Mvps,
                t => t.Id,
                m => m.Id,
                (
                    timer,
                    mvpInfos
                ) => (timer, mvpInfos.Single())
            );
        }
    }
}
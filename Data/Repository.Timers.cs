using System;
using System.Collections.Generic;
using System.Linq;
using DSharpPlus.Entities;
using RagnaBot.Models;
using RagnaBot.Utils;

namespace RagnaBot.Data
{
    public partial class Repository
    {
        public IEnumerable<(Timer Timer, MvpInfo MvpInfo)> GetTimersSpawningInAWhile()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsSpawningInAWhile(o.Timer, o.MvpInfo))
                .ToList();
        }

        public IEnumerable<(Timer Timer, MvpInfo MvpInfo)> GetTimersSpawningSoon()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsSpawningSoon(o.Timer, o.MvpInfo))
                .ToList();
        }

        public IEnumerable<(Timer Timer, MvpInfo MvpInfo)> GetTimersWithReminderDue()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsReminderDue(o.Timer, o.MvpInfo))
                .ToList();
        }

        public IEnumerable<(Timer Timer, MvpInfo MvpInfo)> GetTimersInWindow()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsInWindow(o.Timer, o.MvpInfo))
                .ToList();
        }

        public IEnumerable<(Timer Timer, MvpInfo MvpInfo)> GetTimersSpawned()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsSpawned(o.Timer, o.MvpInfo))
                .ToList();
        }

        public IEnumerable<(Timer Timer, MvpInfo MvpInfo)> GetTimersOldTimers()
        {
            return GetAllTimersWithMvpInfo()
                .Where(o => SpawnCalculator.IsOldTimer(o.Timer, o.MvpInfo))
                .ToList();
        }

        public void DeleteTimer(
            string id
        )
        {
            _data.Timers.RemoveAll(t => t.Id == id);
            _dirty = true;
        }

        public void SetReminderSent(
            string id
        )
        {
            _data.Timers.Single(t => t.Id == id).ReminderSent = true;
            _dirty = true;
        }

        public Timer CreateTimer(
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
            _dirty = true;
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
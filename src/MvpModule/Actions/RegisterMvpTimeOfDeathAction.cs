using System;
using Discord;
using Microsoft.Extensions.Logging;

public class RegisterMvpTimeOfDeathAction(
    MvpInfoRepository mvpInfoRepository,
    MvpTimersRepository mvpTimersRepository,
    ILogger<RegisterMvpTimeOfDeathAction> logger)
{
    public (MvpTimer Timer, MvpInfo MvpInfo) Run(
        string mvpId,
        DateTime timeOfDeath,
        IUser user,
        bool overrideExisting = false
    )
    {
        var mvpInfo = mvpInfoRepository.Find(mvpId) ?? throw new MvpUnknownException(mvpId);

        if (!overrideExisting)
        {
            var existingTimer = mvpTimersRepository.GetExisting(mvpInfo);

            if (existingTimer != null && (SpawnCalculator.IsSpawningInAWhile(existingTimer, mvpInfo) || SpawnCalculator.IsSpawningSoon(existingTimer, mvpInfo)))
                throw new MvpTimerAlreadyExists(existingTimer, mvpInfo);
        }

        var timer = mvpTimersRepository.AddOrUpdate(mvpInfo, timeOfDeath, user);
        logger.LogInformation($"Timer updated for '{mvpInfo.Id}' to '{timer.TimeOfDeath}' by '{user.Username}'");
        return (timer, mvpInfo);
    }
}
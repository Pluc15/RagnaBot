using System;
using Discord;
using Microsoft.Extensions.Logging;

public class RegisterMvpTimeOfDeathAction(
    MvpInfoRepository mvpInfoRepository,
    MvpTimersRepository mvpTimersRepository,
    ILogger<RegisterMvpTimeOfDeathAction> logger)
{
    public (MvpTimer Timer, MvpInfo MvpInfo) Run(
        string mvpKey,
        DateTime timeOfDeath,
        IUser user
    )
    {
        var mvpInfo = mvpInfoRepository.Search(mvpKey) ?? throw new MvpUnknownException(mvpKey);

        // TODO Check if it already exist - ask for confirmation

        var timer = mvpTimersRepository.AddOrUpdate(mvpInfo, timeOfDeath, user);

        logger.LogInformation($"Timer updated for '{mvpInfo.Id}' to '{timer.TimeOfDeath}' by '{user.Username}'");

        return (timer, mvpInfo);
    }
}
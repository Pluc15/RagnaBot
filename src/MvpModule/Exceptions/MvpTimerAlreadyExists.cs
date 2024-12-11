using System;

public class MvpTimerAlreadyExists(MvpTimer existingMvpTimer, MvpInfo mvpInfo) : Exception($"MvP timer already exists")
{
    public MvpTimer ExistingMvpTimer { get; } = existingMvpTimer;
    public MvpInfo MvpInfo { get; } = mvpInfo;
}

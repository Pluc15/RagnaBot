using System;

public class MvpUnknownException(string mvpId) : Exception($"Unknown MvP '{mvpId}'");
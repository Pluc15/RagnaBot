using System;

public class MvpUnknownException(string mvpName) : Exception($"Unknown MvP '{mvpName}'");
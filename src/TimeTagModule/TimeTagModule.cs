using System;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;

[CommandContextType(InteractionContextType.PrivateChannel, InteractionContextType.Guild)]
[IntegrationType(ApplicationIntegrationType.GuildInstall)]
public class TimeTagModule() : BaseModule
{
    [SlashCommand("timetag", "Generate a time tag so everyone can see the time in their timezone")]
    public async Task TimeTag(
        [Autocomplete(typeof(TimezoneAutocomplete))]
        string timezone,
        DateTime datetime)
    {
        var tz = TimeZoneInfo.FindSystemTimeZoneById(timezone);
        var dateTimeOffset = new DateTimeOffset(datetime, tz.BaseUtcOffset);
        dateTimeOffset.ToUnixTimeSeconds();
        await RespondAsync($@"
## Use the following tags to post a time that will self adjust for everyone's timezones.
_eg: 12/03/2024_
```<t:{dateTimeOffset.ToUnixTimeSeconds()}:d>```
_eg: December 3, 2024_
```<t:{dateTimeOffset.ToUnixTimeSeconds()}:D>```
_eg: 7:00 PM_
```<t:{dateTimeOffset.ToUnixTimeSeconds()}:t>```
_eg: 7:00:00 PM_
```<t:{dateTimeOffset.ToUnixTimeSeconds()}:T>```
_eg: December 3, 2024 7:00 PM_
```<t:{dateTimeOffset.ToUnixTimeSeconds()}:f>```
_eg: Tuesday, December 3, 2024 7:00 PM_
```<t:{dateTimeOffset.ToUnixTimeSeconds()}:F>```
_eg: in 2 days_
```<t:{dateTimeOffset.ToUnixTimeSeconds()}:R>```
", ephemeral: true);
    }
}
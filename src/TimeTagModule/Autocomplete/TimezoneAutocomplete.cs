
using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;

public class TimezoneAutocomplete : AutocompleteHandler
{
    public override Task<AutocompletionResult> GenerateSuggestionsAsync(
        IInteractionContext context,
        IAutocompleteInteraction autocompleteInteraction,
        IParameterInfo parameter,
        IServiceProvider services)
    {
        var timezones = TimeZoneInfo.GetSystemTimeZones()
            .Where(timezone => timezone.DisplayName.Contains(
                autocompleteInteraction.Data.Current.Value.ToString() ?? "",
                StringComparison.InvariantCultureIgnoreCase));
        var results = timezones.Select(timezone => new AutocompleteResult(timezone.DisplayName, timezone.Id));
        // max - 25 suggestions at a time (API limit)
        return Task.FromResult(AutocompletionResult.FromSuccess(results.Take(25)));
    }
}

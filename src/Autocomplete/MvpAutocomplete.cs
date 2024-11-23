
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Microsoft.Extensions.DependencyInjection;

public class MvpAutocomplete : AutocompleteHandler
{
    public override Task<AutocompletionResult> GenerateSuggestionsAsync(
        IInteractionContext context,
        IAutocompleteInteraction autocompleteInteraction,
        IParameterInfo parameter,
        IServiceProvider services)
    {
        var mvpInfoRepository = services.GetService<MvpInfoRepository>() ?? throw new NullReferenceException();

        var possibleMvps = mvpInfoRepository.Search(autocompleteInteraction.Data.Current.Value.ToString() ?? "");

        IEnumerable<AutocompleteResult> results = possibleMvps.Select(possibleMvp => new AutocompleteResult($"{possibleMvp.MvpName} ({possibleMvp.Map})", possibleMvp.Id));

        // max - 25 suggestions at a time (API limit)
        return Task.FromResult(AutocompletionResult.FromSuccess(results.Take(25)));
    }
}

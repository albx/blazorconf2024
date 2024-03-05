namespace BlazorStarWars.Web.GraphQL.Events;

public record EpisodeRatedEvent(
    int Average,
    int NumberOfRates);

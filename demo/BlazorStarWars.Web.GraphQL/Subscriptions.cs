using BlazorStarWars.Web.GraphQL.Events;

namespace BlazorStarWars.Web.GraphQL;

public class Subscriptions
{
    [Subscribe]
    [Topic($"{{{nameof(episodeId)}}}")]
    public EpisodeRatedEvent EpisodeRated(
        string episodeId, 
        [EventMessage] EpisodeRatedEvent episodeRated) => episodeRated;
}

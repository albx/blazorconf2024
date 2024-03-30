using BlazorStarWars.Web.GraphQL.Data;
using BlazorStarWars.Web.GraphQL.Events;
using HotChocolate.Subscriptions;

namespace BlazorStarWars.Web.GraphQL;

public class Mutations
{
    public async Task<RateEpisodePayload> RateEpisode(
        [Service(ServiceKind.Resolver)] StarWarsRatingDbContext dbContext,
        [Service] ITopicEventSender sender,
        RateEpisodeInput rate)
    {
        var rating = new EpisodeRating
        {
            EpisodeId = rate.EpisodeId,
            Rate = rate.Rate
        };

        dbContext.Ratings.Add(rating);
        await dbContext.SaveChangesAsync();

        var ratings = dbContext.Ratings.Where(r => r.EpisodeId == rate.EpisodeId).ToArray();
        var numberOfRates = ratings.Length;
        var average = (int)ratings.Average(r => r.Rate);

        await sender.SendAsync(
            rate.EpisodeId,
            new EpisodeRatedEvent(average, numberOfRates));

        return new(rate.EpisodeId, numberOfRates, average);
    }
}

public record RateEpisodeInput(string EpisodeId, int Rate);

public record RateEpisodePayload(string EpisodeId, int NumberOfRates, int Average);

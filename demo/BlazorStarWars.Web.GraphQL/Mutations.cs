using BlazorStarWars.Web.GraphQL.Data;

namespace BlazorStarWars.Web.GraphQL;

public class Mutations
{
    public async Task<RateEpisodePayload> RateEpisode(
        [Service(ServiceKind.Resolver)] StarWarsRatingDbContext dbContext,
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
        return new(rate.EpisodeId, ratings.Length, (int)ratings.Average(r => r.Rate));
    }
}

public record RateEpisodeInput(string EpisodeId, int Rate);

public record RateEpisodePayload(string EpisodeId, int NumberOfRates, int Average);

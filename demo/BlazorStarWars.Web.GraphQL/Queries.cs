using BlazorStarWars.Web.GraphQL.Data;

namespace BlazorStarWars.Web.GraphQL;

public class Queries
{
    public IQueryable<EpisodeRating> GetRatings(
        [Service(ServiceKind.Resolver)] StarWarsRatingDbContext dbContext,
        string episodeId) => dbContext.Ratings.Where(r => r.EpisodeId == episodeId);
}

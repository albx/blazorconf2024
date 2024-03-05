using Microsoft.EntityFrameworkCore;

namespace BlazorStarWars.Web.GraphQL.Data;

public class StarWarsRatingDbContext : DbContext
{
    public StarWarsRatingDbContext(DbContextOptions<StarWarsRatingDbContext> options)
        : base(options)
    {
    }

    public DbSet<EpisodeRating> Ratings { get; set; } = default!;
}

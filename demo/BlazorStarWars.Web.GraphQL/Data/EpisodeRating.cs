namespace BlazorStarWars.Web.GraphQL.Data;

public class EpisodeRating
{
    public int Id { get; set; }

    public string EpisodeId { get; set; } = string.Empty;

    public int Rate { get; set; }
}

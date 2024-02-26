using BlazorStarWars.Web.GraphQL;
using BlazorStarWars.Web.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StarWarsRatingDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EpisodeRatings")));

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<StarWarsRatingDbContext>(DbContextKind.Resolver)
    .AddQueryType<Queries>();

var app = builder.Build();

app.MapGet("/", () => "Hello BlazorConf 2024!");
app.MapGraphQL();

app.Run();

using BlazorStarWars.Web.GraphQL;
using BlazorStarWars.Web.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StarWarsRatingDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EpisodeRatings")));

builder.Services
    .AddGraphQLServer()
    .AddInMemorySubscriptions()
    .RegisterDbContext<StarWarsRatingDbContext>(DbContextKind.Resolver)
    .AddQueryType<Queries>()
    .AddMutationType<Mutations>()
    .AddSubscriptionType<Subscriptions>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseWebSockets();
app.UseCors();

app.MapGet("/", () => "Hello BlazorConf 2024!");
app.MapGraphQL();

app.Run();

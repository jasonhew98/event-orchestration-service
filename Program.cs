using EventOrchestrationService.Api.Conductor;
using EventOrchestrationService.Api.GraphQL.Mutations;
using EventOrchestrationService.Api.GraphQL.Queries;
using EventOrchestrationService.Api.GraphQL.Subscriptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
        .WithOrigins("http://localhost:8080")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<UserQuery>()
    .AddMutationType<MessageMutation>()
    .AddSubscriptionType<MessageSubscription>()
    .AddInMemorySubscriptions(); ;

builder.Services.AddSignalR();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

app.UseWebSockets();

app.MapGraphQL();
app.MapHub<EventHub>("/hubs");

app.Run();

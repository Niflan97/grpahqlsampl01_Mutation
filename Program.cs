using grpahqlsampl01.GraphGL;
using grpahqlsampl01.IServices;
using grpahqlsampl01.Service;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGroupService, GroupService>();
builder.Services.AddSingleton<IStudentService, StudentService>();


builder.Services.AddGraphQL(p =>  SchemaBuilder.New()
    .AddServices(p)
    .AddType<GroupType>()
    .AddType<StudentType>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .Create()

);

var app = builder.Build();

app.UsePlayground(new PlaygroundOptions
{
    QueryPath = "/api",
    Path = "/playground"
});

app.MapGraphQL("/api");
app.MapGet("/", () => "Hello World!");

app.Run();
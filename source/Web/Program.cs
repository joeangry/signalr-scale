using Web.Websocket;

var builder = WebApplication.CreateBuilder(args);

var redisConnection = builder.Configuration.GetValue<string>("App:RedisConnection");

Console.WriteLine($"Using '{redisConnection}' for redis connection");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR()
    .AddStackExchangeRedis(redisConnection);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.MapHub<ChatHub>("/chat-hub");

app.Run();
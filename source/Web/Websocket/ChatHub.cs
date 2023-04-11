using Microsoft.AspNetCore.SignalR;

namespace Web.Websocket;

public class ChatHub : Hub
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }
    
    public async Task SendMessage(string name, string message)
    {
        _logger.LogInformation("{HubName} received a message '{Message}' from {Name}", nameof(ChatHub), message, name);

        var host = Environment.MachineName;
        
        await Clients.All.SendAsync("ReceiveMessage", host, name, message);
    }
}
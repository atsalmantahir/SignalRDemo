using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Models;

namespace SignalRDemo.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessageAsync(string name, string text) 
    {
        var message = new ChatMessage 
        {
            SenderName = name,
            Text = text,
            SentAt = DateTimeOffset.UtcNow,            
        };

        await Clients.All.SendAsync(
            "RecieveMessage",
            message.SenderName,
            message.Text,
            message.SentAt);
    }
}

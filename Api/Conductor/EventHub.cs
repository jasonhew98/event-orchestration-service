using Microsoft.AspNetCore.SignalR;

namespace EventOrchestrationService.Api.Conductor
{
    public class EventHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} joined.");
        }

        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage", "Hello from Server");
        }
    }
}

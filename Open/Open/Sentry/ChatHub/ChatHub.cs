using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Open.Sentry.ChatHub
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("SendMessage", Context.User.Identity.Name, message);
        }

        public async Task AddToClientsList()
        {
            await Clients.All.SendAsync("ListAction", Context.User.Identity.Name);
        }

        public async Task RemoveFromClientsList()
        {
            await Clients.All.SendAsync("ListAction", Context.User.Identity.Name);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "joined");
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "left");
        }
    }
}
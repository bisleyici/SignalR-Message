using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Message.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            if (string.IsNullOrEmpty(user))
                await Clients.All.SendAsync("ReceiveMessageHandler", message);
            else
                await Clients.User(user).SendAsync("ReceiveMessageHandler", message);
        }
    }
}

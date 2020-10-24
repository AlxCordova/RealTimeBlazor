using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTime.Server.Hubs
{
    //[Route("/broadcastHub")]
    public class BroadcastHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
        //public Task SendMessage()
        //{
        //    return Clients.All.SendAsync("ReceiveMessage");
        //}
    }
}

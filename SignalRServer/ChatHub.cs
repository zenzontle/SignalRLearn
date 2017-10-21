using Microsoft.AspNet.SignalR;
using SignalRCommon;

namespace SignalRServer
{
    public class ChatHub : Hub
    {
        public void Send(ChatMessage chatMessage)
        {
            Clients.All.broadcastMessage(chatMessage);
        }
    }
}
using Microsoft.AspNet.SignalR.Client;
using SignalRCommon;
using System;
using System.Threading.Tasks;

namespace SignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();

            Console.ReadKey();
        }

        static async Task MainAsync()
        {
            try
            {
                var hubConnection = new HubConnection("http://localhost:1501/");
                IHubProxy chatProxy = hubConnection.CreateHubProxy("ChatHub");
                chatProxy.On<ChatMessage>("broadcastMessage", chatMessage =>
                {
                    Console.WriteLine($"{chatMessage.User}: {chatMessage.Message}");
                });
                await hubConnection.Start();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}

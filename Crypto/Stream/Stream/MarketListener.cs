using Binance.Spot;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Stream
{
    internal class MarketListener
    {
        private HubConnection connection;

        public MarketListener()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("wss://ws.cex.com", option =>
                {
                    option.Transports = HttpTransportType.WebSockets;
                })
                .WithAutomaticReconnect()
                .Build();
        }

        public async Task StartListeningAsync()
        {
            var webSocket = new MarketDataWebSocket("btcusdt@aggTrade");

            

            JObject test;
            object test2;

            webSocket.OnMessageReceived(
                (data) =>
            {
                Console.WriteLine(data);

                test = JObject.Parse(data);
                test2 = JsonSerializer.Deserialize<JsonElement>(data);
                
                return Task.CompletedTask;
            }, CancellationToken.None);

            await webSocket.ConnectAsync(CancellationToken.None);
            
            
            for (int i = 0; i < 99; i++)
            {
                Console.WriteLine(i);
            }

            Task.Delay(1000);
        }

        //public async Task StartListeningAsync()
        //{
        //    await connection.StartAsync();

        //    connection.On<object>("receiveEvents", (message) =>
        //    {
        //        Console.WriteLine(message);
        //    });
        //}
    }
}

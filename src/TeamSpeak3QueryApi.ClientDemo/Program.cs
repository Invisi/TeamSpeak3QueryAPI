using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using TeamSpeak3QueryApi.Net.ClientQuery;
using TeamSpeak3QueryApi.Net.ClientQuery.Enum;
using TeamSpeak3QueryApi.Net.ClientQuery.Notifications;

namespace TeamSpeak3QueryApi.ClientDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            new Program().Run();

            while (true)
            {
                Thread.Sleep(100);
            }
        }

        private async void Run()
        {
            var loginData = File.ReadAllLines("..\\..\\..\\logindata.secret");

            var token = loginData[0].Trim();

            var rc = new TeamSpeakClient();
            await rc.Connect();
            await rc.Auth(token);

            await rc.RegisterNotification(Event.Any);

            var whoami = await rc.WhoAmI();
            Console.WriteLine($"I am client {whoami.ClientId} in channel {whoami.ChannelId}.");

            var selected = await rc.Use();
            Console.WriteLine($"Currently looking at connection {selected.ServerConnectionHandlerId}.");

            var serverVariable = await rc.GetServerVariable(ServerVariable.Name,
                ServerVariable.Platform,
                ServerVariable.Version,
                ServerVariable.Created,
                ServerVariable.CodecEncryptionMode,
                ServerVariable.DefaultServerGroup,
                ServerVariable.DefaultChannelGroup,
                ServerVariable.HostbannerUrl,
                ServerVariable.HostbannerGfxUrl,
                ServerVariable.HostbannerGfxInterval,
                ServerVariable.PrioritySpeakerDimmModificator,
                ServerVariable.Id,
                ServerVariable.HostbuttonTooltip,
                ServerVariable.HostbuttonUrl,
                ServerVariable.HostbuttonGfxUrl,
                ServerVariable.NamePhonetic,
                ServerVariable.IconId,
                ServerVariable.Ip,
                ServerVariable.AskForPrivilegekey,
                ServerVariable.HostbannerMode);
            Console.WriteLine($"My server is called {serverVariable.Name} running version {serverVariable.Version}.");

            var connections = await rc.GetConnectionList();
            Console.WriteLine($"I have {connections.Count} active connections.");

            var myChannel = await rc.GetChannelInfo(whoami.ChannelId);
            Console.WriteLine($"I am currently in channel {myChannel.Path} on {serverVariable.Name}.");

            var channelClients = await rc.GetChannelClients(whoami.ChannelId);
            Console.WriteLine($"There are {channelClients.Count} users in my channel.");

            rc.Subscribe<CurrentServerConnectionChanged>(data =>
                Console.WriteLine($"Switched active connection to {data.First().ServerConnectionHandlerId}"));

            rc.Subscribe<TalkStatusChange>(data =>
            {
                var stuff = data.First();
                if (stuff.ServerConnectionHandlerId != selected.ServerConnectionHandlerId)
                {
                    return;
                }

                var clientName = channelClients.First(c => c.ClientId == stuff.Id).Name ?? $"Unknown {stuff.Id}";
                if (stuff.IsTalking)
                {
                    Console.WriteLine($"{serverVariable.Name}: {clientName} started talking");
                }
                else
                {
                    Console.WriteLine($"{serverVariable.Name}: {clientName} stopped talking");
                }
            });
        }
    }

    internal static class ReadOnlyCollectionExtensions
    {
        public static void ForEach<T>(this IReadOnlyCollection<T> collection, Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            foreach (var i in collection)
                action(i);
        }
    }
}

using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using ServerQueryClient = TeamSpeak3QueryApi.Net.QueryClient;

namespace TeamSpeak3QueryApi.Net.ClientQuery
{
    public class QueryClient : ServerQueryClient
    {
        private new string Host { get; }
        private new int Port { get; }
        private new TcpClient Client { get; }

        public QueryClient(string hostName, int port)
        {
            if (string.IsNullOrWhiteSpace(hostName))
                throw new ArgumentNullException(nameof(hostName));
            if (!ValidationHelper.ValidateTcpPort(port))
                throw new ArgumentOutOfRangeException(nameof(port));

            Host = hostName;
            Port = port;
            IsConnected = false;
            Client = new TcpClient();
        }

        /// <summary>Connects to the ClientQuery server.</summary>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public new async Task<CancellationTokenSource> Connect()
        {
            await Client.ConnectAsync(Host, Port).ConfigureAwait(false);
            if (!Client.Connected)
                throw new InvalidOperationException("Could not connect.");

            Ns = Client.GetStream();
            Reader = new StreamReader(Ns);
            Writer = new StreamWriter(Ns) {NewLine = "\n"};

            IsConnected = true;

            await Reader.ReadLineAsync().ConfigureAwait(false);
            await Reader.ReadLineAsync().ConfigureAwait(false); // Ignore welcome message
            await Reader.ReadLineAsync().ConfigureAwait(false);

            await Reader.ReadLineAsync().ConfigureAwait(false);
            await Reader.ReadLineAsync().ConfigureAwait(false); // Ignore help info sent by ClientQuery plugin
            await Reader.ReadLineAsync().ConfigureAwait(false);
            await Reader.ReadLineAsync().ConfigureAwait(false); // Ignore "selected schandlerid=x"

            return ResponseProcessingLoop();
        }
    }
}

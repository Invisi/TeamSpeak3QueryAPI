using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSpeak3QueryApi.Net.Specialized.ClientEnum;
using TeamSpeak3QueryApi.Net.Specialized.Notifications;
using TeamSpeak3QueryApi.Net.Specialized.Responses;
using TeamSpeak3QueryApi.Net.Specialized.Responses.Client;

namespace TeamSpeak3QueryApi.Net.Specialized
{
    public class TeamSpeakClientQuery : IDisposable
    {
        private readonly List<Tuple<Event, object, Action<NotificationData>>> _callbacks = new();

        public ClientQueryClient Client { get; }

        /// <summary>Creates a new instance of <see cref="TeamSpeakClientQuery"/> for localhost.</summary>
        public TeamSpeakClientQuery()
        {
            Client = new ClientQueryClient("127.0.0.1", 25638);
            // TODO: Change to 25639
        }

        public Task Connect() => Client.Connect();

        public Task Auth(string token)
        {
            return Client.Send("auth", new Parameter("apikey", token));
        }

        public Task<IReadOnlyList<ServerConnectionHandlerList>> GetConnectionList() =>
            GetMany<ServerConnectionHandlerList>();

        public Task<WhoAmI> WhoAmI() => Get<WhoAmI>();
        public Task<Use> Use() => Get<Use>();
        public Task<Use> Use(int scHandlerId) => Get<Use>(new Parameter("schandlerid", scHandlerId));

        public Task<ChannelConnectInfo> GetChannelInfo(int channelId) =>
            Get<ChannelConnectInfo>(new Parameter("cid", channelId));

        public Task<IReadOnlyList<ChannelClientList>> GetChannelClients(int channelId) =>
            GetMany<ChannelClientList>(new Parameter("cid", channelId));


        public Task<Responses.Client.ServerVariable> GetServerVariable(
            params ClientEnum.ServerVariable[] variables)
        {
            var parameters = variables.Select(v =>
                new Parameter(
                    "virtualserver_" + string.Concat(
                        v.ToString().Select(
                            (x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()
                        )
                    ).ToLowerInvariant(),
                    ""
                )
            ).ToArray();

            return Get<Responses.Client.ServerVariable>(parameters);
        }

        #region Subscriptions

        public void Subscribe<T>(Action<IReadOnlyCollection<T>> callback)
            where T : Notification
        {
            var notification = GetNotificationType<T>();

            Action<NotificationData> cb = data => callback(DataProxy.SerializeGeneric<T>(data.Payload));

            _callbacks.Add(Tuple.Create(notification, callback as object, cb));
            Client.Subscribe(notification.ToString(), cb);
        }

        public void Unsubscribe<T>()
            where T : Notification
        {
            var notification = GetNotificationType<T>();
            var cbts = _callbacks.Where(tp => tp.Item1 == notification).ToList();
            cbts.ForEach(k => _callbacks.Remove(k));
            Client.Unsubscribe(notification.ToString());
        }

        public void Unsubscribe<T>(Action<IReadOnlyCollection<T>> callback)
            where T : Notification
        {
            var notification = GetNotificationType<T>();
            var cbt = _callbacks.SingleOrDefault(t => t.Item1 == notification && t.Item2 == callback as object);
            if (cbt != null)
                Client.Unsubscribe(notification.ToString(), cbt.Item3);
        }

        private static Event GetNotificationType<T>()
        {
            if (!Enum.TryParse(typeof(T).Name, out Event notification)
            ) // This may violate the generic pattern. May change this later.
                throw new ArgumentException(
                    "The specified generic parameter is not a supported NotificationType."); // For this time, we only support class-internal types which are listed in NotificationType
            return notification;
        }

        #endregion

        /// <summary>
        /// Register via clientnotifyregister. By default all current connections are subscribed.
        /// </summary>
        /// <param name="eventName">The subscribed event. Use ClientQueryEvent.Any to subscribe to everything</param>
        /// <param name="serverConnectionHandlerId">Which connectionHandlerId to subscribe to. 0 = all</param>
        /// <returns>QueryResponseDictionary[]</returns>
        public Task RegisterNotification(Event eventName, int serverConnectionHandlerId = 0)
        {
            return Client.Send(
                "clientnotifyregister",
                new Parameter("schandlerid", serverConnectionHandlerId),
                new Parameter("event", eventName.ToString().ToLowerInvariant())
            );
        }

        #region Get/GetMany

        private Task<T> Get<T>(params Parameter[] parameters) where T : Response
        {
            return Get<T>(parameters, null);
        }

        private async Task<T> Get<T>(Parameter[] parameters, string[] options) where T : Response
        {
            var res = await Client.Send(typeof(T).Name.ToLower(), parameters, options).ConfigureAwait(false);
            var proxied = DataProxy.SerializeGeneric<T>(res);
            return proxied.FirstOrDefault();
        }

        private Task<IReadOnlyList<T>> GetMany<T>() where T : Response => GetMany<T>(null);

        private Task<IReadOnlyList<T>> GetMany<T>(params Parameter[] parameters) where T : Response =>
            GetMany<T>(parameters, null);

        private async Task<IReadOnlyList<T>> GetMany<T>(Parameter[] parameters, string[] options)
            where T : Response
        {
            var res = await Client.Send(typeof(T).Name.ToLower(), parameters, options).ConfigureAwait(false);
            return DataProxy.SerializeGeneric<T>(res);
        }

        #endregion

        #region IDisposable support

        /// <summary>Finalizes the object.</summary>
        ~TeamSpeakClientQuery()
        {
            Dispose(false);
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <param name="disposing">A value indicating whether the object is disposing or finalizing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Client?.Dispose();
            }
        }

        #endregion
    }
}

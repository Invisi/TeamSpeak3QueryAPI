namespace TeamSpeak3QueryApi.Net.Specialized.Notifications.Client
{
    public class CurrentServerConnectionChanged: Notification
    {
        [QuerySerialize("schandlerid")]
        public int ServerConnectionHandlerId;
    }
}

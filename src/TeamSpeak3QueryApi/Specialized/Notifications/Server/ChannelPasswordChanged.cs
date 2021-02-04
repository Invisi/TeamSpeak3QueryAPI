namespace TeamSpeak3QueryApi.Net.Specialized.Notifications.Server
{
    public class ChannelPasswordChanged : Notification
    {
        [QuerySerialize("cid")]
        public int ChannelId;
    }
}

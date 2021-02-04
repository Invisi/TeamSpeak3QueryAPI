namespace TeamSpeak3QueryApi.Net.Specialized.Notifications.Server
{
    public class ChannelDescriptionChanged : Notification
    {
        [QuerySerialize("cid")]
        public int ChannelId;
    }
}

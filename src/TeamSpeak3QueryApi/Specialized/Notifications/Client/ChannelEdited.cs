namespace TeamSpeak3QueryApi.Net.Specialized.Notifications.Client
{
    public class ChannelEdited : Notification
    {
        [QuerySerialize("cid")]
        public int ChannelId;
    }
}

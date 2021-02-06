using TeamSpeak3QueryApi.Net.Specialized;
using TeamSpeak3QueryApi.Net.Specialized.Notifications;

namespace TeamSpeak3QueryApi.Net.ClientQuery.Notifications
{
    public class ChannelEdited : Notification
    {
        [QuerySerialize("cid")]
        public int ChannelId;
    }
}

namespace TeamSpeak3QueryApi.Net.Specialized.Notifications.Client
{
    public class TalkStatusChange : Notification
    {
        [QuerySerialize("schandlerid")]
        public int ServerConnectionHandlerId;

        [QuerySerialize("status")]
        public bool IsTalking;

        [QuerySerialize("isreceivedwhisper")]
        public bool IsWhisper;

        [QuerySerialize("clid")]
        public int Id;
    }
}

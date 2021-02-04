namespace TeamSpeak3QueryApi.Net.Specialized.Notifications.Server
{
    public class ClientMoved : InvokerInformation
    {
        [QuerySerialize("ctid")]
        public int TargetChannel;

        [QuerySerialize("clid")]
        public int[] ClientIds;
    }
}

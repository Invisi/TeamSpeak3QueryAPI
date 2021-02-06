namespace TeamSpeak3QueryApi.Net.Specialized.Responses.Client
{
    public class WhoAmI : Response
    {
        [QuerySerialize("clid")]
        public int ClientId;

        [QuerySerialize("cid")]
        public int ChannelId;
    }
}

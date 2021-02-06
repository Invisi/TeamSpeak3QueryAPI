namespace TeamSpeak3QueryApi.Net.Specialized.Responses.Client
{
    public class ChannelConnectInfo : Response
    {
        [QuerySerialize("path")]
        public string Path;
    }
}

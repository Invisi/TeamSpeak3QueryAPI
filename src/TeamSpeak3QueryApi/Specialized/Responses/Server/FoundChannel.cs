namespace TeamSpeak3QueryApi.Net.Specialized.Responses.Server
{
    public class FoundChannel : Response
    {
        [QuerySerialize("cid")]
        public int Id;

        [QuerySerialize("channel_name")]
        public string Name;
    }
}

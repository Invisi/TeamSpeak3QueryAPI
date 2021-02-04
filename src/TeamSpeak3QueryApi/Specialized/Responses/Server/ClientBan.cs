namespace TeamSpeak3QueryApi.Net.Specialized.Responses.Server
{
    public class ClientBan : Response
    {
        [QuerySerialize("banid")]
        public int Id;
    }
}

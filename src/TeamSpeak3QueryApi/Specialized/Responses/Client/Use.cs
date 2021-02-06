namespace TeamSpeak3QueryApi.Net.Specialized.Responses.Client
{
    public class Use : Response
    {
        [QuerySerialize("schandlerid")]
        public int ServerConnectionHandlerId;
    }
}

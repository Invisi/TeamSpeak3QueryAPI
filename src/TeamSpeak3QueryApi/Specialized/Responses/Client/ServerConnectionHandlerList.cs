namespace TeamSpeak3QueryApi.Net.Specialized.Responses.Client
{
    public class ServerConnectionHandlerList : Response
    {
        [QuerySerialize("schandlerid")]
        public int ServerConnectionHandlerId;
    }
}

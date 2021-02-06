using TeamSpeak3QueryApi.Net.Specialized;
using TeamSpeak3QueryApi.Net.Specialized.Responses;

namespace TeamSpeak3QueryApi.Net.ClientQuery.Responses
{
    public class ServerConnectionHandlerList : Response
    {
        [QuerySerialize("schandlerid")]
        public int ServerConnectionHandlerId;
    }
}

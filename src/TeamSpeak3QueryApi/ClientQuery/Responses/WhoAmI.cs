using TeamSpeak3QueryApi.Net.Specialized;
using TeamSpeak3QueryApi.Net.Specialized.Responses;

namespace TeamSpeak3QueryApi.Net.ClientQuery.Responses
{
    public class WhoAmI : Response
    {
        [QuerySerialize("clid")]
        public int ClientId;

        [QuerySerialize("cid")]
        public int ChannelId;
    }
}

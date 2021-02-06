namespace TeamSpeak3QueryApi.Net.Specialized.Responses.Client
{
    public class ChannelClientList : Response
    {
        [QuerySerialize("clid")]
        public int ClientId;

        [QuerySerialize("cid")]
        public int ChannelId;

        [QuerySerialize("client_database_id")]
        public int ClientDbId;

        [QuerySerialize("client_nickname")]
        public string Name;

        [QuerySerialize("client_type")]
        public ClientType Type;

        [QuerySerialize("client_input_muted")]
        public bool InputMuted;

        [QuerySerialize("client_output_muted")]
        public bool OutputMuted;
    }
}

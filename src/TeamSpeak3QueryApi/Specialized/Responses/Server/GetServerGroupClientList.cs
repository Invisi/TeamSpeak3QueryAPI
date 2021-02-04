namespace TeamSpeak3QueryApi.Net.Specialized.Responses.Server
{
    public class GetServerGroupClientList : Response
    {
        [QuerySerialize("cldbid")]
        public int ClientDatabaseId;
    }
}

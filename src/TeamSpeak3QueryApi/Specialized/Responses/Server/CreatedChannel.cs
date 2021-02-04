namespace TeamSpeak3QueryApi.Net.Specialized.Responses.Server
{
    public class CreatedChannel : Response
    {
        [QuerySerialize("cid")]
        public int Id;
    }
}

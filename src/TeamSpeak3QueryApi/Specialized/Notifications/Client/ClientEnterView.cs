
namespace TeamSpeak3QueryApi.Net.Specialized.Notifications.Client
{
    public class ClientEnterView : Notification
    {
        [QuerySerialize("schandlerid")]
        public int ServerConnectionHandlerId;

        [QuerySerialize("client_myteamspeak_id")]
        public object MyTeamspeakId; // TODO: Unknown value/type

        [QuerySerialize("client_integrations")]
        public object ClientIntegrations; // TODO: Unknown value, might be related to Twitch?

        [QuerySerialize("client_myteamspeak_avatar")]
        public object ClientMyTeamspeakAvatar;

        [QuerySerialize("client_signed_badges")]
        public object ClientSignedBadges; // TODO: Might be related to faked badges
    }
}

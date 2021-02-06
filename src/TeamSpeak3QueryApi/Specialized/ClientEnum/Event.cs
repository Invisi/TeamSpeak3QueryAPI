namespace TeamSpeak3QueryApi.Net.Specialized.ClientEnum
{
    public enum Event
    {
        // ALL events
        Any,

        // Updates for lists?
        BanList,
        ComplainList,

        // Channels
        ChannelCreated,
        ChannelDeleted,
        ChannelEdited,
        ChannelMoved,

        // Chat?
        ClientChatClosed,
        ClientChatComposing,

        // Client info
        ClientIds,
        ClientDbIdFromUid,
        ClientNameFromDbId,
        ClientNameFromUid,
        ClientUidFromClId,
        ClientUpdated,

        // Leave/join events
        ClientEnterView,
        ClientLeftView,
        ClientMoved,

        // Message-related
        Message,
        MessageList,
        ClientPoke,
        TextMessage,

        // Server connection
        ConnectionInfo,
        ConnectStatusChange,
        CurrentServerConnectionChanged,

        // Server
        ServerEdited,
        ServerUpdated,

        // Clients speaking
        TalkStatusChange,
    }
}

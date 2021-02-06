using System;

namespace TeamSpeak3QueryApi.Net.Specialized.Responses.Client
{
    public class ServerVariable : Response
    {
        [QuerySerialize("virtualserver_name")]
        public string Name;

        [QuerySerialize("virtualserver_platform")]
        public string Platform;

        [QuerySerialize("virtualserver_version")]
        public string Version;

        [QuerySerialize("virtualserver_created")]
        public int Created;

        [QuerySerialize("virtualserver_codec_encryption_mode")]
        public bool CodecEncryptionMode;

        [QuerySerialize("virtualserver_default_server_group")]
        public int DefaultServerGroup;

        [QuerySerialize("virtualserver_default_channel_group")]
        public int DefaultChannelGroup;

        [QuerySerialize("virtualserver_hostbanner_url")]
        public string HostbannerUrl;

        [QuerySerialize("virtualserver_hostbanner_gfx_url")]
        public string HostbannerGfxUrl;

        [QuerySerialize("virtualserver_hostbanner_gfx_interval")]
        public int HostbannerGfxInterval;

        [QuerySerialize("virtualserver_priority_speaker_dimm_modificator")]
        public Double PrioritySpeakerDimmModificator;

        [QuerySerialize("virtualserver_id")]
        public int Id;

        [QuerySerialize("virtualserver_hostbutton_tooltip")]
        public string HostbuttonTooltip;

        [QuerySerialize("virtualserver_hostbutton_url")]
        public string HostbuttonUrl;

        [QuerySerialize("virtualserver_hostbutton_gfx_url")]
        public string HostbuttonGfxUrl;

        [QuerySerialize("virtualserver_name_phonetic")]
        public string NamePhonetic;

        [QuerySerialize("virtualserver_icon_id")]
        public int IconId;

        [QuerySerialize("virtualserver_ip")]
        public string Ip;

        [QuerySerialize("virtualserver_ask_for_privilegekey")]
        public bool AskForPrivilegekey;

        [QuerySerialize("virtualserver_hostbanner_mode")]
        public int HostbannerMode;

        // Unsupported as of 2021-02-03

        // [QuerySerialize("virtualserver_clientsonline")]
        // public string Clientsonline;
        //
        // [QuerySerialize("virtualserver_channelsonline")]
        // public string Channelsonline;
        //
        // [QuerySerialize("virtualserver_uptime")]
        // public string Uptime;
        //
        // [QuerySerialize("virtualserver_flag_password")]
        // public string FlagPassword;
        //
        // [QuerySerialize("virtualserver_default_channel_admin_group")]
        // public string DefaultChannelAdminGroup;
        //
        // [QuerySerialize("virtualserver_max_download_total_bandwidth")]
        // public string MaxDownloadTotalBandwidth;
        //
        // [QuerySerialize("virtualserver_max_upload_total_bandwidth")]
        // public string MaxUploadTotalBandwidth;
        //
        // [QuerySerialize("virtualserver_complain_autoban_count")]
        // public string ComplainAutobanCount;
        //
        // [QuerySerialize("virtualserver_complain_autoban_time")]
        // public string ComplainAutobanTime;
        //
        // [QuerySerialize("virtualserver_complain_remove_time")]
        // public string ComplainRemoveTime;
        //
        // [QuerySerialize("virtualserver_min_clients_in_channel_before_forced_silence")]
        // public string MinClientsInChannelBeforeForcedSilence;
        //
        // [QuerySerialize("virtualserver_antiflood_points_tick_reduce")]
        // public string AntifloodPointsTickReduce;
        //
        // [QuerySerialize("virtualserver_antiflood_points_needed_command_block")]
        // public string AntifloodPointsNeededCommandBlock;
        //
        // [QuerySerialize("virtualserver_antiflood_points_needed_ip_block")]
        // public string AntifloodPointsNeededIpBlock;
        //
        // [QuerySerialize("virtualserver_client_connections")]
        // public string ClientConnections;
        //
        // [QuerySerialize("virtualserver_query_client_connections")]
        // public string QueryClientConnections;
        //
        // [QuerySerialize("virtualserver_queryclientsonline")]
        // public string Queryclientsonline;
        //
        // [QuerySerialize("virtualserver_download_quota")]
        // public string DownloadQuota;
        //
        // [QuerySerialize("virtualserver_upload_quota")]
        // public string UploadQuota;
        //
        // [QuerySerialize("virtualserver_month_bytes_downloaded")]
        // public string MonthBytesDownloaded;
        //
        // [QuerySerialize("virtualserver_month_bytes_uploaded")]
        // public string MonthBytesUploaded;
        //
        // [QuerySerialize("virtualserver_total_bytes_downloaded")]
        // public string TotalBytesDownloaded;
        //
        // [QuerySerialize("virtualserver_total_bytes_uploaded")]
        // public string TotalBytesUploaded;
        //
        // [QuerySerialize("virtualserver_port")]
        // public string Port;
        //
        // [QuerySerialize("virtualserver_autostart")]
        // public string Autostart;
        //
        // [QuerySerialize("virtualserver_machine_id")]
        // public string MachineId;
        //
        // [QuerySerialize("virtualserver_needed_identity_security_level")]
        // public string NeededIdentitySecurityLevel;
        //
        // [QuerySerialize("virtualserver_log_client")]
        // public string LogClient;
        //
        // [QuerySerialize("virtualserver_log_query")]
        // public string LogQuery;
        //
        // [QuerySerialize("virtualserver_log_channel")]
        // public string LogChannel;
        //
        // [QuerySerialize("virtualserver_log_permissions")]
        // public string LogPermissions;
        //
        // [QuerySerialize("virtualserver_log_server")]
        // public string LogServer;
        //
        // [QuerySerialize("virtualserver_log_filetransfer")]
        // public string LogFiletransfer;
        //
        // [QuerySerialize("virtualserver_min_client_version")]
        // public string MinClientVersion;
        //
        // [QuerySerialize("virtualserver_reserved_slots")]
        // public string ReservedSlots;
        //
        // [QuerySerialize("virtualserver_total_packetloss_speech")]
        // public string TotalPacketlossSpeech;
        //
        // [QuerySerialize("virtualserver_total_packetloss_keepalive")]
        // public string TotalPacketlossKeepalive;
        //
        // [QuerySerialize("virtualserver_total_packetloss_control")]
        // public string TotalPacketlossControl;
        //
        // [QuerySerialize("virtualserver_total_packetloss_total")]
        // public string TotalPacketlossTotal;
        //
        // [QuerySerialize("virtualserver_total_ping")]
        // public string TotalPing;
        //
        // [QuerySerialize("virtualserver_weblist_enabled")]
        // public string WeblistEnabled;
    }
}

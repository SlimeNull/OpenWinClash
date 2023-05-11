namespace OpenWinClash.Models.Clash.Api
{
    internal class ClashOptionalBasicConfig
    {
        public int? Port { get; set; }
        public int? SocketPort { get; set; }

        public int? RedirPort { get; set; }
        public bool? AllowLan { get; set; }

        public ClashRouterMode? Mode { get; set; }
        public ClashLogLevel? LogLevel { get; set;}
    }
}

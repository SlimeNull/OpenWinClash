using System.Collections.Generic;

namespace OpenWinClash.Models.Clash.Configuration
{
    public class ClashShadowsocksProxyV2rayPluginOptions : ClashShadowsocksProxyPluginOptions
    {
        public ClashShadowsocksProxyV2rayPluginOptionsMode Mode { get; set; } = ClashShadowsocksProxyV2rayPluginOptionsMode.Websocket;
        public bool? Tls { get; set; }
        public bool SkipCertVerify { get; set; }
        public string? Host { get; set; }
        public string? Path { get; set; }
        public bool? Mux { get; set; }
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
    }
}
namespace OpenWinClash.Models.Clash.Configuration
{
    public class ClashShadowsocksProxyObfsPluginOptions : ClashShadowsocksProxyPluginOptions
    {
        public ClashShadowsocksProxyObfsPluginOptionsMode Mode { get; set; } = ClashShadowsocksProxyObfsPluginOptionsMode.Tls;   // or http
        public string? Host { get; set; } = null;   // bing.com
    }
}
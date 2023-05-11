namespace OpenWinClash.Models.Clash.Configuration
{
    public class ClashShadowsocksProxyWithObfsPlugin : ClashShadowsocksProxyWithPlugin
    {
        public override ClashShadowsocksProxyPluginType Plugin => ClashShadowsocksProxyPluginType.Obfs;
        public ClashShadowsocksProxyObfsPluginOptions PluginOpts { get; set; } = new ClashShadowsocksProxyObfsPluginOptions();
    }
}
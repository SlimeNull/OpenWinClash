namespace OpenWinClash.Models.Clash.Configuration
{
    public class ClashShadowsocksProxyWithV2rayPlugin : ClashShadowsocksProxyWithPlugin
    {
        public override ClashShadowsocksProxyPluginType Plugin => ClashShadowsocksProxyPluginType.V2rayPlugin;
        public ClashShadowsocksProxyV2rayPluginOptions PluginOpts { get; set; } = new ClashShadowsocksProxyV2rayPluginOptions();
    }
}
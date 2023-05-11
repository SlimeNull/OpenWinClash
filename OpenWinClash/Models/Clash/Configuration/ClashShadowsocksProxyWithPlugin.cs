namespace OpenWinClash.Models.Clash.Configuration
{
    public abstract class ClashShadowsocksProxyWithPlugin : ClashShadowsocksProxy
    {
        public abstract ClashShadowsocksProxyPluginType Plugin { get; } 
    }
}
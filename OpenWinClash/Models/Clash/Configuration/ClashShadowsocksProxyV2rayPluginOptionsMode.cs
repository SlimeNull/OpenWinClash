using System.Runtime.Serialization;

namespace OpenWinClash.Models.Clash.Configuration
{
    public enum ClashShadowsocksProxyV2rayPluginOptionsMode
    {
        Websocket,
        [EnumMember(Value = "QUIC")]
        QUIC
    }
}
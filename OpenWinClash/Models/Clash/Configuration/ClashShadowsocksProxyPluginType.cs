using System.Runtime.Serialization;

namespace OpenWinClash.Models.Clash.Configuration
{
    public enum ClashShadowsocksProxyPluginType
    {
        [EnumMember(Value = "obfs")]
        Obfs,
        [EnumMember(Value = "v2ray-plugin")]
        V2rayPlugin,
    }
}
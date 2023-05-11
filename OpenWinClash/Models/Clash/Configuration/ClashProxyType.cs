using System.Runtime.Serialization;
using YamlDotNet.Serialization;

namespace OpenWinClash.Models.Clash.Configuration
{
    public enum ClashProxyType
    {
        [EnumMember(Value = "ss")]
        Shadowsocks,
        [EnumMember(Value = "vmess")]
        VMess,
        [EnumMember(Value = "socks5")]
        Socks5,
        [EnumMember(Value = "http")]
        Http,
        [EnumMember(Value = "snell")]
        Snell,
        [EnumMember(Value = "trojan")]
        Trojan,
        [EnumMember(Value = "ssr")]
        ShadowsocksR
    }
}
using System.Collections.Generic;
using System.Runtime.Serialization;
using YamlDotNet.Serialization;

namespace OpenWinClash.Models.Clash.Configuration
{
    public abstract class ClashProxy
    {
        public abstract ClashProxyType Type { get; }

        public string Name { get; set; } = string.Empty;
        public string Server { get; set; } = "server";
        public int Port { get; set; } = 443;
    }

    public abstract class ClashVMessProxy : ClashProxy
    {
        public override ClashProxyType Type => ClashProxyType.VMess;

        [YamlMember(Alias = "alterId")]
        public int AlterId { get; set; } = 32;
        public string Cipher { get; set; } = "auto";
        public bool? Udp { get; set; }
        public bool? Tls { get; set; }
        public bool? SkipCertVerify { get; set; }

        [YamlMember(Alias = "servername")]
        public string? ServerName { get; set; }

        public abstract ClashVMessProxyNetworkType Network { get; }
    }

    public enum ClashVMessProxyNetworkType
    {
        [EnumMember(Value = "ws")]
        Websocket,

        [EnumMember(Value = "h2")]
        H2,

        [EnumMember(Value = "http")]
        Http
    }

    public class ClashVMessHttpProxy : ClashVMessProxy
    {
        public override ClashVMessProxyNetworkType Network => ClashVMessProxyNetworkType.Http;
    }

    public abstract class ClashVMessProxyNetworkOptions
    {

    }

    public class ClashVMessWebsocketOptions
    {
        public string Path { get; set; } = "/";   // /path
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public int MaxEarlyData { get; set; } = 2048;
        public string EarlyDataHeaderName { get; set; } = "Sec-WebSocket-Protocol";
    }

    public class ClashVMessHttpOptions
    {
        public string Method { get; set; } = "GET";
        public List<string> Path { get; set; } = new List<string>()
        {
            "/"
        };

        //public 
    }
}
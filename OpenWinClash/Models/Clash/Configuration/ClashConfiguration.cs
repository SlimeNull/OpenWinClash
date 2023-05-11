using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWinClash.Models.Clash.Configuration
{
    /// <summary>
    /// Clash configuration. (https://github.com/Dreamacro/clash/wiki/configuration)
    /// </summary>
    public record class ClashConfiguration
    {
        /// <summary>
        /// Port of HTTP(S) proxy server on the local end
        /// </summary>
        public int Port { get; set; } = 7890;


        /// <summary>
        /// Port of SOCKS5 proxy server on the local end
        /// </summary>
        public int SocksPort { get; set; } = 7891;


        /// <summary>
        /// Transparent proxy server port for Linux and macOS (Redirect TCP and TProxy UDP) (default: 7892)
        /// </summary>
        public int? RedirPort { get; set; } = null;


        /// <summary>
        /// Transparent proxy server port for Linux (TProxy TCP and TProxy UDP) (default: 7893)
        /// </summary>
        public int? TproxyPort { get; set; } = 7893;


        /// <summary>
        /// HTTP(S) and SOCKS4(A)/SOCKS5 server on the same port (default: 7890)
        /// </summary>
        public int? MixedPort { get; set; } = 7890;


        /// <summary>
        /// authentication of local SOCKS5/HTTP(S) server
        /// </summary>
        public List<ClashAuthenticationItem>? Authentication { get; set; }


        /// <summary>
        /// Set to true to allow connections to the local-end server from other LAN IP addresses (default: false)
        /// </summary>
        public bool? AllowLan { get; set; } = false;


        /// <summary>
        /// This is only applicable when `allow-lan` is `true`
        /// '*': bind all IP addresses
        /// 192.168.122.11: bind a single IPv4 address
        /// "[aaaa::a8aa:ff:fe09:57d8]": bind a single IPv6 address (default: *)
        /// </summary>
        public string? BindAddress { get; set; } = null;


        /// <summary>
        /// Clash router working mode
        /// </summary>
        public ClashRouterMode Mode { get; set; } = ClashRouterMode.Rule;


        /// <summary>
        /// Clash by default prints logs to STDOUT (default: info)
        /// </summary>
        public ClashLogLevel? LogLevel { get; set; } = null;


        /// <summary>
        /// When set to false, resolver won't translate hostnames to IPv6 addresses (default: false)
        /// </summary>
        public bool? Ipv6 { get; set; } = null;


        /// <summary>
        /// RESTful web API listening address
        /// </summary>
        public string ExternalController { get; set; } = "127.0.0.1:9090";


        /// <summary>
        /// A relative path to the configuration directory or an absolute path to a
        /// directory in which you put some static web resource. Clash core will then
        /// serve it at `http://{{external-controller}}/ui`. (default: folder)
        /// </summary>
        public string? ExternalUi { get; set; } = null;


        /// <summary>
        /// Secret for the RESTful API (optional)
        /// Authenticate by spedifying HTTP header `Authorization: Bearer ${secret}`
        /// ALWAYS set a secret if RESTful API is listening on 0.0.0.0 (default: emptry string)
        /// </summary>
        public string? Secret { get; set; } = null;


        /// <summary>
        /// Outbound interface name (default: en0)
        /// </summary>
        public string? InterfaceName { get; set; } = null;


        /// <summary>
        /// fwmark on Linux only (default: "6666")
        /// </summary>
        public string? RoutingMark { get; set; } = null;


        /// <summary>
        /// Static hosts for DNS server and connection establishment (like /etc/hosts)
        /// 
        /// Wildcard hostnames are supported (e.g. *.clash.dev, *.foo.*.example.com)
        /// Non-wildcard domain names have a higher priority than wildcard domain names
        /// e.g. foo.example.com > *.example.com > .example.com
        /// P.S. +.foo.com equals to .foo.com and foo.com
        /// </summary>
        public Dictionary<string, string> Hosts { get; } = new();

        /// <summary>
        /// 
        /// </summary>
        public ClashProfile Profile { get; set; } = new();

        public ClashDnsOptions Dns { get; set; } = new();

        public List<ClashProxy> Proxies { get; set; } = new List<ClashProxy>();
    }
}

using System.Collections.Generic;

namespace OpenWinClash.Models.Clash.Configuration
{
    /// <summary>
    /// DNS server settings
    /// This section is optional. When not present, the DNS server will be disabled.
    /// </summary>
    public class ClashDnsOptions
    {
        public bool Enable { get; set; } = false;

        public string Listen { get; set; } = "0.0.0.0:53";

        /// <summary>
        /// when the false, response to AAAA questions will be empty (default: false)
        /// </summary>
        public bool? Ipv6 { get; set; } = null;

        /// <summary>
        /// These nameservers are used to resolve the DNS nameserver hostnames below.
        /// Specify IP addresses only
        /// </summary>
        public List<string> DefaultNameserver { get; set; } = new List<string>();

        /// <summary>
        /// (default: fake-ip)
        /// </summary>
        public ClashEnhancedMode? EnhancedMode { get; set; } = null;

        /// <summary>
        /// Fake IP addresses pool CIDR (default: '198.18.0.1/16')
        /// </summary>
        public string? FakeIpRange = null;

        /// <summary>
        /// lookup hosts and return IP record (default: true)
        /// </summary>
        public bool? UseHosts = null;

        /// <summary>
        /// Hostnames in this list will not be resolved with fake IPs
        /// i.e. questions to these domain names will always be answered with their
        /// real IP addresses
        /// </summary>
        public List<string>? FakeIpFilter { get; set; }

        /// <summary>
        /// Supports UDP, TCP, DoT, DoH. You can specify the port to connect to.
        /// All DNS questions are sent directly to the nameserver, without proxies
        /// involved. Clash answers the DNS question with the first result gathered.
        /// </summary>
        public List<string> Nameserver { get; set; } = new List<string>()
        {
            "114.114.114.114",
            "8.8.8.8",
            "tls://dns.rubyfish.cn:853",
            "https://1.1.1.1/dns-query",
            "dhcp://en0"
            // "8.8.8.8#en0"
        };

        /// <summary>
        /// When `fallback` is present, the DNS server will send concurrent requests
        /// to the servers in this section along with servers in `nameservers`.
        /// The answers from fallback servers are used when the GEOIP country
        /// is not `CN`.
        /// </summary>
        public List<string>? Fallback { get; set; }

        public ClashDnsFallbackFilterOptions FallbackFilter { get; set; } 
            = new ClashDnsFallbackFilterOptions();

        public Dictionary<string, string>? NameserverPolicy { get; set; }
    }
}
using System.Collections.Generic;
using System.Windows.Documents;

namespace OpenWinClash.Models.Clash.Configuration
{
    public class ClashDnsFallbackFilterOptions
    {
        public bool Geoip { get; set; } = true;
        public string GeoipCode { get; set; } = "CN";

        public List<string> Ipcidr { get; } = new List<string>()
        {
            "240.0.0.0/4"
        };

        public List<string> Domain { get; } = new List<string>()
        {
            "+.google.com",
            "+.facebook.com",
            "+.youtube.com"
        };
    }
}
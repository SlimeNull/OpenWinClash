using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWinClash.Models.Clash.Api
{
    internal class ClashBasicConfiguration
    {
        public int Port { get; set; } = 7890;
        public int SocketPort { get; set; } = 7891;

        public int RedirPort { get; set; } = 0;
        public bool AllowLan { get; set; } = true;
        public ClashRouterMode Mode { get; set; } = ClashRouterMode.Rule;
        public ClashLogLevel LogLevel { get; set; } = ClashLogLevel.Info;
    }
}

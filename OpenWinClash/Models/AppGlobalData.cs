using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using OpenWinClash.Models.Clash.Configuration;

namespace OpenWinClash.Models
{
    [ObservableObject]
    public partial class AppGlobalData
    {
        [ObservableProperty]
        private ClashConfiguration? clashConfiguration;

        [ObservableProperty]
        private Bandwidth uploadBandwidth = new Bandwidth();

        [ObservableProperty]
        private Bandwidth downloadBandwidth = new Bandwidth();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using OpenWinClash.Utilities;

namespace OpenWinClash.Models
{
    [ObservableObject]
    public partial class Bandwidth
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(
            nameof(KiloSpeed),
            nameof(MegaSpeed),
            nameof(GigaSpeed),
            nameof(TeraSpeed),
            nameof(SuitableSpeed),
            nameof(SuitableUnit))]
        private long speed;

        public float KiloSpeed => FileSizeUtils.OfKilo(Speed);
        public float MegaSpeed => FileSizeUtils.OfMega(Speed);
        public float GigaSpeed => FileSizeUtils.OfGiga(Speed);
        public float TeraSpeed => FileSizeUtils.OfTera(Speed);

        public float SuitableSpeed
        {
            get
            {
                if (TeraSpeed > 1)
                    return TeraSpeed;
                if (GigaSpeed > 1)
                    return GigaSpeed;
                if (MegaSpeed > 1)
                    return MegaSpeed;
                if (KiloSpeed > 1)
                    return KiloSpeed;
                return Speed;
            }
        }

        public string SuitableUnit
        {
            get
            {
                if (TeraSpeed > 1)
                    return "TB/s";
                if (GigaSpeed > 1)
                    return "GB/s";
                if (MegaSpeed > 1)
                    return "MB/s";
                if (KiloSpeed > 1)
                    return "KB/s";
                return "B/s";
            }
        }
    }
}

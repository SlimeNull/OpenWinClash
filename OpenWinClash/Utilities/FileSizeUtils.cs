using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWinClash.Utilities
{
    internal static class FileSizeUtils
    {
        private static readonly long k = 1024;
        private static readonly float kf = 1024f;

        public static long Kilo(long n) => k * n;
        public static long Mega(long n) => k * Kilo(n);
        public static long Giga(long n) => k * Mega(n);
        public static long Tera(long n) => k * Giga(n);

        public static float OfKilo(float n) => n / kf;
        public static float OfMega(float n) => OfKilo(n) / kf;
        public static float OfGiga(float n) => OfMega(n) / kf;
        public static float OfTera(float n) => OfGiga(n) / kf;

    }
}

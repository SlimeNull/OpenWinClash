using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenWinClash.Utilities
{
    internal static class FileSystemUtils
    {
        public static string AppPath { get; } =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? AppDomain.CurrentDomain.BaseDirectory;

        public static string GetAppPath(string path)
        {
            return Path.Combine(AppPath, path);
        }
    }
}

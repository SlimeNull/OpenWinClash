using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Layouts;
using NLog.Targets;

namespace OpenWinClash.Utilities
{
    internal static class NLogSetup
    {
        public static string LoggingStorageDirectory { get; } =
            FileSystemUtils.GetAppPath("Logs");

        public static string LoggingFilename { get; } =
            "${longdate}.txt";

        public static string LoggingLayout { get; } =
            "${longdate} ${level:uppercase=true} ${logger} ${message:withexception=true}";

        public static string GetCurrentLogFilename()
        {
            return Path.Combine(LoggingStorageDirectory, LoggingFilename);
        }

        public static void Run()
        {
            LogManager.Setup()
                .LoadConfiguration(builder =>
                {
                    builder
                        .ForLogger()
                        .FilterMinLevel(LogLevel.Debug)
                        .WriteToFile(
                            fileName: GetCurrentLogFilename(),
                            layout  : LoggingLayout,
                            encoding: Encoding.UTF8,
                            keepFileOpen: true,
                            archiveAboveSize: FileSizeUtils.Mega(1),
                            maxArchiveDays: 5);
                });
        }
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace FilterBuilderUpdater {
    internal class Program {
        public static void Main(string[] args) {
            var processId = int.Parse(args[0]);
            var downloadPath = args[1];
            var releasePath = Path.Combine(Path.GetTempPath(), "filter_builder_release.zip");

            Console.WriteLine("Closing FilterBuilder process.");
            Process.GetProcessById(processId).Kill();
            Console.WriteLine("FilterBuilder process closed. Downloading update.");
            new WebClient().DownloadFile(downloadPath, releasePath);
            Console.WriteLine("Update downloaded. Removing old version.");
            foreach (var path in Directory.GetFileSystemEntries(Directory.GetCurrentDirectory())) {
                if (path.Contains("Updater")) continue;
                if (File.GetAttributes(path).HasFlag(FileAttributes.Directory)) {
                    Directory.Delete(path, true);
                }
                else {
                    File.Delete(path);
                }
            }
            Console.WriteLine("Old version removed. Extracting new version.");
            ZipFile.ExtractToDirectory(releasePath, Directory.GetCurrentDirectory());
            Console.WriteLine("New version installed. Restarting FilterBuilder.");
            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "FilterBuilder.exe"));
        }
    }
}
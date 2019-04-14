using System;
using System.Diagnostics;

namespace FilterBuilderUpdater {
    internal class Program {
        public static void Main(string[] args) {
            foreach (var arg in args) {
                Console.WriteLine(arg);
            }

            Console.WriteLine("Closing FilterBuilder process.");
            Process.GetProcessById(int.Parse(args[0])).Kill();
            Console.WriteLine("FilterBuilder process closed. Downloading update.");
            Environment.GetEnvironmentVariable("LocalAppData");
            
            var name = Console.ReadLine();
        }
    }
}
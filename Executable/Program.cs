using System;
using SDNLib;
using System.IO;
namespace Executable
{
    class Program
    {
        static void Main(string[] args)
        {
            var lib = new Plugins();
            var plugins = lib.Searcher();
            Console.WriteLine("Welcome to Shell Dot Net, version loaded is {0}", SDNLib.LibInfo.version);
            Console.WriteLine(Directory.GetCurrentDirectory());   

        }
    }
}

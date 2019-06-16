using System.Collections.Generic;
using SDNLib;
namespace Precompiler
{
    class Program
    {
        static void Main(string[] args)
        { var lib = new Plugins();
            var list = lib.Searcher("plugins");
            lib.CompileAll(list, "plugins");
        }
    }
}

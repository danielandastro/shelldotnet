using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
namespace SDNLib
{
    public class Plugins
    {
        /// <summary>
        /// Simple method, searches for plugins and spits out a list of them
        /// </summary>
        public  List<PluginData> Searcher(string path)
        {
            var pluginList = new List<PluginData>();//declare the list
            var temp = new PluginData();//store data before shifting to the list
            var files = Directory.GetFiles(path, "*.sdp");//read the files from the plugin folder
            foreach(string file in files)//process the files
            {
                temp.fileName = file;//filename storing
                temp.command = file.Replace(".sdp", "");//finds command by stripping extension from filename
                //TODO implement better metadata, and commands not limited to the filename
                pluginList.Add(temp);//add the data to the list
            }
            return pluginList;//return the data
        }
        /// <summary>
        /// This is the method you should implement to search the list
        ///  and return the required file for compilation
        /// </summary>
        public string search(string term, List<PluginData> listToSearch)
        {
            string path = "";
            foreach (var dataItem in listToSearch)
            {
                if (term.Contains(dataItem.command))
                {
                    path = dataItem.fileName;
                }
            }
            return path;
        }
        /// <summary>
        /// This is a really good tool for testing, or a really shit way to improve performance
        /// </summary>
        public void CompileAll(List<PluginData> catalog, string path)//a method to compile all known plugins in a catalog
        {
            #if DEBUG
            #warning This method may be used for testing, but should not be used in production
            #elif RELEASE
            #warning Please rethink this desision
            #endif
            foreach (var file in catalog)
            {
                var process = Process.Start("mcs", path + "/" + file.fileName);
                process.WaitForExit();
            }
            /*This is a really cheap and nasty way to improve performance on slower machines
             * It is stupid, probably unrequired if you implement half-decent caching
             * but it is there if required
             * But seriously, please do not use this
             */
        }
        public void CompileAll(string path)//a method to compile all known plugins in a catalog
        {
#if DEBUG
#warning This method may be used for testing, but should not be used in production
#elif RELEASE
#warning Please rethink this desision
#endif
            var catalog = Searcher(path);
            foreach (var file in catalog)
            {
                var process = Process.Start("mcs", path + "/" + file.fileName);
                process.WaitForExit();
            }
            /*This is a really cheap and nasty way to improve performance on slower machines
             * It is stupid, probably unrequired if you implement half-decent caching
             * but it is there if required
             * But seriously, please do not use this
             */
        }
    }
}
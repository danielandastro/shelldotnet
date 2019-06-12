using System;
using System.Collections.Generic;
using System.IO;
namespace SDNLib
{
    public class Plugins
    {
        public List<PluginData> Searcher(string path)
        {
            var pluginList = new List<PluginData>();//declare the list
            var temp = new PluginData;//store data before shifting to the list
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
    }
}
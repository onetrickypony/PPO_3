using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Controls;
using System.IO;
using System.Reflection;

namespace PPO_1.Plugins
{
    class PluginLoader
    {
        public List<IPlugin> LoadPlugins(string pluginFolder)
        {
            List<IPlugin> plugins = new List<IPlugin>();
            string[] assemblyNames = Directory.GetFiles(pluginFolder, "*.dll", SearchOption.AllDirectories);
            foreach (string fileName in assemblyNames)
            {
                Assembly assembly = Assembly.LoadFile(fileName);
                Type[] allPublicTypes = assembly.GetExportedTypes();
                foreach (Type type in allPublicTypes)
                    if (typeof(IPlugin).IsAssignableFrom(type))
                        plugins.Add((IPlugin)Activator.CreateInstance(type));
            }
            return plugins;
        }
    }
}

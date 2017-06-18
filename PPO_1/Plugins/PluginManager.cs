using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace PPO_1.Plugins
{
    class PluginManager
    {
        private ContextMenu groupmenu;
        private ContextMenu studentmenu;
        private TreeView treeView;

        public PluginManager(ContextMenu groupmenu, ContextMenu studentmenu, TreeView treeView)
        {
            this.groupmenu = groupmenu;
            this.studentmenu = studentmenu;
            this.treeView = treeView;
        }

        public void AddAction(IPlugin plugin)
        {
            AddtoContextMenu(plugin);
        }

        private void AddtoContextMenu(IPlugin plugin)
        {
            switch (plugin.application)
            {
                case "group":
                    AddItem(plugin, groupmenu);
                    break;
                case "student":
                    AddItem(plugin, studentmenu);
                    break;
                case "all":
                    AddItem(plugin, groupmenu);
                    AddItem(plugin, studentmenu);
                    break;
            }
        }

        private void AddItem(IPlugin plugin, ContextMenu menu)
        {
            MenuItem item = new MenuItem();
            item.Header = plugin.content;
            plugin.treeView = treeView;
            item.Click += plugin.Action;
            menu.Items.Add(item);
        }
        
    } 
}

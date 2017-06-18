using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPO_1.Plugins;
using System.Windows.Controls;
using System.Windows.Media;

namespace Plugin_1
{
    public class FPlugin : IPlugin
    {
        public TreeView treeView {get; set;}
        public string name { get { return "PrintColorPlugin"; } }
        public string application { get { return "all"; } }
        public string content { get { return "Выделить цветом"; } }
        public void Action(object source, EventArgs args)
        {
            TreeViewItem selectedItem = treeView.SelectedItem as TreeViewItem;
            
            if (selectedItem.Parent == treeView)
            {
                selectedItem.Foreground = Brushes.Green;
            }
            else
            {
                selectedItem.Foreground = Brushes.Blue;
            }
            
        }
    }
}

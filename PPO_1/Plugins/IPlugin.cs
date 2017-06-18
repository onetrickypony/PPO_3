using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPO_1.Plugins
{
    public interface IPlugin
    {
        TreeView treeView { get; set; }
        string name { get; }
        string application { get; }
        string content { get; }

        void Action(object source, EventArgs args);
    }
}

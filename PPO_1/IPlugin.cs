using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupsBase
{
    public delegate object PluginMethod(object arg);
    public enum plugin_output_type { message, file };
    public enum plugin_context_type { root, group, student, root_group, root_student, group_student, root_group_student};

    public struct plugin_descriptor
    {
        public plugin_output_type out_type;
        public plugin_context_type cont_type;
        public string plgn_name;
        public string plgn_text;
    }

    public interface IPlugin
    {
        object Work(object arg);
        plugin_descriptor Descriptor { get; }
    }
}

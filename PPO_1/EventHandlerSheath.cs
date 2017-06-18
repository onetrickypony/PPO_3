using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GroupsBase
{
    class EventHandlerSheath
    {
        PluginMethod plugin_method;
        plugin_descriptor descriptor;
        TreeView view;

        public EventHandlerSheath(IPlugin Plugin, TreeView tree)
        {
            plugin_method = Plugin.Work;
            descriptor = Plugin.Descriptor;
            view = tree;
        }

        public EventHandler GiveHandler
        {
            get { return EventHandlerMethod; }
        }

        private void EventHandlerMethod(object sender, EventArgs e)
        {
            try
            {
                plugin_context_type type_tag = (plugin_context_type)((ToolStripMenuItem)sender).Tag;

                StructureOfGroups main_data = StructureOfGroups.Instance;
                object result_of_work;

                switch (type_tag)
                {
                    case plugin_context_type.root:
                        result_of_work = plugin_method.Invoke(main_data);
                        break;
                    case plugin_context_type.group:
                        result_of_work = plugin_method.Invoke(main_data[view.SelectedNode.Text]);
                        break;
                    case plugin_context_type.student:
                        result_of_work = plugin_method.Invoke(main_data[view.SelectedNode.Parent.Text][view.SelectedNode.Index]);
                        break;
                    default:
                        throw new Exception("Unknown instance used by plugin!");
                }
                switch (descriptor.out_type)
                {
                    case plugin_output_type.message:
                        MessageBox.Show(result_of_work.ToString(), descriptor.plgn_text);
                        break;
                    case plugin_output_type.file:
                        string filename = descriptor.plgn_name + "_" + DateTime.Now.Hour.ToString() + "-" +
                                                                       DateTime.Now.Minute.ToString() + "-" +
                                                                       DateTime.Now.Second.ToString() + ".txt";
                        StreamWriter writer = new StreamWriter(filename);
                        writer.Write(result_of_work.ToString());
                        MessageBox.Show("Записано в файл '" + filename + "'", "Запись результата в файл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        writer.Close();
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка работы плагина: " + ex.Message, descriptor.plgn_text);
            }
        }
    }
}

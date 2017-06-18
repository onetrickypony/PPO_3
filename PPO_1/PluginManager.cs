using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace GroupsBase
{
    class PluginManager
    {
        [ImportMany(typeof(IPlugin))]
        IPlugin[] Plugins;

        TreeView view;
        ContextMenuStrip root_menu, group_menu, student_menu;

        public PluginManager(TreeView tree, ContextMenuStrip root, ContextMenuStrip group, ContextMenuStrip student)
        {
            view = tree;
            root_menu = root;
            group_menu = group;
            student_menu = student;

            var catalog = new DirectoryCatalog(Environment.CurrentDirectory);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        public void LoadPlugins()
        {
            List<KeyValuePair<plugin_descriptor, EventHandler>> injection = GetInjection;

            try
            {
                for (int i = 0; i < injection.Count; i++)
                {
                    ToolStripMenuItem item_root = new ToolStripMenuItem();
                    ToolStripMenuItem item_group = new ToolStripMenuItem();
                    ToolStripMenuItem item_student = new ToolStripMenuItem();

                    item_root.Name = item_group.Name = item_student.Name = injection[i].Key.plgn_name;
                    item_root.Text = item_group.Text = item_student.Text = injection[i].Key.plgn_text;

                    item_root.Tag = plugin_context_type.root;
                    item_group.Tag = plugin_context_type.group;
                    item_student.Tag = plugin_context_type.student;

                    item_root.Click += injection[i].Value;
                    item_group.Click += injection[i].Value;
                    item_student.Click += injection[i].Value;

                    switch (injection[i].Key.cont_type)
                    {
                        case plugin_context_type.root:
                            root_menu.Items.Add(item_root);
                            break;

                        case plugin_context_type.group:
                            group_menu.Items.Add(item_group);
                            break;

                        case plugin_context_type.student:
                            student_menu.Items.Add(item_student);
                            break;

                        case plugin_context_type.root_group:
                            root_menu.Items.Add(item_root);
                            group_menu.Items.Add(item_group);
                            break;

                        case plugin_context_type.root_student:
                            root_menu.Items.Add(item_root);
                            student_menu.Items.Add(item_student);
                            break;

                        case plugin_context_type.group_student:
                            group_menu.Items.Add(item_group);
                            student_menu.Items.Add(item_student);
                            break;

                        case plugin_context_type.root_group_student:
                            root_menu.Items.Add(item_root);
                            group_menu.Items.Add(item_group);
                            student_menu.Items.Add(item_student);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки плагинов!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private List<KeyValuePair<plugin_descriptor, EventHandler>> GetInjection
        {
            get
            {
                List<KeyValuePair<plugin_descriptor, EventHandler>> result = new List<KeyValuePair<plugin_descriptor,EventHandler>>();

                for (int i = 0; i < Plugins.Length; i++)
                {
                    EventHandlerSheath temp = new EventHandlerSheath(Plugins[i], view);
                    EventHandler handler = temp.GiveHandler;
                    result.Add(new KeyValuePair<plugin_descriptor, EventHandler>(Plugins[i].Descriptor, handler));
                }

                return result;
            }
        }
    }
}

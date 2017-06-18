using PPO_1.Plugins;
using PPO_1.Reader;
using PPO_1.RedoUndo;
using PPO_1.Unloader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PPO_1
{
    public class Controller
    {
        private Root root;
        private UndoRedoStack<Root> stack;
        private ViewUpdater viewUpdater;
        private TreeView treeView;

        private PluginLoader pluginLoader;
        private PluginManager pluginManager;

        public Controller(TreeView treeView)
        {
            root = new Root();
            stack = new UndoRedoStack<Root>();
            viewUpdater = new ViewUpdater();
            this.treeView = treeView;
        }

        public void LoadFromFile(string filename)
        {
            root = new Root();
            IReader reader = new XmlReader();
            stack = new UndoRedoStack<Root>();

            root = reader.ReadData(root, filename);
            UpdateTreeview();
        }

        public void LoadPlugins(ContextMenu groupmenu, ContextMenu studentmenu)
        {
            pluginLoader = new PluginLoader();
            pluginManager = new PluginManager(groupmenu, studentmenu, treeView);

            List<IPlugin> plugList = pluginLoader.LoadPlugins(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Plugins"));

            StreamWriter streamWriter = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "InfoAboutLoadedPlugins.txt");

            foreach (IPlugin plugin in plugList)
            {
                try
                {
                    pluginManager.AddAction(plugin);
                    streamWriter.WriteLine("плагин " + plugin.name + " загружен");
                }
                catch
                {
                    streamWriter.WriteLine("Ошибка при загрузке плагина:" + plugin.name);
                    MessageBox.Show("Ошибка при загрузке плагина: " + plugin.name);
                }
            }

            streamWriter.Close();
        }

        public void UnLoadDataToFile(string filename)
        {
            IUnloader unloader = new XmlUnloader();
            unloader.Unload(filename, root); 
        }

        public void Undo()
        {
            root = stack.Undo(root);
            UpdateTreeview();
        }

        public void Redo()
        {
            root = stack.Redo(root);
            UpdateTreeview();
        }

        public void AddGroup(string grname, int position)
        {
            root = stack.Do(new AddGroupCommand(new GroupInfo(grname), position), root);
            UpdateTreeview();
        }

        public void DeleteGroup(int position)
        {
            root = stack.Do(new DeleteGroupCommand(position), root);
            UpdateTreeview();
        }

        public void AddStudent(string surname, string name, string fathername, int rating, string avatar, int grpos, int perpos)
        {
            root = stack.Do(new AddStudentCommand(new PersonInfo(surname, name, fathername, rating, avatar), grpos, perpos), root);
            UpdateTreeview();
        }

        public void DeleteStudent(int grnum, int pernum)
        {
            root = stack.Do(new DeleteStudentCommand(grnum, pernum), root);
            UpdateTreeview();
        }

        public void EditGroup(string grname, int position)
        {
            root = stack.Do(new EditGroupCommand(new GroupInfo(grname), position), root);
            UpdateTreeview();
        }

        public void EditStudent(string surname, string name, string fathername, int rating, string avatar, int grpos, int perpos)
        {
            root = stack.Do(new EditStudentCommand(new PersonInfo(surname, name, fathername, rating, avatar), grpos, perpos), root);
            UpdateTreeview();
        }

        private void UpdateTreeview()
        {
            if (treeView.SelectedItem != null)
            {
                ((TreeViewItem)(treeView.SelectedItem)).IsSelected = false;
            }

            treeView.Items.Clear();
            viewUpdater.UpdateTreeView(treeView, root);
        }

    }
}

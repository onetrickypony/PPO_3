using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PPO_1.Plugins;
using PPO_1.RedoUndo;
using Microsoft.Win32;
using System.IO;

namespace Plugin_2
{
    public class SPlugin : IPlugin
    {
        public TreeView treeView { get; set; }
        public string name { get { return "OutputStudentToFilePlugin"; } }
        public string application { get { return "student"; } }
        public string content { get { return "Сохранить в файл"; } }
        public void Action(object source, EventArgs nothing)
        {
            TreeViewItem selectedItem = treeView.SelectedItem as TreeViewItem;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(selectedItem.ToolTip);
                streamWriter.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPO_1
{
    class ViewUpdater
    {
        public void UpdateTreeView(TreeView treeView, Root root)
        {
            for (int i = 0; i < root.Count; i++)
            {
                TreeViewItem treeNode = new TreeViewItem
                {
                    Header = root[i].GroupName,
                    IsExpanded = true
                };

                treeNode.ToolTip = "Группа: " + root[i].GroupName + "\n" +
                                    "Количество студентов: " + root[i].Count + "\n" +
                                    "Максимальный рейтинг: " + root[i].MaxRating + "\n" +
                                    "Средний рейтинг: " + root[i].MiddleRating + "\n" +
                                    "Минимальный рейтинг: " + root[i].MinRating;

                treeView.Items.Add(treeNode);
                TransferPersonsToTreeView(root[i], treeNode);
            }
        }

        private void TransferPersonsToTreeView(GroupInfo group, TreeViewItem treeNode)
        {
            for (int i = 0; i < group.Count; i++)
            {
                TreeViewItem childTreeNode = new TreeViewItem
                {
                    Header = group[i].Surname + " " + group[i].Name + " " + group[i].FatherName,
                    IsExpanded = true
                };

                childTreeNode.ToolTip = group[i].Surname + " " + group[i].Name + " " + group[i].FatherName + "\n" +
                                        "Группа: " + group.GroupName + "\n" +
                                        "Рейтинг: " + group[i].Rating + "\n" +
                                        "Аватар: " + group[i].Avatar;

                treeNode.Items.Add(childTreeNode);
            }
        }
    }
}

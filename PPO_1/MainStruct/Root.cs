using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace PPO_1
{
    // переписать все так, чтобы была агрегация, классы гринфо перинфо создавались в мейне
    public class Root
    {
        
        private List<GroupInfo> groups;

        public int Count
        {
            get
            { return groups.Count; }
        }

        public Root()
        {
            groups = new List<GroupInfo>();
        }
        

        public void addGroup(string grname)
        {
            groups.Add(new GroupInfo(grname));
        }

        public void addGroup(string grname, int gr_id)
        {
            groups.Insert(gr_id, new GroupInfo(grname));
        }

        public void addGroup(GroupInfo group)
        {
            groups.Add(group);
        }

        public void addGroup(GroupInfo group, int position)
        {
            groups.Insert(position, group);
        }

        public void addPerson(string surname, string name, string fathername, int rating, int gr_id, int per_id)
        {
            groups[gr_id].addPerson(surname, name, fathername, rating, per_id);
        }

        public void addPerson(PersonInfo person, int gr_position, int per_position)
        {
            groups[gr_position].addPerson(person, per_position);
        }

        // Удаление группы по id в treeview
        public void deleteGroup(int id)
        {
            groups[id].PersonsClear();
            groups.RemoveAt(id);
        }

        public void deletePerson(int gr_id, int per_id)
        {
            groups[gr_id].deletePerson(per_id);
        }

        public GroupInfo this[int index]
        {
            get
            {
                if (index < groups.Count && index >= 0)
                {
                    return groups[index];
                }
                else
                    return null;

            }
        }

        /*
        public void loadDataFromXMLFile(string xmlFilePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            foreach (XmlNode group in doc.DocumentElement)
            {
                addGroup(group.Attributes[0].Value);

                XmlNode students = group.FirstChild;

                foreach (XmlNode student  in students.ChildNodes)
                {
                    string surname = student["surname"].InnerText;
                    string name = student["name"].InnerText;
                    string fathername = student["middleName"].InnerText;
                    int rating = int.Parse(student["rating"].InnerText);
                    groups[groups.Count - 1].addPerson(surname, name, fathername, rating);
                }
            }
        }

        public void TransferInfoToTreeView(TreeView treeView)
        {
            foreach (GroupInfo group in groups)
            {
                TreeViewItem treeNode = new TreeViewItem
                {
                    Header = "ГР" + group.GroupName,
                    IsExpanded = true
                };

                treeNode.ToolTip = "Группа № " + group.GroupName + "\n" +
                                    "Количество студентов: " + group.Count + "\n" +
                                    "Максимальный рейтинг: " + group.MaxRating + "\n"+
                                    "Средний рейтинг: " + group.MiddleRating + "\n" +
                                    "Минимальный рейтинг: " + group.MinRating;

                treeView.Items.Add(treeNode);
                group.TransferPersonsToTreeView(treeNode);
            }
        }
        */
    }
}

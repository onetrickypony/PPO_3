using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPO_1
{
    // посчитать остальные параметры при выводе
    
    public class GroupInfo
    {

        private List<PersonInfo> persons;
        private string groupname;

        public string GroupName
        {
            get { return groupname;}
        }

        public int Count
        {
            get
            {
                return persons.Count;
            }
        }
        public int MaxRating
        {
            get
            {
                int max_rating = 0;

                foreach (PersonInfo person in persons)
                {
                    if (person.Rating > max_rating)
                        max_rating = person.Rating;
                }

                return max_rating;
            }
        }

        public int MiddleRating
        {
            get
            {
                int middle_rating = 0;

                if (persons.Count != 0)
                {
                    foreach (PersonInfo person in persons)
                    {
                        middle_rating += person.Rating;
                    }
                    middle_rating = middle_rating / persons.Count;
                }

                return middle_rating;
            }
        }

        public int MinRating
        {
            get
            {
                int min_rating = 100;

                foreach (PersonInfo person in persons)
                {
                    if (person.Rating < min_rating)
                        min_rating = person.Rating;
                }

                if (persons.Count == 0)
                    min_rating = 0;

                return min_rating;
            }
        }

        public PersonInfo this[int index]
        {
            get
            {
                if (index < persons.Count && index >= 0)
                {
                    return persons[index];
                }
                else
                    return null;

            }
        }

        public GroupInfo(string groupname)
        {
            persons = new List<PersonInfo>();

            this.groupname = groupname;
        }

        public GroupInfo(GroupInfo group)
        {
            this.groupname = group.GroupName;
            this.persons = new List<PersonInfo>(group.persons);
        }

        public void PersonsClear()
        {
            persons.Clear();
        }

        public void addPerson(string surname, string name, string fathername, int rating)
        {
            persons.Add(new PersonInfo(surname, name, fathername, rating, ""));
        }

        public void addPerson(PersonInfo person, int position)
        {
            persons.Insert(position, person);
        }

        public void addPerson(string surname, string name, string fathername, int rating, int per_id)
        {
            persons.Insert(per_id, new PersonInfo(surname, name, fathername, rating, ""));
        }

    
        // Удаление по номеру в treview
        public void deletePerson(int id)
        {
            persons.RemoveAt(id);
        }

        /*
        public void TransferPersonsToTreeView(TreeViewItem treeNode)
        {
            foreach (PersonInfo person in persons)
            {
                TreeViewItem childTreeNode = new TreeViewItem
                {
                    Header = person.Surname + " " + person.Name + " " + person.FatherName,
                    IsExpanded = true
                };

                childTreeNode.ToolTip = person.Surname + " " + person.Name + " " + person.FatherName + "\n" +
                                        "Группа № " + this.groupname + "\n" +
                                        "Рейтинг: " + person.Rating + "\n" +
                                        "Аватар: " + person.Avatar;

                treeNode.Items.Add(childTreeNode);
            }
        }
        */
        
    }
}

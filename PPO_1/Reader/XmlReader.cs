using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PPO_1.Reader
{
    class XmlReader : IReader
    {
        public Root ReadData(Root root, string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            foreach (XmlNode group in doc.DocumentElement)
            {
                root.addGroup(group.Attributes[0].Value);

                XmlNode students = group.FirstChild;

                foreach (XmlNode student in students.ChildNodes)
                {
                    string surname = student["surname"].InnerText;
                    string name = student["name"].InnerText;
                    string fathername = student["middleName"].InnerText;
                    int rating = int.Parse(student["rating"].InnerText);
                    root[root.Count - 1].addPerson(surname, name, fathername, rating);
                }
            }

            return root;
        }
    }
}

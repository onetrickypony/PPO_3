using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PPO_1.Unloader
{
    class XmlUnloader : IUnloader
    {
        public void Unload(string filename, Root root)
        {
            XmlTextWriter textWriter = new XmlTextWriter(filename, Encoding.UTF8);
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("groups");

            textWriter.WriteEndElement();
            textWriter.WriteEndDocument();

            textWriter.Close();

            XmlDocument document = new XmlDocument();
            document.Load(filename);

            for (int i = 0; i < root.Count; i++)
            {
                XmlNode group = document.CreateElement("group");
                document.DocumentElement.AppendChild(group);
                XmlAttribute attribute = document.CreateAttribute("name");
                attribute.Value = root[i].GroupName;
                group.Attributes.Append(attribute);

                XmlNode students = document.CreateElement("students");
                group.AppendChild(students);

                for (int j = 0; j < root[i].Count; j++)
                {
                    XmlNode student = document.CreateElement("student");
                    students.AppendChild(student);

                    XmlNode surname = document.CreateElement("surname");
                    surname.InnerText = root[i][j].Surname;
                    student.AppendChild(surname);

                    XmlNode name = document.CreateElement("name");
                    name.InnerText = root[i][j].Name;
                    student.AppendChild(name);

                    XmlNode middlename = document.CreateElement("middleName");
                    middlename.InnerText = root[i][j].FatherName;
                    student.AppendChild(middlename);

                    XmlNode rating = document.CreateElement("rating");
                    rating.InnerText = root[i][j].Rating.ToString();
                    student.AppendChild(rating);
                }
            }

            document.Save(filename);     
        }
    }
}

/*
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
 */

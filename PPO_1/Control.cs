using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupsBase
{
    class Control
    {
        StructureOfGroups main_data_structure;
        CommandStack command_stack;

        public Control()
        {
            main_data_structure = StructureOfGroups.Instance;
            command_stack = new CommandStack();
        }

        public List<TreeNode> UpdateTree()
        {
            List<TreeNode> updated_nodes = new List<TreeNode>();
            for (int i = 0; i < main_data_structure.Groups.Count; i++)
            {
                List<TreeNode> next_level = new List<TreeNode>();
                for (int j = 0; j < main_data_structure[i].StudentsCount; j++)
                    next_level.Add(new TreeNode(main_data_structure[i][j].Surname + " " + 
                                                main_data_structure[i][j].Name + " " + 
                                                main_data_structure[i][j].Secondname));
                updated_nodes.Add(new TreeNode(main_data_structure[i].GetIndex, next_level.ToArray()));
            }
            return updated_nodes;
        }

        public void AddGroup(string name)
        {
            command_stack.AddGroup(new GroupCard(name));
        }

        public void AddStudent(StudentCard student)
        {
            command_stack.AddStudent(student);
        }

        public void UpdateStudent(StudentCard old_rec, StudentCard new_rec)
        {
            command_stack.UpdateStudent(old_rec, new_rec);
        }

        public void RenameGroup(string old_name, string new_name)
        {
            command_stack.RenameGroup(old_name, new_name);
        }

        public void DeleteGroup(string name)
        {
            command_stack.DeleteGroup(main_data_structure[name]);
        }

        public void DeleteStudent(string group_name, int student_index)
        {
            command_stack.DeleteStudent(main_data_structure[group_name][student_index]);
        }

        public void Undo()
        {
            command_stack.Undo();
        }

        public void Redo()
        {
            command_stack.Redo();
        }

        public void LoadFromFile(string filename)
        {
            IReader reader = new ParseJSON();
            List<GroupCard> list = reader.Read(filename);
            if (list != null)
                command_stack.Load(list);
        }

        public void SaveToFile(string filename)
        {
            IWriter writer = new WriterJSON();
            writer.Write(filename, main_data_structure.Groups);
        }

        public string GetToolTipTextForStudentCard(string group_name, int index)
        {
            StudentCard student = main_data_structure[group_name][index];
            return "ФИО: " + student.Surname + " " + student.Name + " " + student.Secondname + "\n" +
                   "Группа: " + group_name + "\n" + "Рейтинг: " + student.Rate + "\n" +
                   "Аватар: " + student.Avatar;
        }

        public string GetToolTipTextForGroupCard(string group_name)
        {
            GroupCard group = main_data_structure[group_name];
            string full_name_head;
            if (group.GetHead == null)
                full_name_head = "";
            else
                full_name_head = group.GetHead.Surname + " " + group.GetHead.Name + " " + group.GetHead.Secondname;
            return "Группа " + group_name + "\n" + "Количество студентов: " + group.StudentsCount + "\n" +
                   "Староста: " + full_name_head + "\n" +
                   "Максимальный рейтинг: " + group.GetMaxRate + "\n" + "Средний рейтинг: " + Math.Round(group.GetAverageRate, 2) + "\n" +
                   "Минимальный рейтинг: " + group.GetMinRate + "\n";
        }

        public StudentCard GetStudentCard(string group_name, int index)
        {
            return main_data_structure[group_name][index];
        }
    }
}

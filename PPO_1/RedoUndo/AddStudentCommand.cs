using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPO_1.RedoUndo
{
    public class AddStudentCommand : ICommand<Root>
    {
        private int gr_position;
        private int per_position;
        private PersonInfo person;

        public AddStudentCommand(PersonInfo person , int gr_position, int per_position)
        {
            this.person = person;
            this.gr_position = gr_position;
            this.per_position = per_position;
        }

        public Root Do(Root root)
        {
            root.addPerson(person, gr_position, per_position);
            return root;
        }

        public Root Undo(Root root)
        {
            root.deletePerson(gr_position, per_position);
            return root;
        }
    }
}

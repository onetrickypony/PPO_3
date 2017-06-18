using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPO_1.RedoUndo
{
    public class DeleteStudentCommand : ICommand<Root>
    {
        private int gr_position;
        private int per_position;
        private PersonInfo person;

        public DeleteStudentCommand(int gr_position, int per_position)
        {
            this.gr_position = gr_position;
            this.per_position = per_position;
        }

        public Root Do(Root root)
        {
            person = root[gr_position][per_position];
            root.deletePerson(gr_position, per_position);
            return root;
        }

        public Root Undo(Root root)
        {
            root.addPerson(person, gr_position, per_position);
            return root;
        }
    }
}

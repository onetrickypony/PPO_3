using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPO_1.RedoUndo
{
    public class DeleteGroupCommand : ICommand<Root>
    {
        private int position;
        private GroupInfo group;

        public int NumInList
        {
            set { position = value; }
        }

        public DeleteGroupCommand(int position)
        {
            this.position = position;
        }

        public Root Do(Root root)
        {
            group = new GroupInfo(root[position]);
            root.deleteGroup(position);
            return root;
        }

        public Root Undo(Root root)
        {
            root.addGroup(group, position);
            return root;
        }
    }
}

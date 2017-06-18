using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPO_1.RedoUndo
{
    public class EditGroupCommand : ICommand<Root>
    {
        private int position;
        private GroupInfo groupold;
        private GroupInfo groupnew;

        public EditGroupCommand(GroupInfo group, int position)
        {
            this.groupnew = group;
            this.position = position;
        }

        public Root Do(Root root)
        {
            groupold = root[position];
            root.deleteGroup(position);
            root.addGroup(groupnew, position);
            return root;
        }

        public Root Undo(Root root)
        {
            root.deleteGroup(position);
            root.addGroup(groupold);
            return root;
        }
    }
}

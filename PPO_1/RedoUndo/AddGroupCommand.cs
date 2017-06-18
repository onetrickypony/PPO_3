using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPO_1.RedoUndo
{
    public class AddGroupCommand : ICommand<Root>
    {
        private int position;
        private GroupInfo group;

        public AddGroupCommand(GroupInfo group, int position)
        {
            this.group = group;
            this.position = position;
        }

        public Root Do(Root root)
        {
            root.addGroup(group, position);
            return root;
        }

        public Root Undo(Root root)
        {
            root.deleteGroup(position);
            return root;
        }

    }
}

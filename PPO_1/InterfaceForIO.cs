using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupsBase
{
    interface IReader
    {
        List<GroupCard> Read(string filename);
    }
    interface IWriter
    {
        void Write(string filename, List<GroupCard> list);
    }
}

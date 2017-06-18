using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPO_1.Reader
{
    interface IReader
    {
        Root ReadData(Root root, string filename);
    }
}

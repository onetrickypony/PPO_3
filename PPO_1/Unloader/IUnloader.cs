using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPO_1.Unloader
{
    interface IUnloader
    {
        void Unload(string filename, Root root);
    }
}

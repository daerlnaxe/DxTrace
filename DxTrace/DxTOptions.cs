using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxTrace
{
    [Flags]
    public enum DxTOptions
    {
        None = 0,
        TimeStamp = 2,
        Prefix = 4

    }
}
